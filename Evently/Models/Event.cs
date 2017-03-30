using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Evently.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public EventType EventType { get; set; }
        [Display(Name = "Type")]
        [Required]
        public byte EventTypeId { get; set; }

        public DateTime DateAdded{ get ; set ;}
        [Display(Name = "When its going down")]
        [Required]
        public DateTime EventDate { get; set; }
    }
}