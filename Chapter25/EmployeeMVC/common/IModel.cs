/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;

namespace Com.PulpFreePress.Common {
  public interface IModel {
    void AddEmployee(IEmployee employee);

    void EditEmployee(IEmployee employee, int index);

    String[] GetAllEmployeesInfo();

    IEmployee GetEmployeeByEmployeeNumber(String employee_number);
    
    IEmployee GetEmployeeByIndex(int index);

    void SortEmployees();
    
    void DeleteEmployeeByIndex(int index);
    
    void SaveEmployeesToFile(String filename);
    
    void LoadEmployeesFromFile(String filename);

  } // end IModel interface definition
} // end namespace