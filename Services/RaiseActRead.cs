using Base.Enums;
using Base.Models;
using Base.Services;
using EarthFront.Models;
using Newtonsoft.Json.Linq;

namespace EarthFront.Services
{
    public class RaiseActRead
    {
        private readonly ReadDto readDto = new()
        {
            ReadSql = @"
select a.*, u.Name as CreatorName 
from dbo.Act a
join dbo.UserFront u on a.Creator=u.Id
order by a.Sn
",
            TableAs = "a",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like2 },
            },
        };

        public async Task<PageOut<ActRowDto>> GetPageAsync(int pageNo, int pageRows, int filterRows, string act, Db db)
        {
            pageRows = _Page.GetPageRows(pageRows);
            return await new CrudRead(db).GetPage2Async<ActRowDto>(readDto,
                _Page.GetPageIn(pageNo, pageRows, filterRows, new List<object>() { "Name", act }));
        }

    } //class
}