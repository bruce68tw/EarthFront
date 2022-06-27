using BaseApi.Controllers;
using EarthFront.Services;
using Microsoft.AspNetCore.Mvc;

namespace EarthFront.Controllers
{
    public class ActController : ApiCtrl
    {
        public async Task<ActionResult> Read(int page = 1, int rows = 0, int filter = -1, string name = "")
        {
            ViewBag.Name = name;
            var dto = await new ActRead().GetPageAsync(page, rows, filter, name);
            return View(dto);
        }

        //傳回活動圖檔
        public async Task<FileResult> Image(string key, string ext)
        {
            return await _Xp.ViewActAsync(key, ext);
        }

    }//class
}