using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;

namespace EarthFront.Services
{
    public class MyRaiseActRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = $@"
select a.*, u.Name as CreatorName 
from dbo.Act a
join dbo.UserFront u on a.Creator=u.Id
where a.Creator='{_Fun.UserId()}'
order by a.Id
",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like2 },
            },
        };

        public async Task<JObject> GetPageAsync(string ctrl, DtDto dt)
        {
            return await new CrudRead().GetPageAsync(dto, dt, ctrl);
        }

    } //class
}