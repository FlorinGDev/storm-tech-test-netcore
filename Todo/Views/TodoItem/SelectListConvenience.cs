using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Todo.Data;
using Todo.Data.Entities;

namespace Todo.Views.TodoItem
{
    public static class SelectListConvenience
    {
        public static readonly SelectListItem[] ImportanceSelectListItems =
        {
            new SelectListItem {Text = "High", Value = Importance.High.ToString()},
            new SelectListItem {Text = "Medium", Value = Importance.Medium.ToString()},
            new SelectListItem {Text = "Low", Value = Importance.Low.ToString()},
        };

        public static List<SelectListItem> UserSelectListItems(this ApplicationDbContext dbContext)
        {
            return dbContext.Users.Select(u => new SelectListItem { Text = u.UserName, Value = u.Id }).ToList();
        }

        public static List<SelectListItem> RankNumbers(this IEnumerable<int> rangeOfNumbers)
        {
            return rangeOfNumbers.Select(u => new SelectListItem { Text = u.ToString(), Value = u.ToString() }).ToList();
        }
    }
}