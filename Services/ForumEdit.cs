using Base.Models;
using Base.Services;

namespace EarthFront.Services
{
    public class ForumEdit : XgEdit
    {
        public ForumEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
                Table = "dbo.Forum",
                PkeyFid = "Id",
                Col4 = new string[] { "Creator", "Created" },
                ReadSql = @"
select f.*,
    CreatorName=u.Name
from dbo.Forum f
join dbo.[User] u on f.Creator=u.Id
where f.Id='{0}'
",
                Items = new EitemDto[]
                {
                    new() { Fid = "Id" },
                    new() { Fid = "Name" },
                    new() { Fid = "Status" },
                },
            };
        }

    } //class
}
