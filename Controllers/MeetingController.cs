using System.Security.Claims;
using System.Threading.Tasks;
using MeetingApp.Data;
using MeetingApp.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeetingApp.Controllers;

public class MeetingController : Controller
{
    private readonly DataContext _Context;

    public MeetingController(DataContext context)
    {
        _Context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Veritabanı hazır olana kadar test verilerini kullan
        // var meetings = TestData.Meetings;
        // return View(meetings);

        var meetings = await _Context.Meetings.ToListAsync();
        if (meetings == null)
        {
            return NoContent();
        }

        return View(meetings);
    }

    [Authorize]
    public async Task<IActionResult> Join(int MeetingId)
    {
        // Meeting ve User'ın var olup olmadığını kontrol et
        var meeting = await _Context.Meetings.FirstOrDefaultAsync(m => m.Id == MeetingId);
        if (meeting == null)
        {
            return NotFound($"Toplantı bulunamadı. MeetingId: {MeetingId}");
        }

        int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var user = await _Context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
        if (user == null)
        {
            return NotFound($"Kullanıcı bulunamadı. UserId: {UserId}");
        }

        // Kullanıcının zaten katılıp katılmadığını kontrol et
        var existingJoin = await _Context.MeetingMapUsers
            .FirstOrDefaultAsync(m => m.MeetingId == MeetingId && m.UserId == UserId);
        
        if (existingJoin != null)
        {
            return RedirectToAction("Detail", new { MeetingId });
        }

        // Yeni katılım kaydı oluştur
        var mmu = new MeetingMapUser 
        { 
            UserId = UserId, 
            MeetingId = MeetingId,
            User = user,
            Meeting = meeting
        };

        await _Context.MeetingMapUsers.AddAsync(mmu);
        await _Context.SaveChangesAsync();

        return RedirectToAction("Detail", new { MeetingId });
    }

    [Authorize]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Meeting meeting)
    {
        _Context.Meetings.Add(meeting);
        await _Context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Detail(int MeetingId)
    {
        // Veritabanı hazır olana kadar test verilerini kullan
        // var meeting = TestData.Meetings.FirstOrDefault(m => m.Id == MeetingId);

        var meeting = await _Context.Meetings.FirstOrDefaultAsync(m => m.Id == MeetingId);
        if (meeting == null)
        {
            return NotFound();
        }

        return View(meeting);
    }

    public async Task<IActionResult> Participants(int MeetingId)
    {
        // var meeting = TestData.Meetings.FirstOrDefault(m => m.Id == MeetingId);
        // var participants = TestData.MeetingMapUsers
        //     .Where(mmu => mmu.MeetingId == MeetingId)
        //     .Select(mmu => new MeetingMapUser
        //     {
        //         Id = mmu.Id,
        //         MeetingId = mmu.MeetingId,
        //         UserId = mmu.UserId,
        //         User = TestData.Users.FirstOrDefault(u => u.Id == mmu.UserId)
        //     })
        //     .ToList();

        var participants = await _Context.MeetingMapUsers.Where(m => m.MeetingId == MeetingId)
                                                        .Include(m => m.User)
                                                        .ToListAsync();

        var meeting = await _Context.Meetings.FirstOrDefaultAsync(m=> m.Id == MeetingId);

        if (meeting == null)
        {
            return NotFound();
        }
        ViewBag.Meeting = meeting;

        return View(participants);
    }
}