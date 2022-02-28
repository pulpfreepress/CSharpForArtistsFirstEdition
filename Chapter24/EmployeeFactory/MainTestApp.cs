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

public class MainTestApp {
  
    private IEmployeeFactory _employee_factory = null;
    private List<IEmployee> _employee_list = null;
    
    public MainTestApp(){
      _employee_factory = new EmployeeFactory();
      _employee_list = new List<IEmployee>();
    }
    
    public void CreateEmployees(){
      _employee_list.Add(_employee_factory.GetNewSalariedEmployee("Rick", "Warren", "Miller",
                                                                  Sex.MALE, new DateTime(1968, 2, 4),
                                                                  "0001"));
      _employee_list[0].PayInfo = new PayInfo(78000);
      _employee_list.Add(_employee_factory.GetNewHourlyEmployee("Coralie", "Sylvia", "Powell",
                                                                  Sex.FEMALE, new DateTime(1969, 4, 8),
                                                                  "0002"));
      _employee_list[1].PayInfo = new PayInfo(80, 57);
    }
    
    public void ListEmployees(){
      foreach(IEmployee e in _employee_list){
        Console.WriteLine(e);
      }
    }
    
    public static void Main(){
      MainTestApp mta = new MainTestApp();
      mta.CreateEmployees();
      mta._employee_list.Sort();
      mta.ListEmployees();
    } // end Main
} // end class definition