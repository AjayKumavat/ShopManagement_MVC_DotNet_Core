using Shop.Database.Repositories;
using Shop.DTO.AccountDTOs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface IAccountService
    {
        bool Login(UserLoginDTO user);
        User AddUser(User user);
        string Register(User user);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public User AddUser(User user)
        {
            User _user = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                MobileNo = user.MobileNo,
                Email = user.Email,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedBy = 0,
                IsActive = true
            };
            _accountRepository.Add(user);
            return user;
        }

        public bool Login(UserLoginDTO user)
        {
            if(_accountRepository.VerifyCredentials(user))
            {
                return true;
            }
            return false;
        }

        public string Register(User user)
        {
            if (_accountRepository.CheckUsernameExists(user.UserName))
            {
                return "UserName Already Exists!";
            }
            if (_accountRepository.CheckMobileNoExists(user.MobileNo))
            {
                return "Mobile No Already Exists!";
            }
            if (_accountRepository.CheckEmailExists(user.Email))
            {
                return "Email Already Exists!";
            }

            AddUser(user);

            return "Registered Successfully!";
        }
    }
}
