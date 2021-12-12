using Shop.Database.Infrastructure;
using Shop.DTO.AccountDTOs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database.Repositories
{
    public interface IAccountRepository : IRepository<UserLoginDTO>
    {
        UserLoginDTO Login(UserLoginDTO user);
        string Register(User user);
        bool CheckUsernameExists(string username);
        bool CheckMobileNoExists(string mobileNo);
        bool CheckEmailExists(string email);
    }
    class AccountRepository : Repository<UserLoginDTO>, IAccountRepository
    {
        public AccountRepository(ShopDbContext context) : base(context)
        {
        }

        public bool CheckEmailExists(string email)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            if(user != null)
            {
                return true;
            }

            return false;
        }

        public bool CheckMobileNoExists(string mobileNo)
        {
            var user = _context.Users.Where(x => x.MobileNo == mobileNo).FirstOrDefault();

            if(user != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckUsernameExists(string username)
        {
            var user = _context.Users.Where(x => x.UserName == username).FirstOrDefault();

            if(user != null)
            {
                return true;
            }
            return false;
        }

        public UserLoginDTO Login(UserLoginDTO user)
        {
            var _user = _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

            UserLoginDTO userLogin = new UserLoginDTO
            {
                UserName = _user.UserName,
                Password = _user.Password
            };

            return userLogin;
        }

        public string Register(User user)
        {
            if (CheckUsernameExists(user.UserName))
            {
                return "UserName Already Exists!";
            }
            if (CheckMobileNoExists(user.MobileNo))
            {
                return "Mobile No Already Exists!";
            }
            if (CheckEmailExists(user.Email))
            {
                return "Email Already Exists!";
            }

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
            _context.Add(_user);
            _context.SaveChanges();

            return "Registered Successfully!";
        }
    }
}
