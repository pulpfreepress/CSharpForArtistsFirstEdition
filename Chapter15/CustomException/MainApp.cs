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
  public static void Main() {
     SurrealistBank sb = new SurrealistBank();
     String input = "Go";
     while (!input.Equals("Quit")) {
       Console.Write("Please enter a name to lookup or 'Quit' to exit the program: ");
       input = Console.ReadLine();
       try {
           Console.WriteLine();
           Console.WriteLine(sb.LookUp(input));
        }catch (SurrealistNotFoundException snfe) {
           Console.WriteLine(snfe.Message);
         }
     }//end while
  }
}
