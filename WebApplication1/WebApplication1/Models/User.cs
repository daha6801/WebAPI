public class User
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Display(Name = "Email address")]
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    public bool IsAdmin { get; set; } //admin or customer

    [Required(ErrorMessage = "The username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}