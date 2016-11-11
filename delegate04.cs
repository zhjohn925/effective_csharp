// A delegate is an object that knows how to call methods

using System;


class Util {

  //this method takes a delegate parameter
  public static void Transform<T> (T[] values, Func<T,T> transformer) {
    for (int i=0; i<values.Length; i++) {
      values[i] = transformer (values[i]);
    }
  }

}

class Test {
  public static void Main() {
    int[] values = {1, 2, 3};
    Util.Transform(values, Square);
    foreach (int x in values) {
      Console.Write(x + " ");
    }
    Console.Write("\n");
  }

  static int Square(int x) { return x*x; }
}

