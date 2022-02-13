using System.ComponentModel.DataAnnotations;

namespace EmplyeeDirectory.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
