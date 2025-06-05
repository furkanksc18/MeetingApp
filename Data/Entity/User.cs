namespace MeetingApp.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }

    }
}