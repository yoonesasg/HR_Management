using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
    public class CreateLeaveTypeViewModel
    {
        [Required]
        public string Name { get; set; }
        [DisplayName("DefaultDay")]
        public int DefaultDay { get; set; }
    }
}
