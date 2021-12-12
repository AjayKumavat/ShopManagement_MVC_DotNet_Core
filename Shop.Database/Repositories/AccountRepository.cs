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
    public interface IAccountRepository : IRepository<User>
    {
        bool VerifyCredentials(UserLoginDTO user);
        bool CheckUsernameExists(string username);
        bool CheckMobileNoExists(string mobileNo);
        bool CheckEmailExists(string email);
    }
    public class AccountRepository : Repository<User>, IAccountRepository
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

        public bool VerifyCredentials(UserLoginDTO user)
        {
            var _user = _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

            if(_user != null)
            {
                return true;
            }
            return false;
        }
    }
}
