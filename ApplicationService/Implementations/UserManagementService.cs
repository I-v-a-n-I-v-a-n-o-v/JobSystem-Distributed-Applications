using System;
using System.Collections.Generic;
using ApplicationService.DTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementations;
using Data.Entities;

namespace ApplicationService.Implementations
{
    public class UserManagementService
    {
        public List<UserDTO> Get()
        {
            List<UserDTO> usersDTO = new List<UserDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get())
                {

                    usersDTO.Add(new UserDTO
                    {
                        Id = item.Id,
                        Email = item.Email,
                        Username = item.Username,
                        Password = item.Password,
                        JobsList = item.JobsList
                    });
                }
            }

            return usersDTO;
        }


        public UserDTO GetById(int id)
        {
            UserDTO userDTO = new UserDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);

                if (user != null)
                {
                    userDTO = new UserDTO
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        Password = user.Password,
                        JobsList = user.JobsList
                    };
                }

                return userDTO;
            }
        }

        public bool Save(UserDTO userDTO)
        {
            User user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                JobsList = userDTO.JobsList
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Insert(user);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, UserDTO userDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {
                    user.Id = userDTO.Id;
                    user.Username = userDTO.Username;
                    user.Email = userDTO.Email;
                    user.Password = userDTO.Password;
                    user.JobsList = userDTO.JobsList;

                    unitOfWork.UserRepository.Update(user);
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
                    unitOfWork.UserRepository.Delete(id);
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

