using Base.Models;
using Base.Services;

namespace EarthFront.Services
{
    public class RaiseActEdit : XgEdit
    {
        public RaiseActEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
                Table = "dbo.Act",
                PkeyFid = "Id",
                Col4 = new string[] { "Creator", "Created" },
                ReadSql = @"
select a.*, u.Name as CreatorName 
from dbo.Act a
join dbo.UserFront u on a.Creator=u.Id
where a.Id='{0}'
",
                Items = new EitemDto[]
                {
                    new() { Fid = "Id" },
                    new() { Fid = "Name" },
                    new() { Fid = "DonateId" },
                    new() { Fid = "Status" },
                },
            };
        }

    } //class
}
