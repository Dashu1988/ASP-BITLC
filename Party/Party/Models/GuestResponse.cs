using System.ComponentModel.DataAnnotations;

namespace Party.Models;

public class GuestResponse
{
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter your Email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter your Phone number")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Please enter if you want to attend")]
    public bool? WillAttend { get; set; }
}