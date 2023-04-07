using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibaryMvvm.Interfaces;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LibaryMvvm.ViewModel
{
    public class EditViewModel : ViewModelBase
    {
        ItemCollection itemCollection;
        IvalidationImplementation validationImplementation = new IvalidationImplementation();
        private string serial;
        private string author;
        private string name;
        private int discount;
        private double price;
        private string edition;
        private string title;
        private bool[] categories = new bool[13];
        private DateTime dateTime = DateTime.Now;
        private bool book;
        private bool journal;
        public bool Book { get => book; set => Set(ref book, value); }
        public bool Journal { get => journal; set => Set(ref journal, value); }

        public string Authuor { get => author; set => Set(ref author, value); }
        public DateTime DateTime { get => dateTime; set => Set(ref dateTime, value); }
        public string Edition { get => edition; set => Set(ref edition, value); }
        public string Title { get => title; set => Set(ref title, value); }
        public string Serial { get => serial; set => Set(ref serial, value); }
        public string Name { get => name; set => Set(ref name, value); }
        public int Discount { get => discount; set => Set(ref discount, value); }
        public double Price { get => price; set => Set(ref price, value); }
        public RelayCommand EditItemCommend { get; set; }
        public bool[] Categories { get => categories; set => Set(ref categories, value); }
        public EditViewModel(ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            EditItemCommend = new RelayCommand(EditItem);
        }
        public void EditItem()
        {
            try
            {
                validationImplementation.ValidIsCheck(Categories);
                validationImplementation.ValidInputString(serial, serial);
                validationImplementation.ValidInputString(name, serial);
                validationImplementation.ValidInputString(title, serial);
                validationImplementation.ValidInputString(edition, serial);
                validationImplementation.ValidInputNumbers(price);
                if (book)
                {
                    validationImplementation.ValidInputString(author, serial);
                    CategoriesB categoriesB = itemCollection.CreateGenreEnumBook(categories);
                    Book book = new Book(categoriesB, serial, name, discount, price, dateTime, title, edition, author);
                    itemCollection.Replace(serial, book);
                    MessageBox.Show("The book has been updated");
                }
                else if (journal)
                {
                    CategoriesJ categoriesJ = itemCollection.CreateGenreEnumJournal(categories);
                    Journal journal = new Journal(categoriesJ, serial, name, discount, price, dateTime, title, edition);
                    itemCollection.Replace(serial, journal);
                    MessageBox.Show("The Journal has been updated");
                }
            }
            catch (KeyNotFoundException kn)
            {
                MessageBox.Show("Worng isbn,The product does not exist");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error please check if all the details insert currectly");
            }
        }



    }
}
