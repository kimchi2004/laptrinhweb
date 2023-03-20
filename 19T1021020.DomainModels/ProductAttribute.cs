﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021020.DomainModels
{
    /// <summary>
    /// Thuộc tính của mặt hàng
    /// </summary>
    public class ProductAttribute
    {
        ///<summary>
        /// Mã thuộc tính
        ///</summary>
        public long AttributeID { get; set; }
        ///<summary>
        /// Mã mặt hàng
        ///</summary>
        public int ProductID { get; set; }
        ///<summary>
        /// Tên thuộc tính
        ///</summary>
        public string AttributeName { get; set; }
        ///<summary>
        /// Giá trị thuộc tính
        ///</summary>
        public string AttributeValue { get; set; }
        ///<summary>
        /// Tứ tự hiển thị
        ///</summary>
        public int DisplayOrder { get; set; }
    }
}
