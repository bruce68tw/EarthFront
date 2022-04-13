using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseWeb.Attributes;
using EarthFront.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EarthFront.Controllers
{
    [XgLogin]        
    public class MyRaiseActController : ApiCtrl
    {
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new MyRaiseActRead().GetPageAsync(Ctrl, dt));
        }

    }//class
}