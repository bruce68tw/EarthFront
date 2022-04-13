var _page = {
	
	//每頁顯示筆數
	//pageRows: 10,
	
    /**
     * 設定分頁button
     * param pageObj {object}: 分頁元件 jquery object
     * param pageNo {int}: 目前頁次, base 1
     * param filterRows {int}: 目前條件下的筆數
     * param fnOnPage {fn}: 點擊頁次trigger event, 參數(pageNo, event)
     * param noRowMsg {string}: (optional)無任何資料時的顯示訊息
     */
    init: function(pageObj, pageArg, fnOnPage, noRowMsg){
		//var pageRows = 10;
		noRowMsg = noRowMsg || _BR.FindNone;
		//pageRows = pageRows || 0;
		//here!!
		var count = pageObj.length == 0 ? 0 : parseInt(pageObj.data('count'));
		if (count <= _page.pageRows){
			if (count == 0)
				pageObj.html('<div class="-info">' + noRowMsg + '</div>')
			//pageObj.hide();
			return;
		}

		//寫入 data-pages
		//var pages = Math.floor(count/_page.pageRows) + (count % _page.pageRows > 0 ? 1 : 0);
		//pageObj.data('pages', pages);
		
		pageObj.show();
		pageObj.pagination({
			currentPage: pageArg.pageNo,
			itemsOnPage: pageArg.pageRows,
			items: pageArg.filterRows,
	        displayedPages: 3,
			cssStyle: 'compact-theme d-flex justify-content-center',
	        prevText: "<",
	        nextText: ">",
			//prevText: "<i class='fas fa-chevron-left'></i>",
			//nextText: "<i class='fas fa-chevron-right'></i>",
			onPageClick: fnOnPage,
	    });
	},

	getPageArg: function (pageStr) {
		var json = JSON.parse(_html.decode(pageStr));
		if (json['pageNo'] == null)
			json['pageNo'] = 1;
		if (json['pageRows'] == null)
			json['pageNo'] = 0;
		if (json['filterRows'] == null)
			json['filterRows'] = -1;
		return json;
	},

	getPageNo: function (pageArg) {
		return pageArg.pageNo;
	},

	onPage: function (page, pageArg, url, json) {
		var filterRows = pageArg.filterRows;
		if (page == null) {
			page = 1;
			filterRows = -1;
        }
		url += '?page=' + page +
			'&rows=' + pageArg.pageRows +
			'&filter=' + filterRows;
		for (var key in json) {
			if (_str.notEmpty(json[key]))
				url += '&' + key + '=' + json[key];
        }

		var link = $('#linkHide');
		link.attr('href', url);
		link.trigger('click');
	},

};