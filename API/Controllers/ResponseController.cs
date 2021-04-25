using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using API.Errors;

namespace API.Controllers
{
    public class ResponseController : BaseController
    {
        private readonly StoreContext _context;
        
        public ResponseController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var entity = _context.Products.Find(42);
            if (entity == null)
                return NotFound(new ErrorResponse(404));
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var entity = _context.Products.Find(42);
            var entityReturn = entity.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ErrorResponse(400));
        }

        [HttpGet("basrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }                        
    }
}