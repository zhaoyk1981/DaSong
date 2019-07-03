using Dal;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Biz
{
    public class UserBiz : Biz
    {
        protected UserDao UserDao { get; set; } = new UserDao();

        public UserModel ValidateUser(UserModel user)
        {
            var u = this.UserDao.GetUserBy(user.UserName.Trim());
            if (u == null)
            {
                return null;
            }

            if (u.Password != user.Password)
            {
                return null;
            }

            return u;
        }

        public UserModel GetUserBy(Guid id)
        {
            return this.UserDao.GetUserBy(id);
        }

        public SignInViewModel GetSignInViewModel()
        {
            return new SignInViewModel();
        }
    }
}
