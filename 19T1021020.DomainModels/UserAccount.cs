using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021020.DomainModels
{
    /// <summary>
    /// Tài khoản người dùng
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// Mã người dùng
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Tên nhóm
        /// </summary>
        public string GroupNames { get; set; }

        /// <summary>
        /// Ảnh người dùng
        /// </summary>
        public string Photo { get; set; }
    }

}
