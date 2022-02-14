using System.ComponentModel.DataAnnotations;

namespace RecipeSuggestion.Models.ViewModel
{
	public class LogInViewModel
	{
        [Required(ErrorMessage = "Please enter an email address.")]
        [MaxLength(200)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Please enter a password.")]
        [MaxLength(200)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
