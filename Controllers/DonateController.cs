using BaseApi.Controllers;
using EarthFront.Services;
using Microsoft.AspNetCore.Mvc;

namespace EarthFront.Controllers
{
    public class DonateController : ApiCtrl
    {
        public ActionResult Create()
        {
            return View();
        }

    }//class
}