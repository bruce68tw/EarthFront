var _me = {

    init: function (pageStr) {
        _me.page = new Page({
            pageStr: pageStr,
            pager: $('#divPage'),
            linker: $('#hideLink'),
            //showMenu: true,
            //pageRowList: [9, 18, 36],
            action: '/Act/Read',
            onFind: _me.onFind,
        });
    },

    onFind: function (page) {
        var json = { name: $('#Name').val() };
        _me.page.find(json, page);
    },

}; //class