using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }
        public string PickupDay { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsCompleted { get; set; }

        [Display(Name = "Suspension Start Date")]
        public DateTime SuspendedStart { get; set; }

        [Display(Name = "Suspension End Date")]
        public DateTime SuspendedEnd { get; set; }
        public DateTime OneTimePickup { get; set; }

    }
}
