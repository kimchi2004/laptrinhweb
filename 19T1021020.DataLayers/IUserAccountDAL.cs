using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021020.DomainModels;

namespace _19T1021020.DataLayers
{
    public interface IUserAccountDal
    {
        /// <summary>
        /// Định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản người dùng
        /// </summary>
        /// <param name="userName"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns> </returns>
        UserAccount Authenticate(string userName, string password);

        /// <summary>
        /// Đổi mật khẩu của nhân viên
        /// </summary>
        /// <param name="userName"> Username </param>
        /// <param name="oldPassword"> Old password </param>
        /// <param name="newPassword"> New password </param>
        /// <returns> </returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

}
