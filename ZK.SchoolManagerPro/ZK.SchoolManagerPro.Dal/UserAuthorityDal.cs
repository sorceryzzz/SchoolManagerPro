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
    /// 数据访问类 t_user_authority
    /// <summary>
    public partial class t_user_authority
    {


        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="columns"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataSet GetUserAuthorityList(int pageIndex, int pageSize, string strWhere, string sort)
        {
            string cmdText = string.Empty;
            DataSet ds = null;
            try
            {
                cmdText = string.Format("SELECT * FROM t_user_authority WHERE {0} ORDER BY {1} LIMIT {2},{3}", strWhere, sort, (pageIndex - 1) * pageSize, pageSize);
                ds = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, cmdText);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ds;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZK.SchoolManagerPro.Model.t_user_authority model)
        {
            #region - qy -
            string insertQy = @"INSERT INTO `zkmanagerdb`.`t_user_authority`
                                            (
                                             `t_userid`,
                                             `t_username`,
                                             `t_authorityid`,
                                             `t_authorityname`,
                                             `t_creater`,
                                             `t_createtime`,
                                             `t_updatetime`)
                                VALUES (
                                        @t_userid,
                                        @t_username,
                                        @t_authorityid,
                                        @t_authorityname,
                                        @t_creater,
                                        @t_createtime,
                                        @t_updatetime);";
            #endregion

            #region - paras -
            MySqlParameter[] parms ={
                                    new MySqlParameter("@t_userid",model.T_UserID),
                                    new MySqlParameter("@t_username",model.T_UserName),
                                    new MySqlParameter("@t_authorityname",model.T_AuthorityName),
                                    new MySqlParameter("@t_authorityid",model.T_AuthorityID),
                                    new MySqlParameter("@t_creater",model.T_Creater),
                                    new MySqlParameter("@t_createtime",model.T_CreateTime),
                                    new MySqlParameter("@t_updatetime",model.T_UpdateTime)
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
        public int Update(ZK.SchoolManagerPro.Model.t_user_authority model)
        {

            #region - qy -
            string insertQy = @"UPDATE `zkmanagerdb`.`t_user_authority`
                                SET 
                                  `t_userid` = @t_userid,
                                  `t_username` = @t_username,
                                  `t_authorityid` = @t_authorityid,
                                  `t_authorityname` = @t_authorityname,
                                  `t_updatetime` = @t_updatetime
                                WHERE `t_uaid` = @t_uaid;";
            #endregion

            #region - paras -
            MySqlParameter[] parms ={
                new MySqlParameter("@t_userid",model.T_UserID),
                                    new MySqlParameter("@t_uaid",model.T_UaID),
                                    new MySqlParameter("@t_username",model.T_UserName),
                                    new MySqlParameter("@t_authorityname",model.T_AuthorityName),
                                    new MySqlParameter("@t_authorityid",model.T_AuthorityID),
                                    new MySqlParameter("@t_updatetime",model.T_UpdateTime)
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
        /// 删除一条数据
        /// </summary>
        public int Delete(int? t_uaid)
        {
            #region - qy -
            string deleteQy = @"DELETE
                                FROM `zkmanagerdb`.`t_user_authority`
                                WHERE `t_uaid` = @t_uaid;";
            #endregion

            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@t_uaid",t_uaid.Value)

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
        public ZK.SchoolManagerPro.Model.t_user_authority GetModel(int? t_uaid)
        {

            #region - qy -
            string selectQy = @"SELECT
                                  `t_uaid`,
                                  `t_userid`,
                                  `t_username`,
                                  `t_authorityid`,
                                  `t_authorityname`,
                                  `t_creater`,
                                  `t_createtime`,
                                  `t_updatetime`
                                FROM `zkmanagerdb`.`t_user_authority`
                                WHERE t_uaid=@t_uaid";
            #endregion

            #region - paras -
            MySqlParameter[] paras = {
                new MySqlParameter("@t_uaid",t_uaid.Value)

            };
            #endregion



            MySqlDataReader reader = DbHelperMySql.ExecuteReader(DbHelperMySql.connectionStringManager, CommandType.Text, selectQy, paras);
            Model.t_user_authority tModel = ConvertToModel(reader);

            return tModel;
        }
        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Model.t_user_authority ConvertToModel(MySqlDataReader reader)
        {
            Model.t_user_authority traModel = new Model.t_user_authority();

            try
            {
                while (reader.Read())
                {

                    traModel.T_UaID = Convert.ToInt32(reader["t_uaid"]);
                    traModel.T_UserID = Convert.ToInt32(reader["t_userid"]);
                    traModel.T_UserName = reader["t_username"].ToString();
                    traModel.T_AuthorityID = Convert.ToInt32(reader["t_authorityid"]);
                    traModel.T_AuthorityName = reader["t_authorityname"].ToString();
                    traModel.T_Creater = reader["t_creater"].ToString();
                    traModel.T_CreateTime = Convert.ToDateTime(reader["t_createtime"]);
                    traModel.T_UpdateTime = Convert.ToDateTime(reader["t_updatetime"]);

                }
            }
            catch (Exception ex)
            {
            }
            return traModel;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? t_uaid)
        {
            return false;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount()
        {
            string cmdText = string.Format("SELECT COUNT(*)  FROM t_user_authority");
            return Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText));

        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<ZK.SchoolManagerPro.Model.t_user_authority> GetList()
        {

            return null;
        }
    }
}