namespace MeetingApp.Data.Entity
{
    public class MeetingMapUser
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}