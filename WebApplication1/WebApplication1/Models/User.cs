namespace WebApplication1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public bool IsAdmin { get; set; } //admin or customer

        public User()
        {
            UserId = 0;
            UserFirstName = String.Empty;
            UserLastName = String.Empty;
            UserEmail = String.Empty;
            UserPhone = String.Empty;
            IsAdmin = false; //customer
        }

    }
}
