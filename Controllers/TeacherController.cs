using ApiWithEntityFramework.Data;
using ApiWithEntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherModel>>> GetTeacherDetails()
        {
            if (_context.TeacherDetails == null)
            {
                return NotFound();
            }
            return await _context.TeacherDetails.ToListAsync();
        }

    }
}
