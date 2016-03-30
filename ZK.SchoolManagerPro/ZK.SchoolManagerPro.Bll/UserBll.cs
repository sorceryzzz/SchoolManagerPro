using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.SchoolManagerPro.Dal;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.Bll
{
    public class UserBll
    {
        UserDal urDal = new UserDal();

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>1 成功 -1 失败</returns>
        public int AddUser(User user)
        {
            return urDal.AddUser(user);
        }
    }
}
