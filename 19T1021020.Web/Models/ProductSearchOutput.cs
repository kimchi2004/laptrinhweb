using _19T1021020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021020.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm mặt hàng dưới dạng phân trang
    /// </summary>
    public class ProductSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách mặt hàng
        /// </summary>
        public List<Product> Data { get; set; }

        /// <summary>
        /// Mã loại hàng
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// From
        /// </summary>
        public int From => (Page - 1) * PageSize + 1;

        /// <summary>
        /// To
        /// </summary>
        public int To => (Page - 1) * PageSize + Data.Count;

    }
}