using System.ComponentModel.DataAnnotations;

namespace Belatrix.Final.WebApi.ViewModels
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}