var _me = {

    init: function (pageStr) {
        _me.page = new Page({
            pageStr: pageStr,
            pager: $('#divPage'),
            linker: $('#hideLink'),
            showMenu: true,
            //pageRowList: [9,18,36],
            action: '/RaiseAct/Read',
            onFind: _me.onFind,
        });

        _crudR.init();
    },

    onFind: function (page) {
        var json = { name: $('#Name').val() };
        _me.page.find(json, page);
    },

    //onclick viewFile, called by XiFile component
    onViewFile: function (table, fid, elm) {
        _me.edit0.onViewFile(table, fid, elm);
    },

}; //class