using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Output;
using DownloadManager.Service.Models.Input;
using DownloadManager.Web.Filter;
using DownloadManager.Web.Logging;
using DownloadManager.Web.Models;
using Serilog;

namespace DownloadManager.Web.Controllers
{
    [JwtAuthentication]
    public class LogsController : ApiController
    {
        #region Private fields

        private readonly InMemoryLogger _logger;

        #endregion

        #region ctor

        public LogsController(InMemoryLogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public methods

        [HttpGet(), Route("api/logs")]
        public IHttpActionResult GetLogs()
        {
            try
            {
                var logs = _logger.GetLogs();
                return Ok(logs);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return InternalServerError(e);
            }
        }

        [HttpDelete(), Route("api/logs")]
        public IHttpActionResult Clear()
        {
            try
            {
                _logger.Clear();
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return InternalServerError(e);
            }
        }

        #endregion
    }
}