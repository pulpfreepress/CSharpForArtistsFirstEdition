/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class DefaultValues {
  public char c = '\u0000';
  public decimal d;
  
  
  static void Main(){
    DefaultValues dv = new DefaultValues();
    Console.WriteLine(dv.c);
    Console.WriteLine(dv.d);
  }
}