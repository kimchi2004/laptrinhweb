using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021020.BusinessLayers;
using _19T1021020.DomainModels;

namespace _19T1021020.Web.Codes
{
    /// <summary>
    /// Một lớp là static, yêu cầu các biến hàm trong đó phải là static
    /// Cung cấp một số hàm tiện ích liên quan đến SelectList
    /// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns>List Of Countries</returns>
        public static List<SelectListItem> Countries()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = " -- Chọn quốc gia -- ",
                    Value = ""
                }
            };

            list.AddRange(CommonDataService.ListOfCountries()
                              .Select(country => new SelectListItem
                              {
                                  Text = country.CountryName,
                                  Value = country.CountryName
                              }));

            return list;
        }

        /// <summary>
        /// Lấy danh sách Loại hàng
        /// </summary>
        /// <returns> List Of Categories </returns>
        public static List<SelectListItem> Categories()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = " -- Chọn loại hàng -- ",
                    Value = "0"
                }
            };

            list.AddRange(CommonDataService.ListOfCategories(0, 0, "", out _)
                              .Select(category => new SelectListItem
                              {
                                  Text = category.CategoryName,
                                  Value = category.CategoryID.ToString()
                              }));

            return list;
        }

        /// <summary>
        /// Lấy danh sách nhà cung cấp
        /// </summary>
        /// <returns>List Of Suppliers</returns>
        public static List<SelectListItem> Suppliers()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = " -- Chọn nhà cung cấp -- ",
                    Value = "0"
                }
            };

            list.AddRange(CommonDataService.ListOfSuppliers(0, 0, "", out _)
                              .Select(supplier => new SelectListItem
                              {
                                  Text = supplier.SupplierName,
                                  Value = supplier.SupplierID.ToString()
                              }));

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Status()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "-99",
                Text = "--Tất cả trạng thái--"
            });
            foreach (var item in OrderService.getListOrderStatus())
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Status.ToString(),
                    Text = item.Description
                });
            }
            return list;
        }
    }
}