using _19T1021020.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021020.Web.Models
{
    /// <summary>
    /// OrderSearchOutput
    /// </summary>
    public class OrderSearchOutput : PaginationSearchOutput
    {
        public List<Order> Data { get; set; }
    }
}