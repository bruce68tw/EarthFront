using Base.Enums;
using Base.Models;
using Base.Services;
using EarthFront.Models;

namespace EarthFront.Services
{
    public class ActRead
    {
        private readonly ReadDto readDto = new()
        {
            ReadSql = @"
select a.*, u.Name as CreatorName 
from dbo.Act a
join dbo.UserFront u on a.Creator=u.Id
order by a.Id
",
            TableAs = "a",
            Items = new QitemDto[] {
                new() { Fid = "Name", Op = ItemOpEstr.Like2 },
            },
        };

        public async Task<PageOut<ActRowDto>> GetPageAsync(int pageNo, int pageRows, int filterRows, string act)
        {
            return await new CrudRead().GetEasyPageAsync<ActRowDto>(readDto, 
                _Page.GetPageIn(pageNo, pageRows, filterRows, new List<object>() { "Name", act }));
        }

    } //class
}