namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }

        public UserDTO() { }

        public UserDTO(int id, string username, string password, string role, string name)
        {
            Id = id;  
            Username = username;
            Password = password;
            Role = role;
            Name = name;
        }
    }
}
