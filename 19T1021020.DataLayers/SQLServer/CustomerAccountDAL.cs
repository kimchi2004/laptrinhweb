using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021020.DomainModels;


namespace _19T1021020.DataLayers.SQLServer
{
    /// <summary>
    /// Các phép xử lý dữ liệu cho tài khoản khách hàng
    /// </summary>
    public class CustomerAccountDal : _BaseDAL, IUserAccountDal
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerAccountDal(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        public UserAccount Authenticate(string userName, string password)
        {
            UserAccount userAccount = null;

            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT CustomerID, CustomerName, Email FROM Customers WHERE Email = @Email AND Password = @Password ";
                sqlCommand.Parameters.AddWithValue("@Email", userName);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.CommandType = CommandType.Text;

                using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        userAccount = new UserAccount
                        {
                            Email = reader["Email"].ToString(),
                            FullName = reader["CustomerName"].ToString(),
                            UserId = reader["CustomerID"].ToString(),
                            Password = password,
                            UserName = reader["Email"].ToString(),
                            GroupNames = "",
                            Photo = ""
                        };

                    reader.Close();
                }
                connection.Close();
            }

            return userAccount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"> Username </param>
        /// <param name="oldPassword"> Old password </param>
        /// <param name="newPassword"> New password </param>
        /// <returns></returns>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            bool result;

            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Customers SET Password = @NewPassword WHERE Email = @Email AND Password = @OldPassword";
                sqlCommand.Parameters.AddWithValue("@Email", userName);
                sqlCommand.Parameters.AddWithValue("@OldPassword", oldPassword);
                sqlCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                sqlCommand.CommandType = CommandType.Text;

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;
        }
    }

}
