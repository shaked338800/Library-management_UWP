using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ItemCollection items = new ItemCollection();
        [TestMethod]
        public void TestAdd() //בודקת שיש את הפלט הרצוי
        {
            DateTime date = DateTime.Now;
            items.Add(new Book(CategoriesB.Horror, "1234567891334", "a", 25, 100, date, "aa", "aaa", "aaaa"));
            Assert.IsTrue(items.Counter > 0);
        }
        [TestMethod]
        public void TestGenreBook()
        {
            bool[] test = new bool[13];
            test[1] = true;
            test[2] = true;
            CategoriesB categories = items.CreateGenreEnumBook(test);
            Assert.IsTrue((CategoriesB.Adventure | CategoriesB.Action).CompareTo(categories) == 0);
        }
        [TestMethod]
        public void TestGenreJournal()
        {
            bool[] test = new bool[13];
            test[1] = true;
            test[2] = true;
            CategoriesJ categories = items.CreateGenreEnumJournal(test);
            Assert.IsTrue((CategoriesJ.CookingBook | CategoriesJ.Comics).CompareTo(categories) == 0);
        }
        [TestMethod]
        public void TestReplace()// בודק שהםונקצייה באמת מבצעת החלהפ בין האובייקטים
        {
            DateTime date = DateTime.Now;
            Book book = new Book(CategoriesB.Horror, "1234567891334", "b", 25, 100, date, "aa", "aaa", "aaaa");
            items.Add(new Book(CategoriesB.Horror, "1234567891334", "a", 25, 100, date, "aa", "aaa", "aaaa"));
            items.Replace("1234567891334", book);
            Assert.IsTrue(items["1234567891334"][0].Name == "b");
        }
    }
}
