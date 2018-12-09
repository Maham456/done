using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookthedoctor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace bookthedoctor.Models
    {
        public class ExternalLoginConfirmationViewModel
        {
           // [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

        public class SendCodeViewModel
        {
            public string SelectedProvider { get; set; }
            public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
            public string ReturnUrl { get; set; }
            public bool RememberMe { get; set; }
        }

        public class VerifyCodeViewModel
        {
            //[Required]
            public string Provider { get; set; }

            //[Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
            public string ReturnUrl { get; set; }

            [Display(Name = "Remember this browser?")]
            public bool RememberBrowser { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ForgotViewModel
        {
           // [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class LoginViewModel
        {
           // [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            //[Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class RegisterViewModel
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
            public string DoctorID;
            
            public string Specialization;
            
            public string Clinic_Name;
            
            public string Clinic_Address;
            
            public string Hospital_Name;
           
            public string Hospital_Address;
            
            public string Clinic_Timing;
            
            public string Hospital_Timing;
         
            public string Clinic_working_days;
            
            public string Hospital_working_days;
        
            public int MBBS_CODE;
           
            [Display(Name = "Day Time")]
            public string Hospital_DayTime;
            
            [Display(Name = "Day Time")]
            public string Clinic_DayTime;
            
            public int Practising_Years;


        }

        public class ResetPasswordViewModel
        {
            //[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            //[Required]
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

        public class ForgotPasswordViewModel
        {
            //[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }

}