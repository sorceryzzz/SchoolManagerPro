using Dinlun.GatewaySite.Common;
using MySql.Data.MySqlClient;
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

            #region - sql qy-

            string insertQy = @"INSERT INTO `zkmanagerdb`.`t_authority`
            (
             `ah_name`,
             `ah_controller_url`,
             `ah_action_url`,
             `ah_creater`,
             `ah_createtime`,
             `ah_updatetime`)
VALUES (
        @ah_name,
        @ah_controller_url,
        @ah_action_url,
        @ah_creater,
        @ah_createtime,
        @ah_updatetime);";
            #endregion


            #region - paras -
            MySqlParameter[] parms ={
                                    new MySqlParameter("@ah_name",model.AH_Name),
                                    new MySqlParameter("@ah_controller_url",model.AH_ControllerURL),
                                    new MySqlParameter("@ah_action_url",model.AH_ActionUrl),
                                    new MySqlParameter("@ah_creater",model.AH_Creater),
                                    new MySqlParameter("@ah_createtime",model.AH_CreateTime),
                                    new MySqlParameter("@ah_updatetime",model.AH_UpdateTime)
                                   };
            #endregion


            #region - exucte -
            try
            {
                return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, insertQy, parms);
            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ZK.SchoolManagerPro.Model.t_authority model)
        {

            #region - qy -
            string updateQy = @"UPDATE `zkmanagerdb`.`t_authority`
                                SET 
                                  `ah_name` =@ah_name,
                                  `ah_controller_url` =@ah_controller_url,
                                  `ah_action_url` =@ah_action_url,
                                  `ah_updatetime` =@ah_updatetime
                                WHERE `ah_id`= @ah_id;";
            #endregion

            #region - paras -
            MySqlParameter[] parms ={
                                    new MySqlParameter("@ah_id",model.AH_ID),
                                    new MySqlParameter("@ah_name",model.AH_Name),
                                    new MySqlParameter("@ah_controller_url",model.AH_ControllerURL),
                                    new MySqlParameter("@ah_action_url",model.AH_ActionUrl),
                                    new MySqlParameter("@ah_updatetime",model.AH_UpdateTime)
                                   };
            #endregion

            #region - exucte -
            try
            {
                return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, updateQy, parms);
            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? ah_id)
        {
            #region - qy -
            string deleteQy = @"DELETE
                                FROM `zkmanagerdb`.`t_authority`
                                WHERE `ah_id` = @ah_id; ";
            #endregion

            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@ah_id",ah_id.Value)

            };
            #endregion

            #region - exucte -
            try
            {
                return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, deleteQy, paras);
            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_authority GetModel(int? ah_id)
        {

            #region - qy -
            string selectQy = @"SELECT
                                  `ah_id`,
                                  `ah_name`,
                                  `ah_controller_url`,
                                  `ah_action_url`,
                                  `ah_creater`,
                                  `ah_createtime`,
                                  `ah_updatetime`
                                FROM `zkmanagerdb`.`t_authority`
                                WHERE ah_id=@ah_id";
            #endregion


            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@ah_id",ah_id.Value)

            };
            #endregion

            MySqlDataReader reader = DbHelperMySql.ExecuteReader(DbHelperMySql.connectionStringManager, CommandType.Text, selectQy, paras);
            Model.t_authority tModel = ConvertToModel(reader);



            return tModel;
  
        }

        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Model.t_authority ConvertToModel(MySqlDataReader reader)
        {

            Model.t_authority tmodel = new Model.t_authority();
            try
            {
                while (reader.Read())
                {

                    tmodel.AH_ID = Convert.ToInt32(reader["ah_id"]);
                    tmodel.AH_Name = reader["ah_name"].ToString();
                    tmodel.AH_ControllerURL = reader["ah_controller_url"].ToString();
                    tmodel.AH_ActionUrl = reader["ah_action_url"].ToString();
                    tmodel.AH_Creater = reader["ah_creater"].ToString();
                    tmodel.AH_CreateTime =Convert.ToDateTime(reader["ah_createtime"]);
                    tmodel.AH_UpdateTime = Convert.ToDateTime(reader["ah_updatetime"]);

                }
            }
            catch (Exception ex)
            {
            }
            return tmodel;
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
            string cmdText = string.Format("SELECT COUNT(*)  FROM t_authority");
            return Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText));
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_authority> GetList()
        {
            return null;
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="columns"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int pageIndex, int pageSize, string strWhere,  string sort)
        {
            string cmdText = string.Empty;
            DataSet ds = null;
            try
            {
                cmdText = string.Format("SELECT * FROM t_authority WHERE {0} ORDER BY {1} LIMIT {2},{3}", strWhere, sort, (pageIndex - 1) * pageSize, pageSize);
                ds = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, cmdText);
            }
            catch (Exception ex)
            {
                throw ;
            }
            return ds;
        }
    }
}