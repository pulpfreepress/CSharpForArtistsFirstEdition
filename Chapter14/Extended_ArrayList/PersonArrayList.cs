/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;

public class PersonArrayList : ArrayList {
	
	public PersonArrayList():base(){}
	
	
	public new Person this[int index]{
		get { return (Person) base[index];}
		
		set { base[index] = (Person) value; }
	}
	
	public override int Add(object o){
		return base.Add((Person)o);
	}
	
	
}