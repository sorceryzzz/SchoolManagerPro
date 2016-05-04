<%@ page language="java" pageEncoding="UTF-8"%>
	<c:if test="${null != pageData}">
  	 共&nbsp;${pageData.recordCount}&nbsp;条记录&nbsp;第${pageData.currentPage}页/${pageData.pageCount}页
   <input type="text" size="1" name="pagenoT" value="${pageData.currentPage}" />
   <input type="button" value="跳转" class="input" onclick="goPage('listForm', document.forms['dataListForm'].pagenoT.value);" name='gopage'>
   <input type="button" onclick="goPage('listForm', ${pageData.firstPage});"   class="page_button" value="首页" <c:if test="${!pageData.hasPrePage}">disabled</c:if> >
   <input type="button" onclick="goPage('listForm', ${pageData.prePage});"   class="page_button" value="上页" <c:if test="${!pageData.hasPrePage}">disabled</c:if> >
   <input type="button" onclick="goPage('listForm', ${pageData.nextPage});"  class="page_button" value="下页" <c:if test="${!pageData.hasNextPage}">disabled</c:if> >
   <input type="button" onclick="goPage('listForm', ${pageData.lastPage});"  class="page_button" value="尾页" <c:if test="${!pageData.hasNextPage}">disabled</c:if> >
	</c:if>