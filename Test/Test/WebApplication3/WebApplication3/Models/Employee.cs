namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
