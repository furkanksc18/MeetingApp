namespace MeetingApp.Data.Entity
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
