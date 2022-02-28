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
  public abstract class Employee : IEmployee {
     private Person _person = null;
     private String  _employee_number = null;
     private PayInfo _payInfo = null;
     
     protected Employee(){
       _person = new Person();
     }
     
     protected Employee(String f_name, String m_name, String l_name, Sex gender, DateTime birthday, String employee_number){
        _person = new Person(f_name, m_name, l_name, gender, birthday );
        _employee_number = employee_number;
      } // end constructor
      
     public int Age { 
       get{ return _person.Age; } 
      }
     public String FullName { 
        get { return _person.FullName; }
     }
     public String FullNameAndAge { 
       get { return _person.FullNameAndAge; } 
     }
     public String FirstName { 
       get { return _person.FirstName; } 
       set { _person.FirstName = value; }
    }
     public String MiddleName { 
       get { return _person.MiddleName; }
       set { _person.MiddleName = value; }
     }
     public String LastName { 
       get { return _person.LastName; }
       set { _person.LastName = value; }
     }
     public Sex Gender { 
       get { return _person.Gender; } 
       set { _person.Gender = value; }
     }
     public String EmployeeNumber { 
        get { return _employee_number; } 
        set { _employee_number = value; }
     }
     public DateTime Birthday { 
       get { return _person.BirthDay; } 
       set { _person.BirthDay = value; } 
     }
     
     public PayInfo PayInfo { 
       get { return _payInfo; }
       set { _payInfo = value; }
     }
     
     // defer implementation of this property
     public abstract double Pay { get; } 
     
     public override String ToString(){
       return (_person.ToString() + " " + EmployeeNumber + " ");
     }
     
     public int CompareTo(IEmployee other){
       return this.ToString().CompareTo(other.ToString());
     }
  }  // end Employee class definition
} // namespace