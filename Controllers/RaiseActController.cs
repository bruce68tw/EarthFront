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
    public class RaiseActController : ApiCtrl
    {
        public async Task<ActionResult> Read(int page = 1, int rows = 0, int filter = -1, string name = "")
        {
            ViewBag.Name = name;
            await using var db = new Db();
            ViewBag.Donates = await _XpCode.GetDonatesAsync(db);
            var dto = await new RaiseActRead().GetPageAsync(page, rows, filter, name, db);
            return View(dto);
        }

        private RaiseActEdit EditService()
        {
            return new RaiseActEdit(Ctrl);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonAsync(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateAsync(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateAsync(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteAsync(key));
        }

        public async Task<FileResult> ViewFile(string table, string fid, string key, string ext)
        {
            return await _Xp.ViewActAsync(key, ext);
        }
    }//class
}