using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_authority
    /// </summary>
    public class t_authority: BLHelper
    {
        private readonly ZK.SchoolManagerPro.DAL.t_authority dal = new ZK.SchoolManagerPro.DAL.t_authority();

        public t_authority()
            : base("_t_authority_") { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZK.SchoolManagerPro.Model.t_authority model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZK.SchoolManagerPro.Model.t_authority model)
        {
            int count = dal.Update(model);
            if (EnableCache && count > 0)
            {
                RemoveModelCache(model.ah_id);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int? ah_id)
        {
            int count = dal.Delete(ah_id);
            if (EnableCache && count > 0)
            {
                RemoveModelCache(ah_id.ToString());
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? ah_id)
        {
            bool bln = dal.Exists(ah_id);
            return bln;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_authority GetModel(int? ah_id)
        {
            ZK.SchoolManagerPro.Model.t_authority model = null;
            if (!EnableCache)
            {
                model = dal.GetModel(ah_id);
            }
            else
            {
                string key = ah_id.ToString();
                if (GetModelCache(key) != null)
                {
                    model = (ZK.SchoolManagerPro.Model.t_authority)GetModelCache(key);
                }
                else
                {
                    model = dal.GetModel(ah_id);
                    TryAddModelCache(key, model, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_authority> GetList()
        {
            List<ZK.SchoolManagerPro.Model.t_authority> lst = dal.GetList();
            return lst;
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public PageList<ZK.SchoolManagerPro.Model.t_authority> GetPageList(PageInfo pi)
        {
            PageList<ZK.SchoolManagerPro.Model.t_authority> pl = dal.GetPageList(pi);
            return pl;
        }
    }
}
