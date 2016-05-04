function showModalCenter(url, pwin, callback, wWidth, wHeight, title) {
	openModalDialog(url, wWidth, wHeight, callback, null, null, null, null, title);
}

function del(formId, url, data) {
	appAjaxLocalSub(formId, url, data);
}

function save(formId, url) {
	appAjaxSave(formId, url, null);
}