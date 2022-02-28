/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PeopleManager {
  // private fields
  private Person[] people_array;
  int index = 0;
  
  // overloaded constructor
  public PeopleManager(int length){
    people_array = new Person[length];
  }
  
  // default constructor
  public PeopleManager():this(10){ }
  
  
  public void AddPerson(String firstName, String middleName, String lastName,
                        Person.Sex gender, int dob_year, int dob_month, int dob_day){
    if(index >= people_array.Length){
       index = 0;
    }
    if(people_array[index] == null){
      people_array[index++] = new Person(firstName, middleName, lastName, gender,
                                          new DateTime(dob_year, dob_month, dob_day));
    }
  } // end method
  
  
  public void ListPeople(){
    for(int i = 0; i<people_array.Length; i++){
      if(people_array[i] != null){
        Console.WriteLine(people_array[i]);
      }
    }
  } // end method
  
  
  public void DeletePersonAtIndex(int index){
    if(!(index < 0) || (index >= people_array.Length)){
      people_array[index] = null;
      this.index = index;
    }
  }
  
  
  public void InsertPersonAtIndex( int index, String firstName, String middleName, 
                                   String lastName, Person.Sex gender, int dob_year, 
                                   int dob_month, int dob_day){
      if(!(index < 0) || (index >= people_array.Length)){
        this.index = index;
        people_array[this.index++] = new Person(firstName, middleName, lastName, gender,
                                          new DateTime(dob_year, dob_month, dob_day));
      }                               
   }
  

} // end PeopleManager class