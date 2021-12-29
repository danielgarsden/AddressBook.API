using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AddressBook.API.Entities
{

    /// <summary>
    /// Address Book entity containing all the properties of an AddressBook entry
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The Id of a specific Address Book record
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        /// <summary>
        /// The first name of the Address Book entry
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Address Book entry
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// The first Address Line of the Address Book entry
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second Address Line of the Address Book entry
        /// </summary>
        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The third Address Line of the Address Book entry
        /// </summary>
        [MaxLength(100)]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The city of the Address Book entry
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// The post code of the Address Book entry
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        /// <summary>
        /// The Land line phonenumber of the Address Book entry
        /// </summary>
        [MaxLength(11)]
        public string LandLineNumber { get; set; }

        /// <summary>
        /// The mobile phone number of the Address Book entry
        /// </summary>
        [MaxLength(11)]
        public string MobileNumber { get; set; }

        [MaxLength(50)]
        public string County { get; set; }

        public virtual List<AddressAudit> AddressAudit { get; set; } = new List<AddressAudit>();

        public bool Deleted { get; set; }
    }
}
