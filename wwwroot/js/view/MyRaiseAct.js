var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'Status' },
                { data: 'CreatorName' },
                { data: 'Created' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crud.dtStatusName(data);
                }},
				{ targets: [3], render: function (data, type, full, meta) {
                    return _date.mmToUiDt(data);
                }, className: 'xg-center '+ _fun.HideRwd },
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crud.dtCrudFun(full.Id, full.Name, true, true, false);
                }},
            ],
        };

        //initial
		_crud.init(config);
    },

}; //class