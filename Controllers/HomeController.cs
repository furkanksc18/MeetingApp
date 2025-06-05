using Microsoft.AspNetCore.Mvc;
using MeetingApp.Data;
using MeetingApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeetingApp.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var topMeetings = await _context.MeetingMapUsers
            .GroupBy(m => m.MeetingId)
            .Select(g => new 
            {
                MeetingId = g.Key,
                ParticipantCount = g.Count()
            })
            .OrderByDescending(m => m.ParticipantCount)
            .Take(5)
            .ToListAsync();
        List<Meeting> MeetingsDetail = new List<Meeting>();
        foreach (var meet in topMeetings)
        {
            MeetingsDetail.Add(await _context.Meetings.Where(m => m.Id == meet.MeetingId).FirstOrDefaultAsync());
            
        }


        return View(MeetingsDetail);
    }

    public IActionResult About()
    {
        return View();
    }
}
