using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shnaps.DAL.Entities;
using Shnaps.ViewModels;

namespace Shnaps.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EFContext _context;
        public UsersController(EFContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<UserItemViewModel> GetUsers()
        {
            Thread.Sleep(1000);
            var model = _context
               .Users
               .Select(u => new UserItemViewModel
               {
                   Id = u.Id,
                   Email = u.Email,
                   Roles = u.UserRoles.Select(r => new RoleItemViewModel
                   {
                       Id = r.Role.Id,
                       Name = r.Role.Name
                   })
               })
               .ToList();
            //    var model = new List<UserItemViewModel>
            //{
            //    new UserItemViewModel
            //    {
            //        Id=1, Email="jon@gg.ss",
            //        Roles = new List<RoleItemViewModel>
            //        {
            //            new RoleItemViewModel { Id=2, Name="Admin"}
            //        }
            //    },
            //    new UserItemViewModel
            //    {
            //        Id=2, Email="bombelyk@gg.ss",
            //        Roles = new List<RoleItemViewModel>
            //        {
            //            new RoleItemViewModel { Id=2, Name="Admin"},
            //            new RoleItemViewModel { Id=3, Name="Meson"}
            //        }
            //    }
            //};
            return model;
        }
    }
}