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
	InterfaceType t1 = InterfaceTypeFactory.NewObjectByClassName("ClassA");
	InterfaceType t2 = InterfaceTypeFactory.NewObjectByClassName("ClassB");
	InterfaceType t3 = InterfaceTypeFactory.NewObjectByClassName("ClassC");

	Console.WriteLine(t1.Message);
	Console.WriteLine(t2.Message);
	Console.WriteLine(t3.Message);
  }
}