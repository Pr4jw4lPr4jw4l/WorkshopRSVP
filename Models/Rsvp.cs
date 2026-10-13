using System.ComponentModel.DataAnnotations;

namespace WorkshopRSVP.Models;

public sealed class Rsvp
{
    public Guid SubmissionId { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Please enter your full name.")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    [Display(Name = "Full name")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Needs accommodation")]
    public bool NeedsAccommodation { get; set; }

    [Required(ErrorMessage = "Please select a workshop.")]
    [Display(Name = "Workshop")]
    public string WorkshopTitle { get; set; } = string.Empty;
}
