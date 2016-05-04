<%@ page language="java" isErrorPage="true" pageEncoding="UTF-8" contentType="text/html;charset=UTF-8" %>
<%@ include file="/static/common/taglibs.jsp"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<title>${app_title}</title>	
</head>

<body id="error">
    <div id="page">
        <div id="content" class="clearfix">
            <div id="main">
            		<%@ include file="/static/common/messages.jsp" %>
                <img src="${ctx}/static/images/error.png" width="223" height="97">
            </div>
        </div>
    </div>
</body>
</html>
