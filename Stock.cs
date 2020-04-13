using System;

namespace pattern_observer_netcore
{
    public class Stock
    {
        public string Symbol { get; set; }
        public float Price { get; set; }

        public Stock(string symbol, float price)
        {
            Symbol = symbol;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var compare = (Stock)obj;
            if (compare != null && compare.Symbol == this.Symbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Stock{" +
              "symbol='" + Symbol + '\'' +
              ", price=" + Price +
              '}';
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Symbol, Price);
        }
    }
}