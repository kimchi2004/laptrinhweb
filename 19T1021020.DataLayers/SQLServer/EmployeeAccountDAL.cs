using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021020.DomainModels;

namespace _19T1021020.DataLayers.SQLServer
{/// <summary>
 /// Các phép xử lý dữ liệu cho tài khoản nhân viên
 /// </summary>
    public class EmployeeAccountDal : _BaseDAL, IUserAccountDal
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeAccountDal(string connectionString) : base(connectionString)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns> </returns>
        public UserAccount Authenticate(string userName, string password)
        {
            UserAccount userAccount = null;

            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT EmployeeID, LastName, FirstName, Email, Photo FROM Employees WHERE Email = @Email AND Password = @Password ";
                sqlCommand.Parameters.AddWithValue("@Email", userName);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.CommandType = CommandType.Text;

                using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        userAccount = new UserAccount
                        {
                            Email = reader["Email"].ToString(),
                            FullName = reader["LastName"] + " " + reader["FirstName"],
                            UserId = reader["EmployeeID"].ToString(),
                            Password = password,
                            UserName = reader["Email"].ToString(),
                            GroupNames = "",
                            Photo = reader["Photo"].ToString()
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
        /// <returns> True if change password is successful, otherwise false </returns>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            bool result;

            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Employees SET Password = @NewPassword WHERE Email = @Email AND Password = @OldPassword";
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
