namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(254)]
        public string EmailID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Password { get; set; }

        public bool? IsEmailVerified { get; set; }

        public Guid? ActivationCode { get; set; }
    }
}
