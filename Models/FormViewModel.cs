using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models {
    public class FormViewModel {
        [Required(ErrorMessage = "Please enter a name.")]
        [MinLength(3, ErrorMessage="Name must be 3 characters or longer.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }
    }
}