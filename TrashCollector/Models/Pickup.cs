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
        //Make into list? Then customer can choose from a dropdown menu
        public bool IsSuspended { get; set; }
        public DateTime SuspendedStart { get; set; }
        public DateTime SuspendedEnd { get; set; }
        public DateTime OneTimePickup { get; set; }

    }
}
