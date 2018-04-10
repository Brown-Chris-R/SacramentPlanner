using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Controllers
{
    [Authorize]
    public class SpeakingAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeakingAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpeakingAssignments
        public async Task<IActionResult> Index(int? id)
        {

            var speakingAssignments = from s in _context.SpeakingAssignments select s;

            if (id != 0)
            {
                speakingAssignments = speakingAssignments.Where(s => s.SacramentMeetingID.Equals(id));
            }

            speakingAssignments = speakingAssignments.OrderBy(s => s.SpeakingSequence);
            if (speakingAssignments == null)
            {
                return NotFound();
            }
            ViewData["SacramentMeetingID"] = id;

            return View(await speakingAssignments.Include(s => s.SacramentMeeting).ToListAsync());
        }

        // GET: SpeakingAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakingAssignment = await _context.SpeakingAssignments
                .Include(s => s.SacramentMeeting)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (speakingAssignment == null)
            {
                return NotFound();
            }

            return View(speakingAssignment);
        }

        // GET: SpeakingAssignments/Create
        public IActionResult Create(int? id)
        {
            var speakingAssignment = new SpeakingAssignment();
            speakingAssignment.AssignedOnDate = DateTime.Now;
            speakingAssignment.SacramentMeetingID = id.Value;
            ViewData["SacramentMeetingID"] = id;

            var sacramentMeeting = _context.SacramentMeetings.SingleOrDefaultAsync(s => s.ID == id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }
            speakingAssignment.SacramentMeeting = new SacramentMeeting();

            speakingAssignment.SacramentMeeting.MeetingDate = sacramentMeeting.Result.MeetingDate;
            return View(speakingAssignment);
        }

        // POST: SpeakingAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SacramentMeetingID,AssignedOnDate,SpeakingSequence,SpeakerName,AssignedTopic")] SpeakingAssignment speakingAssignment)
        {
            speakingAssignment.ID = 0;
            if (ModelState.IsValid)
            {
                _context.Add(speakingAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = speakingAssignment.SacramentMeetingID });
            }
            ViewData["SacramentMeetingID"] = speakingAssignment.SacramentMeetingID;
            return View(speakingAssignment);
        }

        // GET: SpeakingAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakingAssignment = await _context.SpeakingAssignments.Include(s => s.SacramentMeeting).SingleOrDefaultAsync(m => m.ID == id);
            if (speakingAssignment == null)
            {
                return NotFound();
            }
            ViewData["SacramentMeetingID"] = new SelectList(_context.SacramentMeetings, "ID", "ID", speakingAssignment.SacramentMeetingID);
            return View(speakingAssignment);
        }

        // POST: SpeakingAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SacramentMeetingID,AssignedOnDate,SpeakingSequence,SpeakerName,AssignedTopic")] SpeakingAssignment speakingAssignment)
        {
            if (id != speakingAssignment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakingAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakingAssignmentExists(speakingAssignment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = speakingAssignment.SacramentMeetingID });
            }
            ViewData["SacramentMeetingID"] = new SelectList(_context.SacramentMeetings, "ID", "ID", speakingAssignment.SacramentMeetingID);
            return View(speakingAssignment);
        }

        // GET: SpeakingAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakingAssignment = await _context.SpeakingAssignments
                .Include(s => s.SacramentMeeting)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (speakingAssignment == null)
            {
                return NotFound();
            }

            return View(speakingAssignment);
        }

        // POST: SpeakingAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakingAssignment = await _context.SpeakingAssignments.SingleOrDefaultAsync(m => m.ID == id);
            _context.SpeakingAssignments.Remove(speakingAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = speakingAssignment.SacramentMeetingID });
        }

        private bool SpeakingAssignmentExists(int id)
        {
            return _context.SpeakingAssignments.Any(e => e.ID == id);
        }
    }
}
