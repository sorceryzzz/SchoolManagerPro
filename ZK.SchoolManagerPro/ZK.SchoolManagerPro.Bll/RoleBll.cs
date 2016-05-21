using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_role
    /// </summary>
    public class RoleBll
    {
        private readonly ZK.SchoolManagerPro.DAL.t_role dal = new ZK.SchoolManagerPro.DAL.t_role();

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="columns"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataTable GetRoleList(int pageIndex, int pageSize)
        {
            return dal.GetRoleList(pageIndex, pageSize, "1=1", "r_createTime").Tables[0];
        }
        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="columns"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataTable GetRoleList()
        {
            return dal.GetRoleList().Tables[0];
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_role model)
        {
          return  dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_role model)
        {
            int count = dal.Update(model);
            return count;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? r_id)
        {
            int count = dal.Delete(r_id);
            return count;
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return dal.GetCount();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? r_id)
        {
            bool bln = dal.Exists(r_id);
            return bln;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_role GetModel(int? r_id)
        {
            var  model = dal.GetModel(r_id);
            return model;
        }

    }
}
