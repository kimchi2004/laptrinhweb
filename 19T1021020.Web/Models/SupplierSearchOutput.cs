﻿using _19T1021020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021020.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm nhà cung cấp dưới dạng phân trang
    /// </summary>
    public class SupplierSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// Danh sách nhà cung cấp
        /// </summary>
        public List<Supplier> Data { get; set; }
    }
}