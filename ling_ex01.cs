using System;
using System.Collections.Generic;
using System.Linq;

class LinqDemo {
  static void Main() {
    string[] names = {"Tom", "Dick", "Harry", "Jerry", "Mary", "Jay"};
    //using extension method:
    IEnumerable<string> filteredNames1 = System.Linq.Enumerable.Where(names, n => n.Length >= 4);
    //using lambda expression:
    IEnumerable<string> filteredNames2 = names.Where(n => n.Length >= 5);
    //using query expression:
    IEnumerable<string> filteredNames3 = from n in names
                                          where n.Contains("a")
                                          select n;
    foreach (string name in filteredNames1)
      Console.WriteLine(name);
    foreach (string name in filteredNames2)
      Console.WriteLine(name);
    foreach (string name in filteredNames3)
      Console.WriteLine(name);

    //Chaining query, fluent syntax
    IEnumerable<string> query = names
      .Where (n => n.Contains("a"))
      .OrderBy (n => n.Length)
      .Select (n => n.ToUpper());   //convert the results to uppercase

    foreach (string name in query)
      Console.WriteLine(name);

  }
}
