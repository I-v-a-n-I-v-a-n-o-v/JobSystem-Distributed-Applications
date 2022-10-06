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
    public class RegisterManagementService
    {
        private bool IsValid(RegisterDTO registerDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                if (int.Parse(registerDTO.TypeOfUser) == 0)
                {
                    var users = unitOfWork.UserRepository.Get();
                    string registerUserEmail = users.Where(u => u.Email == registerDTO.Email).ToList().FirstOrDefault().Email;
                    if (registerUserEmail == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (int.Parse(registerDTO.TypeOfUser) == 1)
                {
                    var users = unitOfWork.OrganisationRepository.Get();
                    string registerUserEmail = users.Where(u => u.Email == registerDTO.Email).ToList().FirstOrDefault().Email;
                    if (registerUserEmail == null)
                    {
                        //HttpContext.Session.SetObject("loggedUser", loggedUser);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //if (unitOfWork.UserRepository.Contains(loginDTO.Email) != null && unitOfWork.UserRepository.Contains(loginDTO.Password) != null)
                //{
                //    User loggedUser = unitOfWork.UserRepository.GetByID(unitOfWork.UserRepository.Contains(loginDTO.Email).Id);

                //    //HttpContext.Session.SetObject("loggedUser", loggedUser);

                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }
    }
}
