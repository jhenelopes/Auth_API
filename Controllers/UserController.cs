using auth_api.Model;
using auth_api.Token;
using auth_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;  // Injeção de dependência do TokenService

        // Injetando os serviços no construtor
        public UserController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userView)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userView.Password);
            var user = new User(userView.Id, userView.Email, userView.Enabled, userView.First_name,
                userView.Job_title, userView.Last_name, userView.Middle_name, hashedPassword,
                userView.Telephone, userView.Username, userView.Profile_image_id,
                userView.Language_id, userView.Tenant_id, userView.Legacy_id, userView.Role,
                userView.First_access, userView.Calendar_view);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult Get() 
        {
            var users = _userRepository.Get();
            return Ok(users);
        }
        [HttpGet("login")]
        public IActionResult Get(string usuario, string senha)
        {
            // Gets all the users in the repository
            var users = _userRepository.Get();

            // Checks if there is a user with the given username
            var userExistente = users.FirstOrDefault(u => u.username == usuario);

            if (userExistente != null)
            {
                // Checks that the password provided matches the hash of the stored password
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(senha, userExistente.password);

                if (isPasswordValid)
                {
                    var accessToken = _tokenService.Generate(userExistente);
                    var refreshToken = _tokenService.GenerateRefreshToken(userExistente);

                    // Returns the generated token
                    return Ok(new
                    {
                        message = "User found",
                        access_token = accessToken,
                        refresh_token = refreshToken
                    });
                }
                else
                {
                    return Unauthorized(new { message = "Incorrect password" });
                }
            }
            else
            {
                return Unauthorized(new { message = "User not found" });
            }
        }

    }
}
