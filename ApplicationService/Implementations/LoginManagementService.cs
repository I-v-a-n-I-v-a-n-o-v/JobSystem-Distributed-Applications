using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System.Linq;


namespace ApplicationService.Implementations
{
    public class LoginManagementService
    {
        private bool IsValid(LoginDTO loginDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (int.Parse(loginDTO.TypeOfUser) == 0)
                {
                    var users = unitOfWork.UserRepository.Get();
                    User loggedUser = users.Where(u => u.Password == loginDTO.Password && u.Email == loginDTO.Email).ToList().FirstOrDefault();
                    if (loggedUser != null)
                    {
                        //HttpContext.Session.SetObject("loggedUser", loggedUser);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (int.Parse(loginDTO.TypeOfUser) == 1)
                {
                    var users = unitOfWork.OrganisationRepository.Get();
                    Organisation loggedUser = users.Where(u => u.Password == loginDTO.Password && u.Email == loginDTO.Email).ToList().FirstOrDefault();
                    if (loggedUser != null)
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
            }
        }
        public bool Validate(LoginDTO loginDTO)
        {
            return IsValid(loginDTO);
        }
    }
}
