/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class SecurityException : Exception {

    public SecurityException() : base("Security Exception") { }

    public SecurityException(String message) : base(message) { }

    public SecurityException(String message, Exception inner_exception) : base(message, inner_exception) { }
}