using System.ComponentModel.DataAnnotations;

namespace PublicSurveyForm.Domain.Models
{
    public class PublicReview
    {
        [Required(ErrorMessage ="Full Name required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "First Name required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "DOD  required")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Living Place required")]
        public string? PlaceLiving { get; set; }
        [Required(ErrorMessage = "Email  required")]
        [RegularExpression(
    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
    ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Corruption in India required")]
        public string? CorruptionInIndia { get; set; }
    }
}
