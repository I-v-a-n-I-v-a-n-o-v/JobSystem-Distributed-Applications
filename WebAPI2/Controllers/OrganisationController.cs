using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI2.Controllers
{
    public class OrganisationController : ApiController
    {

        private OrganisationManagementService organisationService = new OrganisationManagementService();


        [HttpGet]
        [Route("api/organisation")]
        public IHttpActionResult Get()
        {
            return Json(organisationService.Get());
        }


        [HttpGet]
        [Route("api/organisation/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(organisationService.GetById(id));
        }


        [HttpPost]
        [Route("api/organisation")]
        public IHttpActionResult Save(OrganisationDTO organisationDto)
        {
            if (organisationDto == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (organisationService.Save(organisationDto))
            {
                response.Code = 200;
                response.Body = "Organisation is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Organisation is not saved.";
            }

            return Json(response);
        }

        [HttpPut]
        [Route("api/organisation/{id}")]
        public IHttpActionResult Update(int id, OrganisationDTO organisationDTO)
        {
            if (organisationDTO == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (organisationService.Update(id, organisationDTO))
            {
                response.Code = 200;
                response.Body = "Organisation is updated.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Organisation is not updated.";
            }

            return Json(response);
        }


        [HttpDelete]
        [Route("api/organisation/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (organisationService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Organisation is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Organisation is not deleted.";
            }

            return Json(response);
        }
    }
}
