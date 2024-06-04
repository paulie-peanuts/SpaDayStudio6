namespace  SpaDay6.Models;

public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; } 
        public DateTime Date2 { get; set; } = DateTime.Now;
        
        public User() {}
        public User(string username, string email, string password, DateTime Date) : this()
        {
            Username = username;
            Email = email;
            Password = password;
            Date = DateTime.Now;
        }


    }