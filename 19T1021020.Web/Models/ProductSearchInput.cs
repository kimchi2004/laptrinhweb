using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021020.Web.Models
{
    /// <summary>
    /// ProductSearchInput
    /// </summary>
    public class ProductSearchInput : PaginationSearchInput
    {
        /// <summary>
        /// Mã loại hàng (Default: 0)
        /// </summary>
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// Mã nhà cung cấp (Default: 0)
        /// </summary>
        public int SupplierId { get; set; } = 0;
    }
}