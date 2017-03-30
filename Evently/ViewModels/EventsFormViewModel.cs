using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Evently.Models;

namespace Evently.ViewModels
{
    public class EventsFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        public int? OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }
        
        [Display(Name = "Type")]
        [Required]
        public byte? EventTypeId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "When its going down")]
        [Required]
        public DateTime EventDate { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Event" : "New Event";
            }
        }

        public EventsFormViewModel()
        {
            Id = 0;
        }

        public EventsFormViewModel(Event events)
        {
            Id = events.Id;
            Name = events.Name;
            GenreId = events.GenreId;
        }
    }
}