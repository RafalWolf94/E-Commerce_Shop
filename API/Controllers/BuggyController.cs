using API.Error;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext Context;

        public BuggyController(StoreContext context)
        {
            Context = context;
        }
        
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequesty()
        {
            var thing = Context.Products.Find(42);
            if (thing is null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError
            ()
        {
            var thing = Context.Products.Find(42);
            var thingToReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequesty(int id)
        {
            return Ok();
        }
        
        
    }
}