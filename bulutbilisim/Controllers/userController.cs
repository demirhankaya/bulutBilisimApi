using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using bulutbilisim.DB;
using bulutbilisim.Model;

namespace bulutbilisim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User_Tb> users = await _context.User.ToListAsync();

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        
        [HttpGet("GetLogin")]
        public async Task<IActionResult> GetLogin(string username, string password)
        {
            List<User_Tb> personel = await _context.User.Where(w => w.userName == username && w.pass == password).ToListAsync();

            if (personel.Count != 0)
            {
                return Ok(personel);
                
            }
            else
            {
                return NotFound();

            }
        }
        
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(string name, string username, string password)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User_Tb newUser = new User_Tb
                {
                    name = name,
                    userName = username,
                    pass = password,
                };

                await _context.User.AddAsync(newUser);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok("Kullanıcı Oluşturuldu");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int UserID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    await _context.User.Where(w => w.ID == UserID).ExecuteDeleteAsync();
                    return Ok();
                }
                catch (Exception)
                {

                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
