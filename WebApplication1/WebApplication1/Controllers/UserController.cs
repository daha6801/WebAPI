using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> Get()
        {
            List<User> usersList = new List<User>();

            try
            {
                usersList = _context.Users.ToList();
            }
            catch
            {
                return null; // An error occured
            }

            return usersList;
        }

        [HttpGet("{id:Guid}")]
        public User Get(Guid id)
        {
            User usr = new User();

            try
            {
                usr = _context.Users.First(a => a.Id == id);
            }
            catch
            {
                return null; // An error occured
            }

            return usr;
        }

        [HttpPost]
        public string Post([FromForm] User usr)
        {
            try
            {
                _context.Users.Add(usr);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }

            return "User added Successfully";
        }

        [HttpPut]
        public string Put([FromForm] User usr)
        {
            try
            {
                User user = _context.Users.Find(usr.Id);

                if (user == null)
                {
                    return "User not found in the database.Please make sure to pass the correct Id.";
                }
                else 
                {

                    // Make changes on entity
                    user.FirstName = usr.FirstName;
                    user.LastName = usr.LastName;
                    user.Email = usr.Email;
                    user.Phone = usr.Phone;
                    user.IsAdmin = usr.IsAdmin;
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }

            return "User Updated Successfully";
        }

        [HttpDelete("{id:Guid}")]
        public string Delete(Guid id)
        {
            User usr = new User();

            try
            {
                usr = _context.Users.First(a => a.Id == id);

                _context.Remove(usr);
                _context.SaveChanges();
            }
            catch
            {
                return null; // An error occured
            }

            return "User deleted successfully";
        }
    }
}
