﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterationForm.Models;
using System;
using System.Threading.Tasks;

namespace RegisterationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser  =  new ApplicationUser { UserName = model.UserName, Email = model.Email ,FullName = model.FullName  };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser , model.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("/Test")]
        public String GetName()
        {
            return "My Name is Hamza";
        }
    }
}
