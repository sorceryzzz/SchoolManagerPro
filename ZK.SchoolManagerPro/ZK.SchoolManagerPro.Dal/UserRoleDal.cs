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
    /// 数据访问类 UserRoleDal
    /// <summary>
    public partial class UserRoleDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(t_user_role urModel)
        {
            bool rltBool = false;

            #region - sql -
            string inserUserSql = @"INSERT INTO `zkmanagerdb`.`t_user_role`
                                                (`t_urid`,
                                                 `t_userid`,
                                                 `t_roleid`,
                                                 `t_creater`,
                                                 `t_createTime`,
                                                 `t_updateTime`)
                                    VALUES (@t_urid,
                                            @t_userid,
                                            @t_roleid,
                                            @t_creater,
                                            @t_createTime,
                                            @t_updateTime); ";
            #endregion

            #region - paras -
            MySqlParameter[] paras =
            {
               new MySqlParameter("@t_urid",urModel.T_UsrID),
               new MySqlParameter("@t_userid",urModel.T_UserID),
               new MySqlParameter("@t_roleid",urModel.T_RoleID),
               new MySqlParameter("@t_creater",urModel.T_Creater),
               new MySqlParameter("@t_createTime",urModel.T_CreateTime),
               new MySqlParameter("@t_updateTime",urModel.T_UpdateTime)
           };
            #endregion

            #region - excute -
            try
            {
                //记录查询
                rltBool = DbHelperMySql.ExecuteNonQuery(CommandType.Text, DbHelperMySql.connectionStringManager, inserUserSql, paras);


            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion

            return rltBool ? 1 : -1;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(t_user_role urModel)
        {
            bool rltBool = false;
            #region - sql -
            string inserUserSql = @"UPDATE `zkmanagerdb`.`t_user_role`
                                    SET 
                                      `t_userid` = @t_userid,
                                      `t_roleid` = @t_roleid,
                                      `t_creater` =  @t_creater,
                                      `t_createTime` =  @t_createTime,
                                      `t_updateTime` = @t_updateTime
                                    WHERE `t_urid` = @t_urid,;     ";
            #endregion

            #region - paras -
            MySqlParameter[] paras =
            {
               new MySqlParameter("@t_urid",urModel.T_UsrID),
               new MySqlParameter("@t_userid",urModel.T_UserID),
               new MySqlParameter("@t_roleid",urModel.T_RoleID),
               new MySqlParameter("@t_creater",urModel.T_Creater),
               new MySqlParameter("@t_createTime",urModel.T_CreateTime),
               new MySqlParameter("@t_updateTime",urModel.T_UpdateTime)
           };
            #endregion

            #region - excute -
            try
            {
                //记录查询
                rltBool = DbHelperMySql.ExecuteNonQuery(CommandType.Text, DbHelperMySql.connectionStringManager, inserUserSql, paras);


            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion

            return rltBool ? 1 : -1;



        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? t_urid)
        {
            bool rltBool = false;
            #region - sql -
            string inserUserSql = @"DELETE
                                    FROM `zkmanagerdb`.`t_user_role`
                                    WHERE `t_urid` = @t_urid;";
            #endregion

            #region - paras -
            MySqlParameter[] paras =
            {
               new MySqlParameter("@t_urid",t_urid),
           };
            #endregion

            #region - excute -
            try
            {
                //记录查询
                rltBool = DbHelperMySql.ExecuteNonQuery(CommandType.Text, DbHelperMySql.connectionStringManager, inserUserSql, paras);


            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion

            return rltBool ? 1 : -1;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZK.SchoolManagerPro.Model.t_user_role GetModel(int? t_urid)
        {
            return null;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? t_urid)
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
        public List<ZK.SchoolManagerPro.Model.t_user_role> GetList()
        {
            return null;
        }
    }
}