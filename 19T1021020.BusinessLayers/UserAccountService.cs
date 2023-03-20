using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021020.DomainModels;
using System.Web.Configuration;
using _19T1021020.DataLayers;
using _19T1021020.DataLayers.SQLServer;


namespace _19T1021020.BusinessLayers
{
    /// <summary>
    /// Các nghiệp vụ quản lý tài khoản người dùng
    /// </summary>
    public static class UserAccountService
    {
        private static readonly IUserAccountDal EmployeeAccountDb;
        private static readonly IUserAccountDal CustomerAccountDb;

        /// <summary>
        /// Constructor of UserAccountService
        /// </summary>
        static UserAccountService()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            EmployeeAccountDb = new EmployeeAccountDal(connectionString);
            CustomerAccountDb = new CustomerAccountDal(connectionString);
        }

        /// <summary>
        /// Kiểm tra tài khoản và mật khẩu đăng nhập
        /// </summary>
        /// <param name="type"> Account type </param>
        /// <param name="userName"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns> </returns>
        public static UserAccount Authenticate(AccountTypes type, string userName, string password)
        {
            return type == AccountTypes.Employee ? EmployeeAccountDb.Authenticate(userName, password) : CustomerAccountDb.Authenticate(userName, password);
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="type"> Account type </param>
        /// <param name="userName"> Username </param>
        /// <param name="oldPassword"> Old password </param>
        /// <param name="newPassword"> New password </param>
        /// <returns> </returns>
        public static bool ChangePassword(AccountTypes type, string userName, string oldPassword, string newPassword)
        {
            return type == AccountTypes.Employee ? EmployeeAccountDb.ChangePassword(userName, oldPassword, newPassword) : CustomerAccountDb.ChangePassword(userName, oldPassword, newPassword);
        }
    }

}
