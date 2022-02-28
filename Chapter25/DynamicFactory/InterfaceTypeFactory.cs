/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Reflection;

public class InterfaceTypeFactory {

  public static InterfaceType NewObjectByClassName(String classname) {
    Object o = null;
    try{
      Assembly assembly = Assembly.LoadFrom(classname + ".dll");
      foreach(Type t in assembly.GetTypes()){
        if(t.Name == classname){
          o = Activator.CreateInstance(t);
        }
      }
	  }catch(Exception e){
	     Console.WriteLine("Problem loading class or creating instance!");
	   }
    return (InterfaceType)o;
   }
} // end InterfaceTypeFactory class definition