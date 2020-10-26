﻿using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IUserService
    {
        //TODO: Change all the User domain models with appropriate ViewModel!!!

        void Register(User registerModel);
        void Login(User loginModel);
        void Logout();
        UserViewModel GetCurrentUser(string username);
    }
}
