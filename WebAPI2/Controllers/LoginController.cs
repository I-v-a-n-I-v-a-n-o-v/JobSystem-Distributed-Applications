using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI2.Controllers
{
    public class LoginController : ApiController
    {
        private LoginManagementService loginService = new LoginManagementService();
        // POST: Login/Create
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Authentication(LoginDTO user)
        {
            if (user == null)
                return Json(new ResponseMessage { Code = 500, Error = "Login is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (loginService.Validate(user))
            {
                response.Code = 200;
                response.Body = "Login is successful.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Login failed.";
            }
            return Json(response);
        }
    }
}
