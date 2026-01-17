using System.ComponentModel.DataAnnotations;

namespace GastritisTracker.Models;

public class LogEntry
{
    [Required(ErrorMessage = "Please select what you took/ate.")]
    public string ItemName { get; set; } = "";

    [Required(ErrorMessage = "How did you feel?")]
    public string Feeling { get; set; } = "";

    public DateTime Date { get; set; } = DateTime.Today;
}