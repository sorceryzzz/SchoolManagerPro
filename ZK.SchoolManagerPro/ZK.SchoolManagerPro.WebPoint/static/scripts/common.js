var parentStr="";
function checkOrg(path){
	vReturnValue = window.showModalDialog(path+"/dforganizationcontroller/getorgjson.do",'组织机构',"dialogWidth=300px;dialogHeight=450px");
	if(vReturnValue!=null&&vReturnValue!=""){
		var org = vReturnValue.split(",");
		return org;
	}
}
function checkEnt(path,flag){
	window.open(path+'/dfcompanylistcontroller/findcompanylist.do?flag='+flag,'companyList','height=440,width=770,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
	//vReturnValue = window.showModalDialog(path+"/dfcompanylistcontroller/findcompanylist.do?flag=2",'企业信息',"dialogWidth=750px;dialogHeight=450px");
	
}
function checkEnt(path,flag,pub){
	window.open(path+'/dfcompanylistcontroller/findcompanylist.do?flag='+flag+'&&pub='+pub,'companyList','');
	//vReturnValue = window.showModalDialog(path+"/dfcompanylistcontroller/findcompanylist.do?flag=2",'企业信息',"dialogWidth=750px;dialogHeight=450px");
	
}
function check_ent_group(path,flag){
	window.open(path+'/dfcompanygourpcontroller/getentgroup.do?flag='+flag,'entGroupList','height=470,width=770,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
	//vReturnValue = window.showModalDialog(path+"/dfcompanylistcontroller/findcompanylist.do?flag=2",'企业信息',"dialogWidth=750px;dialogHeight=450px");
	
}
function check_cust_manager(path,flag){
	window.open(path+'/dfcustmanagercontroller/getcustmanagerlist.do?flag='+flag,'custMangerList','height=460,width=770,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
	//vReturnValue = window.showModalDialog(path+"/dfcompanylistcontroller/findcompanylist.do?flag=2",'企业信息',"dialogWidth=750px;dialogHeight=450px");
	
}

//验证手机号    参数  telVal:需要验证的值
function validateTelCommon(telVal) {
	var m = telVal.match(/^\s*(\S+(\s+\S+)*)\s*/); 
	telVal = ((m == null) ? "" : m[1]); 
	if(telVal == '') {
		return true;
	}
	var valMobile = (/^(?:1[358]\d|147)-?\d{5}(\d{3}|\*{3})/.test(telVal));
	var valTel = (/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?/.test(telVal));
	if(valMobile || valTel) {
		return true;
	} else {
		return false;
	}
} 

//验证邮箱    参数  email:需要验证的值
function validateEmailCommon(email) {
	var reg = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
	var m = email.match(/^\s*(\S+(\s+\S+)*)\s*/); 
	email = ((m == null) ? "" : m[1]);
	if(email == '') {
		return true;
	}
	if(reg.test(email)) {
		return true;
	} else {
		return false;
	}
}

//验证额度    参数  limit:需要验证的值
function validateLimitCommon(limit) {
	limit = limit.replace(/(^\s*)|(\s*$)/g,"");
	var reg = /^\d*\.?\d{1,2}$/;
	if(reg.exec(limit) == null) {
		return false;
	}
	return true;
}
