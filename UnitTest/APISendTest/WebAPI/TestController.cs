using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data;
using Mirle.WebAPI.U2NMMA30.ReportInfo;

namespace APISendTest.WebAPI
{
    public class TestController : ApiController
    {
        public TestController()
        {
        }
        [Route("Test/EMPTY_SHELF_QUERY")]
        [HttpPost]
        public IHttpActionResult EMPTY_SHELF_QUERY([FromBody] EmptyShelfQuery_WCS Body)
        {
            EmptyShelfQuery_WMS response = new EmptyShelfQuery_WMS
            {
                carrierId = Body.carrierId,
                jobId = Body.jobId
            };

            response.shelfId = "0100101";
            response.returnCode = "200";
            return Json(response);
        }
    }
}
