using ApplicationService.DTOs;
using Repository.Implementations;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrganisationManagementService
    {
        public List<OrganisationDTO> Get()
        {
            List<OrganisationDTO> organisationsDTO = new List<OrganisationDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.OrganisationRepository.Get())
                {

                    organisationsDTO.Add(new OrganisationDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Password = item.Password
                    });
                }
            }

            return organisationsDTO;
        }


        public OrganisationDTO GetById(int id)
        {
            OrganisationDTO organisationDTO = new OrganisationDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Organisation organisation = unitOfWork.OrganisationRepository.GetByID(id);

                if (organisation != null)
                {
                    organisationDTO = new OrganisationDTO
                    {
                        Id = organisation.Id,
                        Name = organisation.Name,
                        Email = organisation.Email,
                        Password = organisation.Password
                    };
                }

                return organisationDTO;
            }
        }

        public bool Save(OrganisationDTO organisationDTO)
        {
            Organisation organisation = new Organisation
            {
                Name = organisationDTO.Name,
                Email = organisationDTO.Email,
                Password = organisationDTO.Password
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrganisationRepository.Insert(organisation);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, OrganisationDTO organisationDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Organisation organisation = unitOfWork.OrganisationRepository.GetByID(id);
                if (organisation != null)
                {
                    organisation.Id = organisationDTO.Id;
                    organisation.Name = organisationDTO.Name;
                    organisation.Email = organisationDTO.Email;
                    organisation.Password = organisationDTO.Password;

                    unitOfWork.OrganisationRepository.Update(organisation);
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
                    unitOfWork.OrganisationRepository.Delete(id);
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

