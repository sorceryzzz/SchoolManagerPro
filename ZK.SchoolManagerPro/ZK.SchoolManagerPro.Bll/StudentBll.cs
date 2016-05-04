using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.SchoolManagerPro.Dal;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.Bll
{
   public  class StudentBll
    {
       StudentDal dal = new StudentDal();
       public DataTable GetStudetnsList(int pageIndex, int pageSize, string strWhere, string columns, string sort)
       {
           return dal.GetStudetnsList(pageIndex, pageSize, strWhere, columns, sort).Tables[0];
       }

       public int GetTotalCount(string sqlWhere)
       {
           return dal.GetTotalCount(sqlWhere);
       }

       public int DeleteStudent(int Id)
       {
           return dal.DeleteStudent(Id);
       }

       public Students GetModel(int Id)
       {
           return dal.GetModel(Id);
       }

       public int Edit(Students model)
       {
           return dal.Edit(model);
       }
       public int Add(Students model)
       {
           return dal.Add(model);
       }
       /// <summary>
       /// 重置密码
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public int ResetPassword(int Id, string password)
       {
           return dal.ResetPassword(Id, password);
       }
    }
}
