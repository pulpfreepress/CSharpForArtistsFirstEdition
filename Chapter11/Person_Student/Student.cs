/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Student:Person {
  private String _student_number;
  private String _major;
  
  public String StudentNumber {
    get { return _student_number; }
    set { _student_number = value; }
  }
  
  public String Major {
    get { return _major; }
    set { _major = value; }
  }
  
  public Student(String firstName, String middleName, String lastName, 
                 Sex gender, DateTime birthday, String studentNumber,
                 String major):base(firstName, middleName, lastName, gender, birthday) {
       StudentNumber = studentNumber;
       Major = major;
  }
  
  
  public override String ToString(){
    return (base.ToString() + " Student Number: " + StudentNumber + " Major: " + Major);
  }
	
} // end Student class definition