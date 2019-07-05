using DaSongERP.Dal;
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


        public UserModel ValidateUser(UserModel user)
        {
            var u = this.GetUserBy(user.UserName.Trim());
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

        public UserModel GetUserBy(string userName, Guid? id = null)
        {
            return this.UserDao.GetUserBy(userName, id);
        }

        public UserModel GetUserBy(Guid id)
        {
            return this.UserDao.GetUserBy(id);
        }

        public SignInViewModel GetSignInViewModel()
        {
            return new SignInViewModel();
        }

        public UserListViewModel GetUserListViewModel(string search = null)
        {
            var vm = new UserListViewModel();
            vm.Users = this.GetUserList(search, true);
            vm.Search = (search ?? string.Empty).Trim();
            return vm;
        }

        public IList<UserModel> GetUserList(string search, bool fillPermissionsText = false)
        {
            var s = (search ?? string.Empty).Trim();
            s = string.IsNullOrWhiteSpace(s) ? default(string) : s;
            var list = this.UserDao.GetUserList(s);
            if (fillPermissionsText)
            {
                var plist = this.GetAllPermissions();
                foreach (var u in list)
                {
                    this.SetPermissionDisplayText(plist, u);
                }
            }

            return list;
        }

        public int RemoveUser(Guid id)
        {
            var rowCount = this.UserDao.RemoveUser(id);
            return rowCount;
        }

        public IList<PermissionModel> GetAllPermissions()
        {
            var list = this.UserDao.GetAllPermissions();
            return list;
        }

        public void SetPermissionDisplayText(IList<PermissionModel> permissions, UserModel user)
        {
            var up = permissions
                .Where(m => (user.PermissionID.Value & m.ID.Value) == m.ID.Value)
                .Select(m => m.Name)
                .ToList();
            user.权限 = string.Join(", ", up);
        }
    }
}
