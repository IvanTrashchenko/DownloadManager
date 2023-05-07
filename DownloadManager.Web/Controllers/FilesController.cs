using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Input;

namespace DownloadManager.Web.Controllers
{
    public class FilesController : ApiController
    {
        #region Private fields

        private readonly IFileService _fileService;

        #endregion

        #region ctor

        public FilesController(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="model">A JSON model containing the information about the download.</param>
        [HttpPost(), Route("api/files/download")]
        public IHttpActionResult Download([FromBody] FileDownloadModel model)
        {
            try
            {
                _fileService.DownloadFile(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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