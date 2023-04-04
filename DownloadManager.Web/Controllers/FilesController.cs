using System;using System.Web.Http;
using System.Web.Http.Description;
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

        [HttpPost(), Route("api/files/download")]
        public IHttpActionResult Download([FromBody] FileDownloadModel model)
        {
            _fileService.DownloadFile(model);
            return Ok();
        }

        [HttpGet(), Route("api/files"), ResponseType(typeof(IFileReportsPageModel))]
        public IHttpActionResult Get([FromBody] FileFilterModel model)
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