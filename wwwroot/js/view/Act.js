var _me = {

    init: function () {
        _page.init($('#divPage'), _me.pageArg, _me.onPage);
    },

    //on click 頁次
    onFind: function () {
        _me.findData();
    },

    //on click 頁次
    onPage: function (page, event) {
        event.preventDefault();
        _me.findData(page);
    },

    //page: re-count rows if null
    findData: function (page) {
        var json = { act: $('#ActName').val() };
        _page.onPage(page, _me.pageArg, '/Act/Read', json);
	},

}; //class