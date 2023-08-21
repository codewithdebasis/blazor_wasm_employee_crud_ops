using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_crud_ops.Shared.Models
{
    public class EmployeeProfilePic
    {
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        [Required]
        public int EmployeeId { get; set; }

        public string ImageType { get; set; }

        public string? Thumbnail { get; set; }

        public string? ImageUrl { get; set; }

        public virtual Employee? EmployeeInfo { get; set; }

    }
}
