using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Enums;

namespace Bdikut
{
    internal class Program
    {
        static ItemCollection _items = new ItemCollection();
        static void Main(string[] args)
        {
            AddBooks();
            List<Item> list = _items["1234567891234"];
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        public static void AddBooks()
        {
            //DateTime dateTime = new DateTime(1994, 11, 25);
            //_items.Add(new Book(CategoriesB.Comics|CategoriesB.Classics, "1234567891234", "superman", 40, 50000, dateTime, 1, "Marvel", "Original"));
            //_items.Add(new Book(CategoriesB.Comics, "1234567891234", "superman", 40, 50000, dateTime, 1, "Marvel", "New"));
            //_items.Add(new Book(CategoriesB.Comics, "1234567891235", "Thor", 40, 50000, dateTime, 1, "Marvel", "Special"));
            //_items.Add(new Book(CategoriesB.Comics, "1234567891236", "Spiderman", 40, 50000, dateTime, 1, "Marvel", "Special"));
            //_items.Add(new Book(CategoriesB.Comics, "1234567891237", "Wonderwoman", 40, 50000, dateTime, 1, "Marvel", "Special"));
            //_items.Add(new Journal(CategoriesJ.Comics, "1234567891237", "Wonderwoman", 40, 50000, dateTime, 1, "Marvel", "Special"));
        }
    }
}
