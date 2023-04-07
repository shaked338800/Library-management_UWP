using Models.Enums;
using System;

namespace Models
{
    public sealed class Book : ReadingProducts
    {
        private string authuor;
        public Book(CategoriesB category, string isbn, string name, int discount, double price
            , DateTime publishDate,string title, string edtion,string authuor)
            : base(isbn, name, discount, price, publishDate,title, edtion)
        {
            Type = "Book";
            Categories = category;
            this.authuor = authuor;
        }
        public override string ToString()
        {
            return $"Book details:\n{base.ToString()}\n Author:{authuor}";
        }
    }

}
