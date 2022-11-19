using System.ComponentModel.DataAnnotations;

namespace ADM.Store.Models.Models.Customer
{
    public class CustomerCreateModel
    {
        [Required]
        public string FirtName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Group1 { get; set; }
        public int Group2 { get; set; }
        public int Group3 { get; set; }

    }

    public class CustomerDetailsModel
    {
        public int Id { get; set; }
        public string FirtName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Group1 { get; set; }
        public int Group2 { get; set; }
        public int Group3 { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class CustomerUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirtName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Group1 { get; set; }
        public int Group2 { get; set; }
        public int Group3 { get; set; }
    }
}
