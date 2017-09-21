namespace DemoWeb.Models
{
    using DemoWeb.Class;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please Enter ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string name { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [ValidBirthDate(ErrorMessage = "DOB Should be between 01-25-1970 & 01-25-2000")]
        public DateTime birthDate { get; set; }
    }
}
