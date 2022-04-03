﻿using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using EarthFront.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EarthFront.Controllers
{
    public class ActController : ApiCtrl
    {
        //[XgLogin]        
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new ActRead().GetPageAsync(Ctrl, dt));
        }

    }//class
}