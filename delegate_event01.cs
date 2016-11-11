using System;

public class PriceChangedEventArgs : EventArgs
{
  public readonly decimal LastPrice;
  public readonly decimal NewPrice;

  public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
  {
    LastPrice = lastPrice;
    NewPrice = newPrice;
  }
}

public class Stock
{
  string symbol;
  decimal price;

  public Stock(string symbol) { this.symbol = symbol; }

  //define event delegate
  public event EventHandler<PriceChangedEventArgs> PriceChanged;

  protected virtual void OnPriceChanged (PriceChangedEventArgs e)
  {
    //when there is method is added to PriceChanged event delegate
    if (PriceChanged != null) {
       //invoke the method:
       //   stock_PriceChanged(object sender, PriceChangedEventArgs e)
       PriceChanged.Invoke(this, e);
    }
  }

  //getter and setter
  public decimal Price
  {
    get { return price; }
    set {
      if (price==value) return;
      decimal oldPrice = price;
      price = value;
      OnPriceChanged (new PriceChangedEventArgs(oldPrice, price));
    }
  }
}

class Test
{
  static void Main()
  {
    Stock stock = new Stock("THPW");
    stock.Price = 17.10M;
    //PriceChanged is a event delegate.
    //  Register with the PriceChanged Event by adding
    //  the method to event delegate
    stock.PriceChanged += stock_PriceChanged;
    stock.PriceChanged += stock_Decision;
    stock.Price = 31.59M;
    stock.Price = 32.59M;
  }

  static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
  {
    if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
      Console.WriteLine("Alert, 10% stock price increase!");
  }

  static void stock_Decision(object sender, PriceChangedEventArgs e)
  {
    if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
      Console.WriteLine("It is time to sell stock!");
    else
      Console.WriteLine("It is time to hold stock!");

  }
}
