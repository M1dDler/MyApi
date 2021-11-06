using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Domain;
using MyApi.DTO;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyApiDbContext _context;

        public UsersController(MyApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var UsersWithGroups = _context.Users.AsNoTracking()
                .Select(user => new UserGetDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Groups = user.Groups.Select(group => group.Id).ToList()
                }).ToList();

            return Ok(UsersWithGroups);
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUser(UserPostDTO userpostdto)
        {
            var User = new User { Name = userpostdto.Name };
            if (User.Name == "")
            {
                return "Error creating user!";
            }

            if (userpostdto.GroupsId != null)
            {
                var groups = _context.Groups.Where(group => userpostdto.GroupsId.Contains(group.Id));
                User.Groups = await groups.ToListAsync();
            }

            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            return $"User {User.Name} created. User ID: {User.Id}";
        }

        [HttpDelete]
        public async Task<string> DeleteUser(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null) return "User not found!";

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return "User has successfully deleted!";
        }

    }
}
