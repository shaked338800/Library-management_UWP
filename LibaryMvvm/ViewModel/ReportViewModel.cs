using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace LibaryMvvm.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        string[] input = new string[4];
        internal ItemCollection itemCollection;
        private bool[] options = new bool[5];
        public static ObservableCollection<Item> allItems { get; set; }
        public bool[] Options { get => options; set => options = value; }
        public string[] Input { get => input; set => Set(ref input, value); }
        public RelayCommand FilterCommand { get; set; }
        public ReportViewModel(ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            allItems = new ObservableCollection<Item>();
            FilterCommand = new RelayCommand(Search);
        }
        public void Search()
        {
            List<Item> filterList = default;
            try
            {
                filterList = Checkoptions(options);
                allItems.Clear();
                foreach (Item item in filterList)
                {
                    allItems.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Please check that the fields you selected are filled in correctly");
            }
        }
        private List<Item> Checkoptions(bool[] options)
        {
            List<Item> filterList;
            List<Item> mainFilterList = null;
            for (int i = 0; i < Input.Length; i++)
            {
                if (options[4])
                {
                    mainFilterList = new List<Item>();
                    foreach(Item item in itemCollection)
                    {
                        mainFilterList.Add(item);
                    }
                    return mainFilterList;
                }
                if (options[i])
                {
                    filterList = itemCollection[input[i]];
                    if(mainFilterList == null)
                    {
                        mainFilterList = filterList;
                    }
                    else
                    {
                       mainFilterList = mainFilterList.Intersect(filterList).ToList();
                    }
                }
            }
            return mainFilterList;
        }
    }

}
