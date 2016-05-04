using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_role
    /// </summary>
    public class t_role: BLHelper
    {
        private readonly ZK.SchoolManagerPro.DAL.t_role dal = new ZK.SchoolManagerPro.DAL.t_role();

        public t_role()
            : base("_t_role_") { }

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
        public void Update(ZK.SchoolManagerPro.Model.t_role model)
        {
            int count = dal.Update(model);
            if (EnableCache && count > 0)
            {
                RemoveModelCache(model.r_id);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int? r_id)
        {
            int count = dal.Delete(r_id);
            if (EnableCache && count > 0)
            {
                RemoveModelCache(r_id.ToString());
            }
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
            ZK.SchoolManagerPro.Model.t_role model = null;
            if (!EnableCache)
            {
                model = dal.GetModel(r_id);
            }
            else
            {
                string key = r_id.ToString();
                if (GetModelCache(key) != null)
                {
                    model = (ZK.SchoolManagerPro.Model.t_role)GetModelCache(key);
                }
                else
                {
                    model = dal.GetModel(r_id);
                    TryAddModelCache(key, model, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
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

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public PageList<ZK.SchoolManagerPro.Model.t_role> GetPageList(PageInfo pi)
        {
            PageList<ZK.SchoolManagerPro.Model.t_role> pl = dal.GetPageList(pi);
            return pl;
        }
    }
}
