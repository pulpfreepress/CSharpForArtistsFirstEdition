/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PeopleManagerApplication {
  public static void Main(){
    Person p1 = new Person("Ulysses", "S", "Grant", Person.Sex.MALE, new DateTime(1822, 04, 22));
    Console.WriteLine(p1);
  } // end Main
} // end class definition