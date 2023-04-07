using Models.Enums;
using System;

namespace Models
{
    public sealed class Journal : ReadingProducts
    {
        public Journal(CategoriesJ categoriesJ, string isbn, string name, int discount, double price, DateTime printDate,
         string title, string edtion)
          : base(isbn, name, discount, price, printDate,title, edtion)
        {
            Categories = categoriesJ;
            Type = "Journal";
        }
        public override string ToString()
        {
            return $"Journal details:\n{base.ToString()}";
        }
    }
}
