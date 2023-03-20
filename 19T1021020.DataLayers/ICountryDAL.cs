using _19T1021020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021020.DataLayers
{
    /// <summary>
    /// Các chức năng xử lý dữ liệu cho quốc gia
    /// </summary>
    public interface ICountryDAL
    {
        /// <summary>
        /// Lấy danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        IList<Country> List();
    }
}
