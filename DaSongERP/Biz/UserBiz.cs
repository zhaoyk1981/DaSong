﻿using DaSongERP.Conditions;
using DaSongERP.Dal;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

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

        //public IList<UserModel> GetUserList(string search, bool fillPermissionsText = false)
        //{
        //    var s = (search ?? string.Empty).Trim();
        //    s = string.IsNullOrWhiteSpace(s) ? default(string) : s;
        //    var list = this.UserDao.GetUserList(s);
        //    if (fillPermissionsText)
        //    {
        //        var plist = this.GetAllPermissions();
        //        foreach (var u in list)
        //        {
        //            this.SetPermissionDisplayText(plist, u);
        //        }
        //    }

        //    return list;
        //}

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

        public int Create(UserModel user)
        {
            user.ID = Guid.NewGuid();
            var cu = this.GetUserBy(user.UserName);
            if (cu != null)
            {
                return 2;
            }

            var rowCount = this.UserDao.Create(user);
            return rowCount;
        }

        public int Update(UserModel user)
        {
            user.Password = string.IsNullOrEmpty(user.Password) ? default(string) : user.Password;
            var cu = this.GetUserBy(user.UserName, user.ID);
            if (cu != null)
            {
                return 2;
            }

            var rowCount = this.UserDao.Update(user);
            return rowCount;
        }

        public EditUserViewModel GetNewUserViewModel()
        {
            var vm = new EditUserViewModel();
            vm.PermissionDataSource = this.GetAllPermissions();
            return vm;
        }

        public EditUserViewModel GetEditUserViewModel(Guid id)
        {
            var vm = new EditUserViewModel();
            vm.PermissionDataSource = this.GetAllPermissions();
            vm.User = GetUserBy(id);
            return vm;
        }

        public PagedList<UserModel> GetUserList(UserCondition condition)
        {
            var list = this.UserDao.GetUserList(condition);
            var plist = this.GetAllPermissions();
            foreach (var u in list.DataSource)
            {
                this.SetPermissionDisplayText(plist, u);
            }

            return list;
        }

        public UserListViewModel GetUserListViewModel()
        {
            var vm = new UserListViewModel();
            vm.Users = new PagedList<UserModel>();
            vm.Users.PageSize = 300;
            return vm;
        }
    }
}
