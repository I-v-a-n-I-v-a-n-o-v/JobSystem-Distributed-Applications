using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI2.Controllers
{
    public class UserController : ApiController
    {

        private UserManagementService userService = new UserManagementService();


        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        {
            return Json(userService.Get());
        }


        [HttpGet]
        [Route("api/user/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(userService.GetById(id));
        }


        [HttpPost]
        [Route("api/user")]
        public IHttpActionResult Save(UserDTO userDto)
        {
            if (userDto == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (userService.Save(userDto))
            {
                response.Code = 200;
                response.Body = "User is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "User is not saved.";
            }

            return Json(response);
        }

        [HttpPut]
        [Route("api/user/{id}")]
        public IHttpActionResult Update(int id, UserDTO userDTO)
        {

            if (userDTO == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (userService.Update(id, userDTO))
            {
                response.Code = 200;
                response.Body = "User is updated.";
            }
            else
            {
                response.Code = 500;
                response.Body = "User is not updated.";
            }

            return Json(response);
        }


        [HttpDelete]
        [Route("api/user/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (userService.Delete(id))
            {
                response.Code = 200;
                response.Body = "User is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "User is not deleted.";
            }

            return Json(response);
        }
    }
}
