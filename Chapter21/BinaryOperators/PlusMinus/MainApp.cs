/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
  public static void Main(){
    MyType mt = new MyType();
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("Should be 7:" + (mt++ + 2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("Should be 9:" + (++mt + 2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("Should be 4:" + (--mt - 2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("Should be 4:" + (mt-- - 2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("----------------------------");
    int i = 5;
    Console.WriteLine("i = " + i);
    Console.WriteLine("Should be 7:" + (i++ + 2));
    Console.WriteLine("i = " + i);
    Console.WriteLine("Should be 9:" + (++i + 2));
    Console.WriteLine("i = " + i);
    Console.WriteLine("Should be 4:" + (--i - 2));
    Console.WriteLine("i = " + i);
    Console.WriteLine("Should be 4:" + (i-- - 2));
    Console.WriteLine("i = " + i);  
    Console.WriteLine("-----------------------------");
    MyType mt2 = new MyType();
    Console.WriteLine("Should be 10:" + (mt + mt2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("mt2 = " + mt2);
    Console.WriteLine("Should be 0:" + (mt - mt2));
    Console.WriteLine("mt = " + mt);
    Console.WriteLine("mt2 = " + mt2);
  }
}