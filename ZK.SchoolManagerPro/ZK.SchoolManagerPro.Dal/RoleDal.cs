using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ZK.SchoolManagerPro.DAL
{
    /// <summary>
    /// 数据访问类 t_role
    /// <summary>
    public partial class t_role : DALHelper
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_role model)
        {
            IDbDataParameter[] parms4t_role = PrepareAddParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.StoredProcedure, COMMAND_ADD, parms4t_role);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_role model)
        {
            IDbDataParameter[] parms4t_role = PrepareUpdateParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.StoredProcedure, COMMAND_UPDATE, parms4t_role);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? r_id)
        {
            IDbDataParameter[] parms4t_role = PrepareDeleteParameters(r_id);
            return dbHelper.ExecuteNonQuery(CommandType.StoredProcedure, COMMAND_DELETE, parms4t_role);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_role GetModel(int? r_id)
        {
            IDbDataParameter[] parms4t_role = PrepareGetModelParameters(r_id);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.StoredProcedure, COMMAND_GETMODEL, parms4t_role))
            {
                if (dr.Read()) return GetModel(dr);
                return null;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? r_id)
        {
            IDbDataParameter[] parms4t_role = PrepareExistParameters(r_id);
            object obj = dbHelper.ExecuteScalar(CommandType.StoredProcedure, COMMAND_EXISTS, parms4t_role);
            return int.Parse(obj.ToString()) > 0;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount()
        {
            object obj = dbHelper.ExecuteScalar(CommandType.StoredProcedure, COMMAND_GETCOUNT, null);
            return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_role> GetList()
        {
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.StoredProcedure, COMMAND_GETLIST, null))
            {
                List<ZK.SchoolManagerPro.Model.t_role> lst = new List<ZK.SchoolManagerPro.Model.t_role>();
                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));
                return lst;
            }
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public PageList<ZK.SchoolManagerPro.Model.t_role> GetPageList(PageInfo pi)
        {
            pi.RecordCount = GetCount();
            pi.Compute();

            PageList<ZK.SchoolManagerPro.Model.t_role> pl = new PageList<ZK.SchoolManagerPro.Model.t_role>(pi);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, COMMAND_GETLIST, null))
            {
                pl.List = new List<ZK.SchoolManagerPro.Model.t_role>();
                ExecuteReaderAction(dr, pi.FirstIndex, pi.PageSize, r => pl.List.Add(GetModel(r)));
            }
            return pl;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private ZK.SchoolManagerPro.Model.t_role GetModel(IDataReader dr)
        {
            ZK.SchoolManagerPro.Model.t_role model = new ZK.SchoolManagerPro.Model.t_role();
            PrepareModel(model, dr);
            return model;
        }
    }
}