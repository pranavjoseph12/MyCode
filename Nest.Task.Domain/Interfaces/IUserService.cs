﻿using Nest.Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Task.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserView> GetUserDetails(int userId);
    }
}
