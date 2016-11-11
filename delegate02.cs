using System;

public delegate void ProgressReporter(int percentComplete);

public class Util {
  public static void HardWork (ProgressReporter p) {
    for (int i = 0; i<10; i++) {
      p(i*10);
      System.Threading.Thread.Sleep(100);
    }
  }
}

class Test {
  static void Main() {
    //Multicast delegate invokes two methods in sequence
    ProgressReporter p = WriteProgressToConsole;
    p += WriteProgressToFile;
    Util.HardWork(p);
  }

  static void WriteProgressToConsole(int percentComplete) {
    Console.WriteLine(percentComplete);
  }

  static void WriteProgressToFile(int percentComplete) {
    System.IO.File.WriteAllText("process.txt", percentComplete.ToString());
  }
}


