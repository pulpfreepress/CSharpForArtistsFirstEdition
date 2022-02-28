/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;

public class ConvertToArrayDemo {
	public static void Main(){
		String[] names = { "Rick",
		                   "Sally",
		                   "Joe",
		                   "Bob",
		                   "Steve" };
		                   
		SortedDictionary<String, String> quotes = new SortedDictionary<String, String>();
		
		quotes.Add(names[0], "How Do You Do?");
		quotes.Add(names[1], "When are we going home?");
		quotes.Add(names[2], "I said go faster, man!");
		quotes.Add(names[3], "Turn now! Nowww!");
		quotes.Add(names[4], "The rain in Spain falls mainly on the plain.");
		
		KeyValuePair<String, String>[] quote_array = new KeyValuePair<String, String>[quotes.Count];
		quotes.CopyTo(quote_array, 0);
		
		for(int i = 0; i<quote_array.Length; i++){
			Console.WriteLine(quote_array[i].Key + " said: \"" + quote_array[i].Value + "\"" );
		}
		
	}// end Main()
} // end ConvertToArrayDemo class