public class UserLoginModel
{
    [Required(ErrorMessage = "The username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "The password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}