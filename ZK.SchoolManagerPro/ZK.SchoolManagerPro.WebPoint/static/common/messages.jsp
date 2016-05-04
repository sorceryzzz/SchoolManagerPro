<c:if test="${null != statusData}">
 <div class="error" id="errorMessages"> 	
          ${statusData.resultCode} <br>
          ${statusData.resultMessage}
</div>
</c:if>