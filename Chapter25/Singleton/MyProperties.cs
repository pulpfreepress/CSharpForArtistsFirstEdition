/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MyProperties : XMLProperties {

   // private fields
   private static MyProperties _props = null;
   
   
   //private constructor
   private MyProperties() { }
   
   private MyProperties(String filename):base(filename){ }
   
   
   
   // default GetInstance() method
   public static MyProperties GetInstance(){
     return MyProperties.GetInstance(XMLProperties.DEFAULT_PROPERTIES_FILENAME);
   }
   
   // GetInstance() method
   public static MyProperties GetInstance(String filename){
     if((filename == null) || (filename == String.Empty)){
       if(_props == null){
         _props = new MyProperties();
       }
     } else {
       if(_props == null){
         _props = new MyProperties(filename);
       }
     }
     return _props;
   }

}