using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_role
    /// </summary>
    public class t_role
    {
        private readonly ZK.SchoolManagerPro.DAL.t_role dal = new ZK.SchoolManagerPro.DAL.t_role();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZK.SchoolManagerPro.Model.t_role model)
        {
            dal.Add(model);
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

        /// <summary>
        /// 获得泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_role> GetList()
        {
            List<ZK.SchoolManagerPro.Model.t_role> lst = dal.GetList();
            return lst;
        }
    }
}
