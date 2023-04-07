using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class ReadingProducts : Item
    {
        protected string title;
        internal string Edtion { get; set; }
        protected DateTime publishDate;
        public ReadingProducts
        (string isbn, string name, int discount, double price,DateTime publishDate,string title,string edtion)
         : base(isbn, name, discount, price)
        {
            this.title = title;
            Edtion = edtion;
            this.publishDate = publishDate;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nIsbn: {Serial}\nPublishDate: {publishDate}\nTitle: {title}\nEdition: {Edtion}\nCategories: {Categories}\nPrice:{price} \nPrice after discount: {Price}\nAmount: {Amount}";
        }
    }
}
