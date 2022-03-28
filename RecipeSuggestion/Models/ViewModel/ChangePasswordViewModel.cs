using System.ComponentModel.DataAnnotations;

namespace RecipeSuggestion.Models.ViewModel
{
	public class ChangePasswordViewModel
	{
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your current password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter a new password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
	}
}
