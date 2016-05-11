using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ZK.SchoolManagerPro.DAL
{
    /// <summary>
    /// 数据访问类 t_authority
    /// <summary>
    public partial class t_authority
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_authority model)
        {
            return -1;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_authority model)
        {
            return -1;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? ah_id)
        {
            return -1;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_authority GetModel(int? ah_id)
        {
                return null;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? ah_id)
        {
            return false;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount()
        {
            return -1;
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_authority> GetList()
        {
            return null;
        }
    }
}