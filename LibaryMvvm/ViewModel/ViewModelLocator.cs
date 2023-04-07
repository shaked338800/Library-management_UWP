/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LibaryMvvm"
                           x:Key="Locator" />
  </Application.Resources>
  
In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"


*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Models;

namespace LibaryMvvm.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ItemCollection>();//Logic
            SimpleIoc.Default.Register<ReportViewModel>();//View Model
            SimpleIoc.Default.Register<EditViewModel>();//View Model
            SimpleIoc.Default.Register<AddReadingProduct>();//View Model
        }
        public ReportViewModel Report//Instant to view Report
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReportViewModel>();
            }
        }
        public EditViewModel Edit//Instant to view Edit
        {
            get
            {
              return ServiceLocator.Current.GetInstance<EditViewModel>();
            }
        }
        public AddReadingProduct ReadingProduct//Instant to view AddReadingProductView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddReadingProduct>();
            }
        }

    }
}