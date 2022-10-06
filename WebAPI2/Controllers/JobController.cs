using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI2.Controllers
{
    public class JobController : ApiController
    {

        private JobManagementService jobService = new JobManagementService();


        [HttpGet]
        [Route("api/job")]
        public IHttpActionResult Get()
        {
            return Json(jobService.Get());
        }


        [HttpGet]
        [Route("api/job/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(jobService.GetById(id));
        }


        [HttpPost]
        [Route("api/job")]
        public IHttpActionResult Save(JobDTO jobDto)
        {
            if (jobDto == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (jobService.Save(jobDto))
            {
                response.Code = 200;
                response.Body = "Job is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Job is not saved.";
            }

            return Json(response);
        }

        [HttpPut]
        [Route("api/job/{id}")]
        public IHttpActionResult Update(int id, JobDTO jobDTO)
        {

            if (jobDTO == null)
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });

            ResponseMessage response = new ResponseMessage();

            if (jobService.Update(id, jobDTO))
            {
                response.Code = 200;
                response.Body = "Job is updated.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Job is not updated.";
            }

            return Json(response);
        }


        //[HttpDelete]
        //[Route("api/job/{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    ResponseMessage response = new ResponseMessage();

        //    if (jobService.Delete(id))
        //    {
        //        response.Code = 200;
        //        response.Body = "Organisation is deleted.";
        //    }
        //    else
        //    {
        //        response.Code = 500;
        //        response.Body = "Organisation is not deleted.";
        //    }

        //    return Json(response);
        //}
        [HttpDelete]
        [Route("api/job/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (jobService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Job is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Job is not deleted.";
            }

            return Json(response);
        }
    }
}
