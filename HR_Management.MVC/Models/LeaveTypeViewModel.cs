﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Default Day")]
        public int DefaultDay { get; set; }
    }
}
