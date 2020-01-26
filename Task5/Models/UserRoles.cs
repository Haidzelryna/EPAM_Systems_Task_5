using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task5.Models
{
    public class UserRoles
    {
        public int UserId { get; set; }

        public string RoleId { get; set; }

        //public SelectList DropDownList { get; set; }
    }

    //public class MyListTable
    //{
    //    public int Key { get; set; }

    //    public string Display { get; set; }
    //}

    //public static class MyExtensions
    //{
    //    public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
    //        where TEnum : struct, IComparable, IFormattable, IConvertible
    //    {
    //        var values = from TEnum e in Enum.GetValues(typeof(TEnum))
    //                     select new { Id = e, Name = e.ToString() };
    //        return new SelectList(values, "Id", "Name", enumObj);
    //    }
    //}
}