using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class JobManagementService
    {
        public List<JobDTO> Get()
        {
            List<JobDTO> jobsDTO = new List<JobDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.JobRepository.Get())
                {

                    jobsDTO.Add(new JobDTO
                    {
                        Id = item.Id,
                        Publisher = item.Publisher,
                        Description = item.Description,
                        Title = item.Title,
                        PublishedOn = item.PublishedOn,
                        Category = item.Category,
                        Type = item.Type,
                        Candidates = item.Candidates,
                        OrganisationId = item.OrganisationId
                    });
                }
            }
            return jobsDTO;


            //JobDTO jobDTO = new JobDTO();

            //jobDTO.Id = item.Id;
            //jobDTO.JobPublisher = item.JobPublisher;
            //jobDTO.Description = item.Description;
            //jobDTO.Title = item.Title;
            //jobDTO.Category = item.Category;
            //jobDTO.JobType = item.JobType;
            //if (item.Candidates != null)
            //{
            //    jobDTO.Candidates = item.Candidates;
            //}

            //jobsDTO.Add(jobDTO);
        }


        public JobDTO GetById(int id)
        {
            JobDTO jobDTO = new JobDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Job job = unitOfWork.JobRepository.GetByID(id);

                if (job != null)
                {
                    jobDTO = new JobDTO
                    {
                        Id = job.Id,
                        Publisher = job.Publisher,
                        Description = job.Description,
                        Title = job.Title,
                        PublishedOn = job.PublishedOn,
                        Category = job.Category,
                        Type = job.Type,
                        Candidates = job.Candidates,
                        OrganisationId = job.OrganisationId
                    };
                }


                return jobDTO;
            }
        }

        public bool Save(JobDTO jobDTO)
        {
            Job job = new Job
            {
                Description = jobDTO.Description,
                Publisher = jobDTO.Publisher,
                PublishedOn = jobDTO.PublishedOn,
                Category = jobDTO.Category,
                Title = jobDTO.Title,
                Type = jobDTO.Type,
                Candidates = new List<int>
                {
                    1,2, 3, 4, 5, 6, 7
                },
                OrganisationId =jobDTO.OrganisationId
                //new Organisation
                //{
                //    Id = jobDTO.OrganisationId.Id,
                //    Name = jobDTO.OrganisationId.Name,
                //    Email = jobDTO.OrganisationId.Email
                //}
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.JobRepository.Insert(job);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, JobDTO jobDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Job job = unitOfWork.JobRepository.GetByID(id);
                if (job != null)
                {
                    job.Id = jobDTO.Id;
                    job.Title = jobDTO.Title;
                    job.Description = jobDTO.Description;
                    job.Publisher = jobDTO.Publisher;
                    job.PublishedOn = jobDTO.PublishedOn;
                    job.Category = jobDTO.Category;
                    job.OrganisationId = jobDTO.OrganisationId; 
                    job.Candidates = jobDTO.Candidates; 
                    //{
                    //    Id = jobDTO.OrganisationId.Id,
                    //    Name = jobDTO.OrganisationId.Name,
                    //    Email = jobDTO.OrganisationId.Email,
                    //};

                    unitOfWork.JobRepository.Update(job);
                    unitOfWork.Save();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.JobRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
