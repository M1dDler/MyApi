using System.Collections.Generic;
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
    public class GroupsController : ControllerBase
    {
        private readonly MyApiDbContext _context;

        public GroupsController(MyApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var GroupWithUsers = _context.Groups.AsNoTracking()
                .Select(group => new GroupGetDTO
                {
                    Id = group.Id,
                    Name = group.Name,
                    Users = group.User.Select(g => g.Id).ToList()
                }).ToList();

            return Ok(GroupWithUsers);
        }

        [HttpGet("{id}")]
        public async Task<Group> GetGroup(int id)
        {
            return await _context.Groups.AsNoTracking().SingleAsync(Group => Group.Id == id);
        }

        [HttpPost]
        public async Task<string> PostGroup(GroupPostDTO groupdto)
        {
            var Group = new Group { Name = groupdto.Name };
            if (Group.Name == "")
            {
                return "Error creating group!";
            }

            if (groupdto.UserId != null && Group.Name != "")
            {
                var users = _context.Users.Where(user => groupdto.UserId.Contains(user.Id));
                Group.User = await users.ToListAsync();
            }

            await _context.Groups.AddAsync(Group);
            await _context.SaveChangesAsync();
            return $"Group {Group.Name} created. Group ID: {Group.Id}";
        }

        [HttpDelete]
        public async Task<string> DeleteGroup(int id)
        {
            var group = _context.Groups.Where(x => x.Id == id).SingleOrDefault();
            if (group == null) return "Group not found!";

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return "Group has successfully deleted!";
        }

    }
}
