/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace Com.PulpFreePress.Common { 
  [Serializable]
  public class Person : IComparable<Person> {

    // private instance fields
    private String   _firstName;
    private String   _middleName;
    private String   _lastName;
    private Sex      _gender;       
    private DateTime _birthday;

    
    //private default constructor
    public Person(){}

    public Person(String firstName, String middleName, String lastName, 
                  Sex gender, DateTime birthday){
       FirstName = firstName;
       MiddleName = middleName;
       LastName = lastName;
       Gender = gender;
       BirthDay = birthday;
    }

    // public properties
    public String FirstName {
      get { return _firstName; }
      set { _firstName = value; }
    }
    
    public String MiddleName {
      get { return _middleName; }
      set { _middleName = value; }
    }
    
    public String LastName {
      get { return _lastName; }
      set { _lastName = value; }
    }
    
    public Sex Gender {
      get { return _gender; }
      set { _gender = value; }
    }
    
    public DateTime BirthDay {
      get { return _birthday; }
      set { _birthday = value; }
    }
    
    public int Age {
     get { 
	     int years = DateTime.Now.Year - _birthday.Year;
       int adjustment = 0;
	     if(DateTime.Now.Month < _birthday.Month){
         adjustment = 1;
       }else if((DateTime.Now.Month == _birthday.Month) && (DateTime.Now.Day < _birthday.Day)){
           adjustment = 1;
       } 
	   return years - adjustment;
	   }
   }
    
    public String FullName {
      get { return FirstName + " " + MiddleName + " " + LastName; }
    }
    
    public String FullNameAndAge {
      get { return FullName + " " + Age; } 
    }
    
    public override String ToString(){
      return FullName + ", " + Gender + ", " + Age;
    }
    
    public int CompareTo(Person other){
      return this.FullName.CompareTo(other.FullName);
    }

  } // end Person class
} // namespace