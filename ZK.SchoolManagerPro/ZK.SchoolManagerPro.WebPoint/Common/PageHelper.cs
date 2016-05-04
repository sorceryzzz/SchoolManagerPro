using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ZK.SchoolManagerPro.WebPoint.Common
{
    public static class PageHelper
    {
        public static HtmlString ShowPageNavigate(this HtmlHelper htmlHelper, int currentPage, int pageSize, int totalCount, string redirectTo, string name, string number, string Class, string Department)
        {
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                output.AppendFormat("<nav><ul class='pagination'><li {2}><a  aria-label='Previous' href='{0}?pageIndex=1&pageSize={1}&Name={3}&number={4}&Class={5}&Department={6}'><span aria-hidden='true'>首页</span></a></li> ", redirectTo, pageSize, currentPage != 1 ? "" : " class='disabled'", name, number, Class, Department);
                output.AppendFormat("<li {3}><a  aria-label='Previous' href='{0}?pageIndex={1}&pageSize={2}&Name={3}&number={4}&Class={5}&Department={6}'><span aria-hidden='true'>上一页</span></a></li> ", redirectTo, currentPage - 1, pageSize, currentPage > 1 ? "" : " class='disabled'", name, number, Class, Department);

                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理                           
                            output.AppendFormat("<li class='active'><a href='{0}?pageIndex={1}&pageSize={2}&name={4}&number={5}&Class={6}&Department={7}'>{3}</a></li> ", redirectTo, currentPage, pageSize, currentPage, name, number, Class, Department);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}&name={4}&number={5}&Class={6}&Department={7}'>{3}</a></li> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint, name, number, Class, Department);
                        }
                    }
                    output.Append(" ");
                }

                output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&name={4}&number={5}&Class={6}&Department={7}' aria-label='Next'><span aria-hidden='true'>下一页</span></a></li> ", redirectTo, currentPage + 1, pageSize, currentPage < totalPages ? "" : " class='disabled'", name, number, Class, Department);

                output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&name={4}&number={5}&Class={6}&Department={7}' aria-label='Next'><span aria-hidden='true'>末页</span></a></li></ul></nav>", redirectTo, totalPages, pageSize, currentPage != totalPages ? "" : " class='disabled'", name, number, Class, Department);
            }
            //output.AppendFormat("<label>第{0}页 / 共{1}页</label>", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }
    }
}