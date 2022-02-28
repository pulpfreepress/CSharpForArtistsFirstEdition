/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Person {

  // private instance fields
  private String   _firstName;
  private String   _middleName;
  private String   _lastName;
  private String   _gender;
  private DateTime _birthday;


  public Person(String firstName, String middleName, String lastName, String gender, DateTime birthday){
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
  
  public String Gender {
    get { return _gender; }
    set { _gender = value; }
  }
  
  public DateTime BirthDay {
    get { return _birthday; }
    set { _birthday = value; }
  }

} // end Person class
