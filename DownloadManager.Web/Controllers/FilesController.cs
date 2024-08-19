using System;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Input;
using DownloadManager.Web.Filter;
using DownloadManager.Web.Models;

namespace DownloadManager.Web.Controllers
{
    [JwtAuthentication]
    public class FilesController : ApiController
    {
        #region Private fields

        private readonly IFileService _fileService;
        private readonly IUserService _userService;

        #endregion

        #region ctor

        public FilesController(IFileService fileService, IUserService userService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="model">A JSON model containing the information about the download.</param>
        [HttpPost(), Route("api/files/download")]
        public IHttpActionResult Download([FromBody] DownloadModel model)
        {
            try
            {
                var userName = Thread.CurrentPrincipal.Identity.Name;

                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new InvalidOperationException("No Username found.");
                }

                var userId = _userService.GetUserIdByUsername(userName);

                var serviceModel = new FileDownloadModel()
                {
                    FileName = model.FileName,
                    FileDownloadDirectory = model.FileDownloadDirectory,
                    FileDownloadMethod = model.FileDownloadMethod,
                    Url = model.Url,
                    UserId = userId
                };

                _fileService.DownloadFile(serviceModel);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return InternalServerError(ex);
                }
            }

            return Ok();
        }

        /// <summary>
        /// Gets filtered report about downloaded files.
        /// </summary>
        /// <param name="model">The filter data.</param>
        /// <returns>A JSON object representing the report model.</returns>
        [HttpGet(), Route("api/files"), ResponseType(typeof(IFileReportsPageModel))]
        public IHttpActionResult GetReport([FromUri] FileFilterModel model)
        {
            IFileReportsPageModel result;

            try
            {
                result = _fileService.GetFiltered(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion
    }
}