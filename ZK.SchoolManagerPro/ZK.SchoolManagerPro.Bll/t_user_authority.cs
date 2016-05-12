//using System;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Caching;

//namespace ZK.SchoolManagerPro.BLL
//{
//    /// <summary>
//    /// 业务逻辑类 t_user_authority
//    /// </summary>
//    public class t_user_authority: BLHelper
//    {
//        private readonly ZK.SchoolManagerPro.DAL.t_user_authority dal = new ZK.SchoolManagerPro.DAL.t_user_authority();

//        public t_user_authority()
//            : base("_t_user_authority_") { }

//        /// <summary>
//        /// 增加一条数据
//        /// </summary>
//        public void Add(ZK.SchoolManagerPro.Model.t_user_authority model)
//        {
//            dal.Add(model);
//        }

//        /// <summary>
//        /// 更新一条数据
//        /// </summary>
//        public void Update(ZK.SchoolManagerPro.Model.t_user_authority model)
//        {
//            int count = dal.Update(model);
//            if (EnableCache && count > 0)
//            {
//                RemoveModelCache(model.t_uaid);
//            }
//        }

//        /// <summary>
//        /// 删除一条数据
//        /// </summary>
//        public void Delete(int? t_uaid)
//        {
//            int count = dal.Delete(t_uaid);
//            if (EnableCache && count > 0)
//            {
//                RemoveModelCache(t_uaid.ToString());
//            }
//        }

//        /// <summary>
//        /// 是否存在该记录
//        /// </summary>
//        public bool Exists(int? t_uaid)
//        {
//            bool bln = dal.Exists(t_uaid);
//            return bln;
//        }

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        public ZK.SchoolManagerPro.Model.t_user_authority GetModel(int? t_uaid)
//        {
//            ZK.SchoolManagerPro.Model.t_user_authority model = null;
//            if (!EnableCache)
//            {
//                model = dal.GetModel(t_uaid);
//            }
//            else
//            {
//                string key = t_uaid.ToString();
//                if (GetModelCache(key) != null)
//                {
//                    model = (ZK.SchoolManagerPro.Model.t_user_authority)GetModelCache(key);
//                }
//                else
//                {
//                    model = dal.GetModel(t_uaid);
//                    TryAddModelCache(key, model, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
//                }
//            }
//            return model;
//        }

//        /// <summary>
//        /// 获得泛型数据列表
//        /// </summary>
//        public List<ZK.SchoolManagerPro.Model.t_user_authority> GetList()
//        {
//            List<ZK.SchoolManagerPro.Model.t_user_authority> lst = dal.GetList();
//            return lst;
//        }

//        /// <summary>
//        /// 分页获取泛型数据列表
//        /// </summary>
//        public PageList<ZK.SchoolManagerPro.Model.t_user_authority> GetPageList(PageInfo pi)
//        {
//            PageList<ZK.SchoolManagerPro.Model.t_user_authority> pl = dal.GetPageList(pi);
//            return pl;
//        }
//    }
//}
