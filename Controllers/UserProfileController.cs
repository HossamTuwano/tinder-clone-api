using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileAPI.Models;
using UserProfileAPI.Data;

namespace UserProfileAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserProfileController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(UserProfile user)
        {
            if(user.Id == 0)
            {
                _context.User.Add(user);
            } else
            {
                var userInDb = _context.user.Find(user.Id);

                if (userInDb == null)
                    return new JsonResult(NotFound());

                userInDb = user;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(user));

        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.user.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        
 
       
    }
}

