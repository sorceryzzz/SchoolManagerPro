using Dinlun.GatewaySite.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.DAL
{
    /// <summary>
    /// 数据访问类 t_role
    /// <summary>
    public partial class t_role
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_role model)
        {

            #region - qy -
            string insertQy = @"INSERT INTO `zkmanagerdb`.`t_role`
                                            (
                                             `r_name`,
                                             `r_creater`,
                                             `r_createTime`,
                                             `r_updateTime`)
                                VALUES (
                                        @r_name,
                                        @r_creater,
                                        @r_createTime,
                                        @r_updateTime);";
            #endregion


            #region - paras -
            MySqlParameter[] parms ={
                                    new MySqlParameter("@r_name",model.R_Name),
                                    new MySqlParameter("@r_creater",model.R_Creater),
                                    new MySqlParameter("@r_createTime",model.R_CreateTime),
                                    new MySqlParameter("@r_updateTime",model.R_UpdateTime)
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
        public int Update(ZK.SchoolManagerPro.Model.t_role model)
        {
            #region - qy  -
            string updateQy = @"UPDATE `zkmanagerdb`.`t_role`
                                SET 
                                  `r_name` =@r_name,
                                  `r_updateTime` =@r_updateTime
                                WHERE `r_id` =@r_id;";
            #endregion

            #region - paras  -
            MySqlParameter[] parms ={
                                    new MySqlParameter("@r_id",model.R_ID),
                                    new MySqlParameter("@r_name",model.R_Name),
                                    new MySqlParameter("@r_updatetime",model.R_UpdateTime)
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
        public int Delete(int? r_id)
        {
            #region - qy -
            string deleteQy = @"DELETE
                                FROM `zkmanagerdb`.`t_role`
                                WHERE `r_id` = @r_id;";
            #endregion

            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@r_id",r_id.Value)

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
        public ZK.SchoolManagerPro.Model.t_role GetModel(int? r_id)
        {

            #region - qy -
            string selectQy = @"SELECT
                                  `r_id`,
                                  `r_name`,
                                  `r_creater`,
                                  `r_createTime`,
                                  `r_updateTime`
                                FROM `zkmanagerdb`.`t_role`
                                WHERE `r_id` = @r_id;";
            #endregion

            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@r_id",r_id.Value)

            };
            #endregion



            MySqlDataReader reader = DbHelperMySql.ExecuteReader(DbHelperMySql.connectionStringManager, CommandType.Text, selectQy, paras);
            Model.t_role tModel = ConvertToModel(reader);

            return tModel;

        }

        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Model.t_role ConvertToModel(MySqlDataReader reader)
        {

            Model.t_role tmodel = new Model.t_role();
            try
            {
                while (reader.Read())
                {

                    tmodel.R_ID= Convert.ToInt32(reader["r_id"]);
                    tmodel.R_Name = reader["r_name"].ToString();
                    tmodel.R_Creater = reader["r_creater"].ToString();
                    tmodel.R_CreateTime = Convert.ToDateTime(reader["ah_createtime"]);
                    tmodel.R_UpdateTime = Convert.ToDateTime(reader["ah_updatetime"]);

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
        public bool Exists(int? r_id)
        {
            return false;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount()
        {
            string cmdText = string.Format("SELECT COUNT(*)  FROM t_role");
            return Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText));
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
        public DataSet GetRoleList(int pageIndex, int pageSize, string strWhere, string sort)
        {
            string cmdText = string.Empty;
            DataSet ds = null;
            try
            {
                cmdText = string.Format("SELECT * FROM t_role WHERE {0} ORDER BY {1} LIMIT {2},{3}", strWhere, sort, (pageIndex - 1) * pageSize, pageSize);
                ds = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, cmdText);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ds;
        }
    }
}