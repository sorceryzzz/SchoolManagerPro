﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_user_authority
    /// </summary>
    public class t_user_authority
    {
        private readonly ZK.SchoolManagerPro.DAL.t_user_authority dal = new ZK.SchoolManagerPro.DAL.t_user_authority();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZK.SchoolManagerPro.Model.t_user_authority model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_user_authority model)
        {
            int count = dal.Update(model);
            return count;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? t_uaid)
        {
            int count = dal.Delete(t_uaid);
            return count;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? t_uaid)
        {
            bool bln = dal.Exists(t_uaid);
            return bln;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_user_authority GetModel(int? t_uaid)
        {
            var  model = dal.GetModel(t_uaid);
            return model;
        }

        /// <summary>
        /// 获得泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_user_authority> GetList()
        {
            List<ZK.SchoolManagerPro.Model.t_user_authority> lst = dal.GetList();
            return lst;
        }
    }
}
