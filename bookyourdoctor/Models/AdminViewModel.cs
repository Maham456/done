using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace bookyourdoctor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace bookyourdoctor.Models
    {
        public class ExternalLoginConfirmationViewModeL
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModeL
        {
            public string ReturnUrl { get; set; }
        }

        public class SendCodeViewModeL
        {
            public string SelectedProvider { get; set; }
            public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
            public string ReturnUrl { get; set; }
            public bool RememberMe { get; set; }
        }

        public class VerifyCodeViewModeL
        {
            [Required]
            public string Provider { get; set; }

            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
            public string ReturnUrl { get; set; }

            [Display(Name = "Remember this browser?")]
            public bool RememberBrowser { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ForgotViewModeL
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class LoginViewModeL
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModeL
        {

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }


            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]

            public string Name;
            public int PhoneNumber;
            public string PatientID;


        }

        public class ResetPasswordViewModeL
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public class ForgotPasswordViewModeL
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }

}