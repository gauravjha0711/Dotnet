using System.ComponentModel.DataAnnotations;
namespace Auth_Login.Models
{
    public class UserLogin
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Please Enter UserNamw")]
        [Display(Name = "Please Enter UserName")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string passcode { get; set; }
        public int isActive { get; set; }
    }
}
