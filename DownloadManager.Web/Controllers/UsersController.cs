﻿using DownloadManager.Service.Contract;
using System;
using System.Web.Http;
using DownloadManager.Service.Models.Input;
using System.Net;

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
                return Ok();
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
                    return Ok();
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
    }
}