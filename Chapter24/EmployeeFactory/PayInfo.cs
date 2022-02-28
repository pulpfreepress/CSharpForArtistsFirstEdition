/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

   [Serializable]
  public class PayInfo {
    // fields
    private double _salary = 0;
    private double _hours_worked = 0;
    private double _hourly_rate = 0;
    
    // properties
    public double Salary {
       get { return _salary; }
       set { _salary = value; }
    }  
    
    public double HoursWorked {
      get { return _hours_worked; }
      set { _hours_worked = value; }
    }
    
    public double HourlyRate {
      get { return _hourly_rate; }
      set { _hourly_rate = value; }
    }
    
    // constructors
    public PayInfo(){ }
    
    public PayInfo(double salary){
       _salary = salary;
    }
    public PayInfo(double hours_worked, double hourly_rate){
       _hours_worked = hours_worked;
       _hourly_rate = hourly_rate;
    }
  } // end PayInfo class definition
