using DownloadManager.Service.Contract;
using System;
using System.Configuration;
using System.Web.Http;
using DownloadManager.Service.Models.Input;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DownloadManager.Web.Controllers
{
    public class UsersController : ApiController
    {
        #region Private fields

        private readonly IUserService _userService;

        #endregion

        #region ctor

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The register model containing the user's desired username and password.</param>
        /// <returns>A response indicating the success or failure of the registration.</returns>
        [HttpPost(), Route("api/users/register")]
        public IHttpActionResult Register([FromBody] UserCredentialsModel model)
        {
            try
            {
                _userService.RegisterUser(model);
                var token = GenerateJwtToken(model.Username);
                return Ok(new { Token = token });
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    return BadRequest(e.Message);
                }
                else if (e is InvalidOperationException)
                {
                    return Conflict();
                }
                else
                {
                    return InternalServerError(e);
                }
            }
        }

        /// <summary>
        /// Authenticate a user.
        /// </summary>
        /// <param name="model">The login model containing the user's username and password.</param>
        /// <returns>A response indicating the success or failure of the authentication.</returns>
        [HttpPost(), Route("api/users/login")]
        public IHttpActionResult CheckCredentials([FromBody] UserCredentialsModel model)
        {
            try
            {
                bool isCredentialsValid = _userService.CheckCredentials(model);

                if (isCredentialsValid)
                {
                    var token = GenerateJwtToken(model.Username);
                    return Ok(new { Token = token });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return InternalServerError(e);
                }
            }
        }

        #endregion

        #region Private methods

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["DownloadManager:Token"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("unique_name", username)
                    //new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}