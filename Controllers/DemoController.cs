using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MsOwinDemo.Controllers {

    [RoutePrefix("api/demo")]
    public class DemoController : ApiController {

        private static IList<DemoModel> models = new List<DemoModel> {
            new DemoModel {
                Id = DateTime.Now.Ticks,
                Message = "Hello, world!"
            }
        };

        [HttpGet, Route("")]
        public IHttpActionResult GetAll() {
            return Ok(models);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Save(DemoModel model) {
            model.Id = DateTime.Now.Ticks;
            models.Insert(0, model);
            return Ok(model);
        }

    }

    public class DemoModel {
        public long Id { get; set; }
        public string Message { get; set; }
    }

}
