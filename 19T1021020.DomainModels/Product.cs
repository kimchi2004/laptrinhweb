using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021020.DomainModels
{
    /// <summary>
    /// Mặt hàng
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Mã hàng
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Tên hàng
        /// </summary>
        public String ProductName { get; set; }
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// Mã loại hàng
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Đơn vị
        /// </summary>
        public String Unit { get; set; }
        /// <summary>
        /// Giá
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ảnh
        /// </summary>
        public String Photo { get; set; }
    }
}
