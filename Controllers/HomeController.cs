using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoActivity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DojoActivity.Controllers {
    public class HomeController : Controller {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController (MyContext context) {
            dbContext = context;
        }

        // ROUTES: //
        [HttpGet("")]       // display Login & Register on the same page
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost ("register")]     // Register User form
        public IActionResult Registration (User newUser) {
            if (ModelState.IsValid) {
                if (dbContext.Users.Any (u => u.Email == newUser.Email)) {
                    ModelState.AddModelError ("Email", "Email already in use!");
                    return View ("Index");
                }
                else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                    newUser.Password = Hasher.HashPassword (newUser, newUser.Password);
                    dbContext.Add (newUser);
                    dbContext.SaveChanges ();
                    var registerUser = dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);
                    HttpContext.Session.SetInt32 ("UserId", registerUser.UserId); // store in session logged in user's id
                    int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId");
                    return Redirect("/dashboard");
                }
            } 
            else {
                return View ("Index");
            }
        }

        [HttpPost ("login")]        // Login User form
        public IActionResult Login (LoginUser userSubmission) {
            if (ModelState.IsValid) {
                var userInDb = dbContext.Users.FirstOrDefault (u => u.Email == userSubmission.LoginEmail);
                if (userInDb == null) {
                    ModelState.AddModelError ("LoginEmail", "Invalid Email, try again or Register!");
                    return View ("Index"); // stays on the same page, there is a link to Register
                }
                var hasher = new PasswordHasher<LoginUser> ();
                var result = hasher.VerifyHashedPassword (userSubmission, userInDb.Password, userSubmission.LoginPassword);
                if (result == 0) {
                    ModelState.AddModelError ("LoginPassword", "Invalid Password, try again or Register!");
                    return View ("Index"); // stays on the same page, there is a link to Register
                }
                HttpContext.Session.SetInt32 ("UserId", userInDb.UserId);
                int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId");
                return Redirect("/dashboard");
            }
            return View ("Index");
        }

        [HttpGet ("dashboard")]     // SEE ALL ACTIVITIES
        public IActionResult Dashboard () {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/");
            }
            // send over the name
            int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId");
            User LoggedInUser = dbContext.Users.FirstOrDefault (u => u.UserId == LoggedInUserId);
            ViewBag.LoggedInUser = LoggedInUser;
            // display all the activities
            List<Activity> allActivities = dbContext.Activities
                .OrderBy (a => a.StartDate)
                .Include (a => a.Coordinator)
                .Include (a => a.Participations)
                .ThenInclude (p => p.User)
                .ToList ();
            ViewBag.allActs = allActivities;
            return View (allActivities);
        }

        
        [HttpGet("newactivity")]        // DISPLAY NEW ACTIVITY FORM
        public IActionResult NewActivity()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/");
            }
            // send over the name
            int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId");
            User LoggedInUser = dbContext.Users.FirstOrDefault (u => u.UserId == LoggedInUserId);
            ViewBag.LoggedInUser = LoggedInUser;
            return View();
        }
        
        [HttpPost("newactivity")]        // POST ROUTE TO ADD NEW ACTIVITY
        public IActionResult AddActivity(Activity newActivity)
        {
            int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId"); // im grabbing the user id in session
            User LoggedInUser = dbContext.Users.FirstOrDefault (u => u.UserId == LoggedInUserId); // im grabbing the user that's in session
            ViewBag.LoggedInUser = LoggedInUser; // i'm putting it in a viewBag

            if(ModelState.IsValid)
            {
                if (newActivity.Duration <= 0) 
                {
                    ModelState.AddModelError ("Duration", "Enter a Duration");
                    return View ();
                } 
                else 
                {
                    int min = newActivity.StartTime.Minute;
                    int hour = newActivity.StartTime.Hour;
                    newActivity.StartDate = newActivity.StartDate.AddHours (hour);
                    newActivity.StartDate = newActivity.StartDate.AddMinutes (min);
                    newActivity.CoordinatorId = (int)LoggedInUserId;
                    dbContext.Activities.Add (newActivity);
                    dbContext.SaveChanges ();
                    return RedirectToAction ("dashboard");
                }
            }
            return View("NewActivity");
        }

        [HttpGet ("activity/{actId}")]      // VIEW ONE ACTIVITY
        public IActionResult ViewActivity (int actId) 
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/");
            }
            int? LoggedInUserId = HttpContext.Session.GetInt32 ("UserId");
            User LoggedInUser = dbContext.Users.FirstOrDefault (u => u.UserId == LoggedInUserId);
            ViewBag.LoggedInUser = LoggedInUser;
            
            Activity ActivityDetails = dbContext.Activities
                .Include (a => a.Coordinator)
                .Include (a => a.Participations)
                .ThenInclude (p => p.User)
                .FirstOrDefault (a => a.ActivityId == actId);
            
            return View (ActivityDetails);
        }
        
        [HttpGet ("delete/{actId}")]     // DELETE YOUR ACTIVITY
        public IActionResult Delete (int actId) {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/");
            }
            Activity activityToDel = dbContext.Activities.FirstOrDefault (a => a.ActivityId == actId);
            dbContext.Remove (activityToDel);
            dbContext.SaveChanges ();
            return RedirectToAction ("dashboard");
        }

        [HttpGet("join/{actId}")]       // JOIN AN ACTIVITY
        public IActionResult JoinActivity(int actId)
        {
            
            int? LoggedInUser = HttpContext.Session.GetInt32("UserId");
            Activity oneActivity = dbContext.Activities.FirstOrDefault(e=>e.CoordinatorId == actId);
            User thisUser = dbContext.Users.FirstOrDefault(u=>u.UserId == (int)LoggedInUser);
            Participation newPart = new Participation();

            List<Participation> yourActivities = dbContext.Participations
            .Where(p=>p.UserId == (int) LoggedInUser)
            .Include(p=>p.Activity)
            .ToList();

            foreach(var part in yourActivities)
            {
                if(part.Activity.StartDate == oneActivity.StartDate)
                {
                    TempData["Overlapping"] = "You're already going to an activity!";
                    return Redirect($"/activity/{actId}");
                }
            }
            newPart.Activity = oneActivity;
            newPart.User = thisUser;
            newPart.UserId = (int) LoggedInUser;
            newPart.ActivityId = actId;
            dbContext.Participations.Add(newPart);
            dbContext.SaveChanges();
            return Redirect("/dashboard");
        }

        [HttpGet ("leave/{actId}")]        // LEAVE AN ACTIVITY
        public IActionResult LeaveActivity (int actId) {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return Redirect("/");
            }
            int? LoggedInUser = HttpContext.Session.GetInt32("UserId");
            Participation thisPart;
            List<Participation> partAct = dbContext.Participations
            .Where (p => p.ParticipationId == actId).ToList();
            foreach(var r in partAct)
            {
                if(r.UserId == (int)LoggedInUser)
                {
                    thisPart = r;
                    dbContext.Participations.Remove(thisPart);
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction ("dashboard");
        }

        [HttpGet ("logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("/");
        }
    }
}