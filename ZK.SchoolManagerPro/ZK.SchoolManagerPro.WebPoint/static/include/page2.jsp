<%@ page language="java" pageEncoding="UTF-8"%>
	<c:if test="${null != test}">
  	 共&nbsp;${test.recordCount}&nbsp;条记录&nbsp;第${test.currentPage}页/${test.pageCount}页
   <input type="text" size="1" name="pagenoT" value="${test.currentPage}" />
   <input type="button" value="跳转" class="input" onclick="goPage2('listForm', document.forms['dataListForm2'].pagenoT.value);" name='gopage'>
   <input type="button" onclick="goPage2('listForm', ${test.firstPage});"   class="page_button" value="首页" <c:if test="${!test.hasPrePage}">disabled</c:if> >
   <input type="button" onclick="goPage2('listForm', ${test.prePage});"   class="page_button" value="上页" <c:if test="${!test.hasPrePage}">disabled</c:if> >
   <input type="button" onclick="goPage2('listForm', ${test.nextPage});"  class="page_button" value="下页" <c:if test="${!test.hasNextPage}">disabled</c:if> >
   <input type="button" onclick="goPage2('listForm', ${test.lastPage});"  class="page_button" value="尾页" <c:if test="${!test.hasNextPage}">disabled</c:if> >
	</c:if>
	
	<script type="text/javascript" >
	function goPage2(formId, pageNo, isNew) {
		alert("hey,girl....");
	var theform = document.getElementById(formId);
	theform.currentPage2.value = pageNo;
	theform.submit();
	
}
</script>