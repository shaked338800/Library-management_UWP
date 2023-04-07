using Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Models
{
    public class ItemCollection : IEnumerable
    {
        private List<Item> items = new List<Item>();
        int counter = 0;
        public int Counter { get => counter; private set => counter = value; }
        public ItemCollection()
        {
            var book1 = new Book(CategoriesB.Comics | CategoriesB.Comedy, "1425367485111", "diary of a wimpy kid",  25, 180, new DateTime(2007, 04, 1), "Life of a wimpy kid", "1", "Jeff Kinney");
            var book2 = new Book(CategoriesB.Comics | CategoriesB.Comedy, "1427658932154", "diary of a wimpy kid",  25, 180, new DateTime(2009,01,1), "The Last Straw", "3", "Jeff Kinney");
            var book3 = new Book(CategoriesB.Comics | CategoriesB.Comedy, "1427466485111", "diary of a wimpy kid ", 25, 180, new DateTime(2009, 10, 12), "summer-vaction", "4", "Jeff Kinney");
            var book4 = new Book(CategoriesB.Comics | CategoriesB.Comedy, "1427466485113", "diary of a wimpy kid ", 25, 180, new DateTime(2002, 02, 1), "rodrick rules", "2", "Jeff Kinney");
            var book5 = new Book(CategoriesB.Comics | CategoriesB.Comedy, "1427466485114", "diary of a wimpy kid ", 25, 180, new DateTime(2010, 11, 1), "The Ugly Truth", "5", "Jeff Kinney");
            var Journal1 = new Journal(CategoriesJ.CookingBook, "1478523698741", "Liza the chaf", 5, 40, new DateTime(2018, 01, 29), "Desserts", "Limitd");
            items.Add(book1);
            items.Add(book2);
            items.Add(book3);
            items.Add(book4);
            items.Add(book5);
            items.Add(Journal1);
        }
        public List<Item> this[string parameter]
        {
            get
            {
                if (parameter == String.Empty || parameter == null) throw new KeyNotFoundException();
                List<Item> indexerList = new List<Item>();
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Serial == parameter || items[i].Name.ToLower() == parameter.ToLower() || items[i].Type.ToLower() == parameter.ToLower() || items[i].Discount.ToString() == parameter)
                    {
                        indexerList.Add(items[i]);
                    }
                }
                return indexerList;
            }
        }
        public CategoriesB CreateGenreEnumBook(bool[] array) //לפי מה שהמשתמש בחר ומוסיף קטגוריות לפי מיקום viewModel-לוקח את המערך הבוליאני מה 
        {
            CategoriesB genres = new CategoriesB();
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i]) genres |= (CategoriesB)(Math.Pow(2, i));
            }
            return genres;
        }
        public CategoriesJ CreateGenreEnumJournal(bool[] array)// של קטגוריות שונות בגלל שזה ג'ורנאלEunm אותו דבר פה אבל עם 
        {
            CategoriesJ genres = new CategoriesJ();
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i]) genres |= (CategoriesJ)(Math.Pow(2, i));
            }
            return genres;
        }
        public void Add(Item item)//  מוסיפה פריט למאגר לאחר בדיקה סוג הפריט,מספר סידורי,הנחה הגבוהה
        {
            if (items.Count == 0) { items.Add(item); counter++; };
            bool check = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (item.Type == items[i].Type) //book == book
                {
                    if (items[i].Serial == item.Serial)
                    {
                        items[i].Amount++;
                        check = true;
                        break;
                    }
                    if (item.Categories.CompareTo(items[i].Categories) == 0)
                    {
                        if (item.Discount > items[i].Discount)
                            items[i].Discount = item.Discount;
                        else
                            item.Discount = items[i].Discount;
                    }
                }
            }
            if (!check)
            {
                items.Add(item);
                counter++;
            }
        }
        public void Replace(string serial, Item updateItem) //בודקת אם המספר סידורי נכון, אם כן ניתן לעדכן נתונים אחרים והפונקצייה תחליף את הנתונים הישנים בחדשים
        {
            foreach (var item in items)
            {
                if (item.Type == updateItem.Type)
                {
                    if (item.Serial == serial)
                    {
                        items.Remove(item);
                        items.Add(updateItem);
                        return;
                    }
                }
            }
            throw new KeyNotFoundException(); //אם לא קיים ספר עם מס סידורי כזה ,תזרוק אקספשיין
        }
        public IEnumerator<Item> GetEnumerator() // ישום אינטרפייס בשביל לעבור בפוראיצ על האיטם קולקשין
        {
            foreach (Item item in items)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
