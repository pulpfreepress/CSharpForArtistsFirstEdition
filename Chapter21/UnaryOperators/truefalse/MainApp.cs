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
    Console.WriteLine(mt.IntField);
    if(mt){
      Console.WriteLine("if statement evaluated to true. Value of IntField = " + mt.IntField);
    }else{
      Console.WriteLine("if statement evaluated to false. Value of IntField = " + mt.IntField);
    }
    mt = -mt;
    if(mt){
      Console.WriteLine("if statement evaluated to true. Value of IntField = " + mt.IntField);
    }else{
      Console.WriteLine("if statement evaluated to false. Value of IntField = " + mt.IntField);
    }
  }
}