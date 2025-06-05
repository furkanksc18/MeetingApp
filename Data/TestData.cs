using MeetingApp.Data.Entity;

namespace MeetingApp.Data
{
    public static class TestData
    {
        public static List<Meeting> Meetings = new List<Meeting>
        {
            new Meeting
            {
                Id = 1,
                Name = "Yeni Proje Lansmanı",
                Location = "Ana Konferans Salonu",
                Date = DateTime.Now.AddDays(2),
                Type = "Sunum"
            },
            new Meeting
            {
                Id = 2,
                Name = "Ekip Toplantısı",
                Location = "Toplantı Odası 3",
                Date = DateTime.Now.AddDays(1),
                Type = "İç Toplantı"
            },
            new Meeting
            {
                Id = 3,
                Name = "Müşteri Görüşmesi",
                Location = "VIP Toplantı Odası",
                Date = DateTime.Now.AddDays(3),
                Type = "Müşteri Toplantısı"
            },
            new Meeting
            {
                Id = 4,
                Name = "Yazılım Geliştirme Planlaması",
                Location = "Geliştirme Odası",
                Date = DateTime.Now.AddDays(5),
                Type = "Planlama"
            }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Ahmet",
                Surname = "Yılmaz",
                Age = 28,
                Email = "ahmet.yilmaz@company.com",
                Phone = 5551234567
            },
            new User
            {
                Id = 2,
                Name = "Ayşe",
                Surname = "Kaya",
                Age = 32,
                Email = "ayse.kaya@company.com",
                Phone = 5559876543
            },
            new User
            {
                Id = 3,
                Name = "Mehmet",
                Surname = "Demir",
                Age = 25,
                Email = "mehmet.demir@company.com",
                Phone = 5554567890
            },
            new User
            {
                Id = 4,
                Name = "Zeynep",
                Surname = "Çelik",
                Age = 35,
                Email = "zeynep.celik@company.com",
                Phone = 5557890123
            }
        };

        public static List<MeetingMapUser> MeetingMapUsers = new List<MeetingMapUser>
        {
            // Yeni Proje Lansmanı'na katılanlar
            new MeetingMapUser { Id = 1, MeetingId = 1, UserId = 1 },
            new MeetingMapUser { Id = 2, MeetingId = 1, UserId = 2 },
            new MeetingMapUser { Id = 3, MeetingId = 1, UserId = 3 },

            // Ekip Toplantısı'na katılanlar
            new MeetingMapUser { Id = 4, MeetingId = 2, UserId = 1 },
            new MeetingMapUser { Id = 5, MeetingId = 2, UserId = 2 },
            new MeetingMapUser { Id = 6, MeetingId = 2, UserId = 4 },

            // Müşteri Görüşmesi'ne katılanlar
            new MeetingMapUser { Id = 7, MeetingId = 3, UserId = 2 },
            new MeetingMapUser { Id = 8, MeetingId = 3, UserId = 3 },

            // Yazılım Geliştirme Planlaması'na katılanlar
            new MeetingMapUser { Id = 9, MeetingId = 4, UserId = 1 },
            new MeetingMapUser { Id = 10, MeetingId = 4, UserId = 3 },
            new MeetingMapUser { Id = 11, MeetingId = 4, UserId = 4 }
        };
    }
} 