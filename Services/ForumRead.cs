using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace EarthFront.Services
{
    public class ForumRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select f.*, CreatorName = u.Name  
from dbo.Forum f
join dbo.[User] u on f.Creator = u.Id
order by f.Id
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