using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using EarthFront.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EarthFront.Controllers
{
    public class ForumController : ApiCtrl
    {
        //[XgLogin]        
        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new ForumRead().GetPageAsync(Ctrl, dt));
        }

        private ForumEdit EditService()
        {
            return new ForumEdit(Ctrl);
        }

        [Authorize]
        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            //return JsonToCnt(await EditService().GetUpdJsonAsync(key));
            return null;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            //return Json(await EditService().CreateAsync(_Str.ToJson(json)));
            return null;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            //return Json(await EditService().UpdateAsync(key, _Str.ToJson(json)));
            return null;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            //return Json(await EditService().DeleteAsync(key));
            return null;
        }

    }//class
}