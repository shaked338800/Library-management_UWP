using System;

namespace Models
{
    public abstract class Item
    {
        protected double price;
        internal int Amount { get; set; }
        internal double Price { get { return price * (1 - ((double)Discount / 100)); } set { price = value; } }
        internal string Type { get; set; }
        internal string Serial { get; set; }
        public string Name { get; set; }
        internal int Discount { get; set; }
        internal Enum Categories { get; set; }
        public Item(string serial, string name, int discount, double price)
        {
            Serial = serial;
            Name = name;
            Discount = discount;
            this.price = price;
        }
    }

}
