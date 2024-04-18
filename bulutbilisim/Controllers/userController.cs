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

        /
        [HttpGet("GetLogin")]
        public async Task<IActionResult> GetLogin(string username, string password)
        {
            List<User_Tb> personel = await _context.User.Where(w => w.userName == username && w.pass == password).ToListAsync();

            if (personel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personel);
            }
        }
        /*
        [HttpPost("CreatePersonel")]
        public async Task<IActionResult> CreateUser(string name, string username, string password, string role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                personel_tb newUser = new personel_tb
                {
                    personelAd = name,
                    personelKullaniciAdi = username,
                    personelSifre = password,
                    personelRol = role
                };

                await _context.personel.AddAsync(newUser);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return CreatedAtAction(nameof(GetPersonelByID), new { id = newUser.personelID }, newUser);
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

        [HttpPost("UpdatePersonel")]
        public async Task<IActionResult> UpdatePersonel(int personelID, string? name, string? username, string? password, string? role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                personel_tb User = await _context.personel.Where(w => w.personelID == personelID).FirstOrDefaultAsync();
                {
                    if (User == null) { return NotFound(); }
                    else
                    {
                        if (name != null) { User.personelAd = name; }
                        if (username != null) { User.personelKullaniciAdi = username; }
                        if (password != null) { User.personelSifre = password; }
                        if (role != null) { User.personelRol = role; }
                    }
                };


                if (await _context.SaveChangesAsync() > 0)
                {
                    return CreatedAtAction(nameof(GetPersonelByID), new { id = User.personelID }, User);
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

        [HttpPost("DeletePersonel")]
        public async Task<IActionResult> DeletePersonel(int personelID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    await _context.personel.Where(w => w.personelID == personelID).ExecuteDeleteAsync();
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
        }*/
    }
}
