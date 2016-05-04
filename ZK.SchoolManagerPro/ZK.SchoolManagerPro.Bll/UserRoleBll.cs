using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_user_role
    /// </summary>
    public class UserRoleBll
    {
        private readonly ZK.SchoolManagerPro.DAL.UserRoleDal dal = new ZK.SchoolManagerPro.DAL.UserRoleDal();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_user_role model)
        {
           return  dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_user_role model)
        {
            int count = dal.Update(model);
            return count;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? t_urid)
        {
            int count = dal.Delete(t_urid);
            return count;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? t_urid)
        {
            bool bln = dal.Exists(t_urid);
            return bln;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_user_role GetModel(int? t_urid)
        {
            ZK.SchoolManagerPro.Model.t_user_role model = null;
            if (!EnableCache)
            {
                model = dal.GetModel(t_urid);
            }
            else
            {
                string key = t_urid.ToString();
                if (GetModelCache(key) != null)
                {
                    model = (ZK.SchoolManagerPro.Model.t_user_role)GetModelCache(key);
                }
                else
                {
                    model = dal.GetModel(t_urid);
                    TryAddModelCache(key, model, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_user_role> GetList()
        {
            List<ZK.SchoolManagerPro.Model.t_user_role> lst = dal.GetList();
            return lst;
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public PageList<ZK.SchoolManagerPro.Model.t_user_role> GetPageList(PageInfo pi)
        {
            PageList<ZK.SchoolManagerPro.Model.t_user_role> pl = dal.GetPageList(pi);
            return pl;
        }
    }
}
