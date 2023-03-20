using _19T1021020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021020.Web.Models
{
    /// <summary>
    /// ProductEditModel
    /// </summary>
    public class ProductEditModel
    {
        /// <summary>
        /// Mặt hàng
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Thuộc tính mặt hàng
        /// </summary>
        public List<ProductAttribute> Attributes { get; set; }

        /// <summary>
        /// Ảnh minh họa
        /// </summary>
        public List<ProductPhoto> Photos { get; set; }

    }
}