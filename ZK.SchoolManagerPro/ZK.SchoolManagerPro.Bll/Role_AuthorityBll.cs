using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_role_authority
    /// </summary>
    public class Role_AuthorityBll
    {
        private readonly ZK.SchoolManagerPro.DAL.t_role_authority dal = new ZK.SchoolManagerPro.DAL.t_role_authority();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZK.SchoolManagerPro.Model.t_role_authority model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_role_authority model)
        {
            int count = dal.Update(model);
            return count;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? t_ra_id)
        {
            int count = dal.Delete(t_ra_id);
            return count;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? t_ra_id)
        {
            bool bln = dal.Exists(t_ra_id);
            return bln;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_role_authority GetModel(int? t_ra_id)
        {
           var  model = dal.GetModel(t_ra_id);
            return model;
        }

        /// <summary>
        /// 获得泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_role_authority> GetList()
        {
            List<ZK.SchoolManagerPro.Model.t_role_authority> lst = dal.GetList();
            return lst;
        }
    }
}
