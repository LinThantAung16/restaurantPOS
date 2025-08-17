using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPOS.Shared
{
    public class DevCode
    {
        private readonly AppDbContext _db;
        public DevCode(AppDbContext db)
        {
            _db = db;
        }

        // Check existing name in the database
        public bool Exists<T>(Expression<Func<T, string>> columnSelector, string value) where T : class
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            return _db.Set<T>()
                      .Any(e => EF.Property<string>(e, ((MemberExpression)columnSelector.Body).Member.Name).ToLower()
                                == value.ToLower());
        }


        // Generate sequence number
        public int GetNextNumber<T>(Expression<Func<T, int>> columnSelector) where T : class
        {
            var maxValue = _db.Set<T>().Any()
                ? _db.Set<T>().Max(columnSelector)
                : 0;
            return maxValue + 1;
        }

        // Generate next sequence number (string, with prefix)
        public string GetNextCode<T>(Expression<Func<T, string>> columnSelector, string prefix, int numberLength) where T : class
        {
            var lastCode = _db.Set<T>()
                .Where(e => EF.Functions.Like(
                    EF.Property<string>(e, ((MemberExpression)columnSelector.Body).Member.Name),
                    prefix + "%"))
                .OrderByDescending(e => EF.Property<string>(e, ((MemberExpression)columnSelector.Body).Member.Name))
                .Select(columnSelector)
                .FirstOrDefault();

            int nextNum = 1;
            if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > prefix.Length)
            {
                int.TryParse(lastCode.Substring(prefix.Length), out nextNum);
                nextNum++;
            }

            return prefix + nextNum.ToString().PadLeft(numberLength, '0');
        }
    }
}
