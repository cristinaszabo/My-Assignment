using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoActivity.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId{get;set;}

        [Required]
        [Display (Name="Title")]
        [MinLength(2, ErrorMessage="Title has to be 2 characters or longer!")]
        public string ActivityTitle{get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date")]
        [ActivityDate(ErrorMessage="Activity must be in the future!")]
        public DateTime StartDate{get;set;}

        [NotMapped]
        [DataType(DataType.Time)]
        [Display(Name="Time")]
        public DateTime StartTime{get;set;}

        [Required]
        [MinLength(10,ErrorMessage="Description has to be longer than 10 characters!")]
        public string Description {get;set;}
        [Required]
        public int Duration {get;set;}
        [Required]
        public string TimeMeasure{get;set;}
        // connections
        public int CoordinatorId{get;set;}
        public User Coordinator{get;set;}
        public List<Participation> Participations{get;set;}
        
    }
}