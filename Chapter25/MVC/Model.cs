/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Model {

	private int i = 0;

	private String[] messages = { "Eat right, get plenty of rest, and exercise daily.",
						          "Make love not war.",
						          "Carpe Diem!",
						          "Eat your vegatables.",
						          "Brush and floss your teeth three times daily.",
						          "A penny saved is a penny earned.",
						          "What you do today prepares you for tomorrow.",
						          "All work and no play makes Jack a dull boy.", };



	public String GetMessage(){
	  if(i++ == (messages.Length-1)) i = 0;
	  return messages[i];
    }

} // end Model class