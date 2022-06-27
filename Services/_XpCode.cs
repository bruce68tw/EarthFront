using Base.Models;
using Base.Services;

namespace EarthFront.Services
{
    //for dropdown input
    public static class _XpCode
    {
        #region master table to codes
        public static async Task<List<IdStrDto>> GetDonatesAsync(Db? db = null)
        {
            return await TableToListAsync("Donate", db);
        }
        public static async Task<List<IdStrDto>> GetRolesAsync(Db? db = null)
        {
            return await TableToListAsync("XpRole", db);
        }
        public static async Task<List<IdStrDto>> GetProgsAsync(Db? db = null)
        {
            //return TableToList("XpProg", db);
            var sql = @"
select 
    Id, (case when AuthRow=1 then '*' else '' end)+Name as Str
from dbo.XpProg
order by Id";
            return await SqlToListAsync(sql, db);
        }
        #endregion

        #region get from XpCode table
        public static async Task<List<IdStrDto>> GetLangLevelsAsync(string locale, Db? db = null)
        {
            return await TypeToListAsync(locale, "LangLevel", db);
        }
        #endregion

        private static async Task<List<IdStrDto>> TableToListAsync(string table, Db? db = null)
        {
            var sql = string.Format(@"
select 
    Id, Name as Str
from dbo.[{0}]
order by Id
", table);
            return await SqlToListAsync(sql, db);
        }

        //get codes from sql 
        private static async Task<List<IdStrDto>> SqlToListAsync(string sql, Db? db = null)
        {
            var emptyDb = false;
            _Fun.CheckOpenDb(ref db, ref emptyDb);

            var rows = await db.GetModelsAsync<IdStrDto>(sql);
            await _Fun.CheckCloseDb(db, emptyDb);
            return rows;
        }

        //get code table rows
        private static async Task<List<IdStrDto>> TypeToListAsync(string locale, string type, Db? db = null)
        {
            var sql = $@"
select 
    Value as Id, Name_{locale} as Str
from dbo.XpCode
where Type='{type}'
order by Sort";
            return await SqlToListAsync(sql, db);
        }

    }//class
}
