﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using _19T1021020.DomainModels;
using Newtonsoft.Json;


namespace _19T1021020.Web.Codes
{
    /// <summary>
    /// 
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? DmyStringToDateTime(string date, string format = "dd/MM/yyyy")
        {
            try { return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture); }
            catch (Exception e) { return null; }
        }
        /// <summary>
        ///     Convert Cookie to UserAccount
        /// </summary>
        /// <param name="cookie"> Cookie </param>
        /// <returns> UserAccount </returns>
        public static UserAccount CookieToUserAccount(string cookie)
        {
            return JsonConvert.DeserializeObject<UserAccount>(cookie);
        }

    }
}