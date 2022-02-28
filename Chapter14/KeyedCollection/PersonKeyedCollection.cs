/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.ObjectModel;

public class PersonKeyedCollection : KeyedCollection<String, Person> {
	
	public PersonKeyedCollection():base(){ }
	
	protected override String GetKeyForItem(Person person){
		return person.BirthDay.ToString();
	}
}