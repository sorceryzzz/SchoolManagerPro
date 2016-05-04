<%@ page language="java" pageEncoding="UTF-8" contentType="text/html;charset=utf-8"%>
<%@include file="/static/common/taglibs.jsp" %>
<%@ include file="/static/include/js/common-js.jsp"%>

<%
response.addHeader("sessionStatus", "timeout"); 
response.setStatus(HttpServletResponse.SC_UNAUTHORIZED);
%>

<script type="text/javascript">
$(function(){
  <c:if test="${'401' == param.login_error}">
  	alert(appmsg['res_status_401']);
  </c:if>
  var tUri = '${pageContext.request.queryString}';
  if (tUri != '') {
	  tUri = '?' + tUri;
  }
  
  goLogin(tUri);
});
</script>

