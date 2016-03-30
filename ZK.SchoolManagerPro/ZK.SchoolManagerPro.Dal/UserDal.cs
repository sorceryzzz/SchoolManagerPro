using Dinlun.GatewaySite.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.Dal
{
    public class UserDal
    {
        public UserDal()
        {

        }

        #region - method -

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>1 成功 -1 失败</returns>
        public int AddUser(User user)
        {
            bool rltBool = false;

            #region - sql -
            string inserUserSql =@"INSERT INTO `test`.`user`
                                          (
                                           `Name`,
                                           `Age`)
                                    VALUES(
                                            @Name,
                                            @Age); ";
            #endregion

            #region - paras -
            MySqlParameter[] paras =
            {
               new MySqlParameter("@Name",user.Name),
               new MySqlParameter("@Age",user.Age)
           };
            #endregion

            #region - excute -
            try
            {
                //记录查询
                rltBool = DbHelperMySql.ExecuteNonQuery(CommandType.Text,DbHelperMySql.connectionStringManager, inserUserSql, paras);

           
            }
            catch (Exception ex)
            {

                throw;
            }
            #endregion
            
            return rltBool?1:-1;
        }
        #endregion

    }
}
