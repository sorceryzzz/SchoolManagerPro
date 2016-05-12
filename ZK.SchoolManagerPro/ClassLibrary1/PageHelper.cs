using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ClassLibrary1
{
    public static  class PageHelper
    {
        public static HtmlString ShowPageNavigate(int currentPage, int pageSize, int totalCount, string redirectTo, string Name, string number, string Class, string department)
        {
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                output.AppendFormat("<nav><ul class='pagination'><li {2}><a  aria-label='Previous' href='{0}?pageIndex=1&pageSize={1}&Name={3}&number={4}&class={5}&department={6}'><span aria-hidden='true'>首页</span></a></li> ", redirectTo, pageSize, currentPage != 1 ? "" : " class='disabled'", Name, number, Class, department);
                output.AppendFormat("<li {3}><a  aria-label='Previous' href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&class={6}&department={7}'><span aria-hidden='true'>上一页</span></a></li> ", redirectTo, currentPage - 1, pageSize, currentPage > 1 ? "" : " class='disabled'", Name, number, Class, department);

                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理                           
                            output.AppendFormat("<li class='active'><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&class={6}&department={7}'>{3}</a></li> ", redirectTo, currentPage, pageSize, currentPage, Name, number, Class, department);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&class={6}&department={7}'>{3}</a></li> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint, Name, number, Class, department);
                        }
                    }
                    output.Append(" ");
                }

                output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&class={6}&department={7}' aria-label='Next'><span aria-hidden='true'>下一页</span></a></li> ", redirectTo, currentPage + 1, pageSize, currentPage < totalPages ? "" : " class='disabled'", Name, number, Class, department);

                output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&class={6}&department={7}' aria-label='Next'><span aria-hidden='true'>末页</span></a></li></ul></nav>", redirectTo, totalPages, pageSize, currentPage != totalPages ? "" : " class='disabled'", Name, number, Class, department);
            }
            //output.AppendFormat("<label>第{0}页 / 共{1}页</label>", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }

        public static HtmlString ShowTeaPageNavigate(this HtmlHelper helper, int currentPage, int pageSize, int totalCount, string redirectTo, string Name, string number, string department)
        {
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            try
            {
                if (totalPages > 1)
                {
                    output.AppendFormat("<nav><ul class='pagination'><li {2}><a  aria-label='Previous' href='{0}?pageIndex=1&pageSize={1}&Name={3}&number={4}&department={5}'><span aria-hidden='true'>首页</span></a></li> ", redirectTo, pageSize, currentPage != 1 ? "" : " class='disabled'", Name, number, department);
                    output.AppendFormat("<li {3}><a  aria-label='Previous' href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&department={6}'><span aria-hidden='true'>上一页</span></a></li> ", redirectTo, currentPage - 1, pageSize, currentPage > 1 ? "" : " class='disabled'", Name, number, department);

                    int currint = 5;
                    for (int i = 0; i <= 10; i++)
                    {//一共最多显示10个页码，前面5个，后面5个
                        if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                        {
                            if (currint == i)
                            {//当前页处理                           
                                output.AppendFormat("<li class='active'><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&department={6}'>{3}</a></li> ", redirectTo, currentPage, pageSize, currentPage, Name, number, department);
                            }
                            else
                            {//一般页处理
                                output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&department={6}'>{3}</a></li> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint, Name, number, department);
                            }
                        }
                        output.Append(" ");
                    }

                    output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&department={6}' aria-label='Next'><span aria-hidden='true'>下一页</span></a></li> ", redirectTo, currentPage + 1, pageSize, currentPage < totalPages ? "" : " class='disabled'", Name, number, department);

                    output.AppendFormat("<li {3}><a href='{0}?pageIndex={1}&pageSize={2}&Name={4}&number={5}&department={6}' aria-label='Next'><span aria-hidden='true'>末页</span></a></li></ul></nav>", redirectTo, totalPages, pageSize, currentPage != totalPages ? "" : " class='disabled'", Name, number, department);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                throw;
            }
            //output.AppendFormat("<label>第{0}页 / 共{1}页</label>", currentPage, totalPages);//这个统计加不加都行

            return new HtmlString(output.ToString());
        }
    }
}
