using Microsoft.AspNetCore.Mvc;
using auth_api.Model;
using auth_api.ViewModel;

namespace auth_api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentException();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userView)
        {
            var user = new User(userView.Id, userView.Email, userView.Enabled, userView.First_name,
                userView.Job_title, userView.Last_name, userView.Middle_name, userView.Password,
                userView.Telephone, userView.Username, userView.Profile_image_id,
                userView.Language_id, userView.Tenant_id, userView.Legacy_id, userView.Role,
                userView.First_access, userView.Calendar_view);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var users = _userRepository.Get();
            return Ok(users);
        }
    }
}
