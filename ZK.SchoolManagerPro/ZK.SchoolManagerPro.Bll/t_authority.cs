﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace ZK.SchoolManagerPro.BLL
{
    /// <summary>
    /// 业务逻辑类 t_authority
    /// </summary>
    public class t_authority
    {
        private readonly ZK.SchoolManagerPro.DAL. t_authority dal = new ZK.SchoolManagerPro.DAL.t_authority();


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
        public int Update(ZK.SchoolManagerPro.Model.t_authority model)
        {
            int count = dal.Update(model);
            return count;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? ah_id)
        {
            int count = dal.Delete(ah_id);
            return count;
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
           
            model = dal.GetModel(ah_id);
           
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
    }
}
