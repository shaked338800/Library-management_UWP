﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibaryMvvm.Views
{
    /// <summary>
    /// Interaction logic for AddReadingProductView.xaml
    /// </summary>
    public partial class AddReadingProductView : UserControl
    {
        public AddReadingProductView()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); // מאפשר לכתוב בתוך הטקס בוקס רק מספרים
        private void LettersValidationTextBox(object sender, TextCompositionEventArgs e) //מאפשר לכתוב בתוך הטקסבוקס רק אותיות
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }
    }
}
