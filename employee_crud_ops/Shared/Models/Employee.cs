using System.ComponentModel.DataAnnotations;

namespace employee_crud_ops.Shared.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string? Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
    }
}
