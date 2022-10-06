using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using WebAPI.Messages;

namespace WebAPI2.Controllers
{
    public class RegisterController : ApiController
    {
        private RegisterManagementService registerService = new RegisterManagementService();


        [HttpPost]
        [Route("api/register")]
        public IHttpActionResult Authentication(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
                return Json(new ResponseMessage { Code = 500, Error = "Login is not valid!" });

            ResponseMessage response = new ResponseMessage();
            

            if (registerDTO.TypeOfUser == "0")
            {
                UserDTO userDTO = new UserDTO
                {
                    Email = registerDTO.Email,
                    Password = registerDTO.Password,
                    Username = registerDTO.Name
                };
                //userService.Save(registerDTO);

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
