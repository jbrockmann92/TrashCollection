using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public double Balance { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Pickup")]
        [Display(Name = "Pickup Information")]
        public int? PickupId { get; set; }
        public Pickup Pickup { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string? IdentityUserId { get; set; }
        //Should this match the one from AspNetUserRoles? Or be unique? Unique I think, then the IdentityUser has its own identifier
        //Or should I make the Id the same as the IdentityUser's Id?
        public IdentityUser IdentityUser { get; set; }

    }
}
