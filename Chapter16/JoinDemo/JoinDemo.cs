/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Threading;

public class JoinDemo {
  
  private const int COUNT = 100;
  
  public static void Run(object value){
    for(int i=0; i<COUNT; i++){
	  Console.Write(value);
	  Thread.Sleep(10);
	}
  }
  
  public static void Main(){
    Thread thread1 = new Thread(new ParameterizedThreadStart(Run)); // longhand way
	Thread thread2 = new Thread(Run); // shorthand way
	thread1.Start("Hello ");
	thread2.Start("World! ");
	for(int i = 0; i< 10; i++){
	  Console.Write("\n------- Main Thread Message --------");
	  if(i==1) thread2.Join();
	}
  }
}