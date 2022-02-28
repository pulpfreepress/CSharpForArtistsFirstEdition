/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MessagePrinter:IMessagePrinter {	
  private String _message;
  
  public String Message {
     get { return _message; }
     set { _message = value; }
  }
  
  public MessagePrinter(String message){
    Message = message;
    Console.WriteLine("MessagePrinter object created...");
  }
  
  public MessagePrinter():this("Default MessagePrinter message"){ }
  
  public void PrintMessage(){
    Console.WriteLine("MessagePrinter PrintMessage(): " + Message);
  }
}