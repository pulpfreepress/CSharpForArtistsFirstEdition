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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.Model { 
  public class Model : IModel {

    private List<IEmployee> _employee_list = null;
    private IEmployeeFactory _employee_factory = null;
    
    public Model(){
       _employee_list = new List<IEmployee>();
       _employee_factory = new EmployeeFactory();
    }

    public void AddEmployee(IEmployee employee){                               
      _employee_list.Add(employee);                                                                
    }

    public void EditEmployee(IEmployee employee, int index){
      _employee_list[index] = employee;                               
    }

    

    public String[] GetAllEmployeesInfo(){
      String[] emp_info = new String[_employee_list.Count];
      for(int i = 0; i<_employee_list.Count; i++){
       emp_info[i] = _employee_list[i].ToString();
      }
      return emp_info;
    }

    public IEmployee GetEmployeeByEmployeeNumber(String employee_number){
      IEmployee employee = null;
      foreach(IEmployee emp in _employee_list){
        employee = emp;
        if(employee.EmployeeNumber.Equals(employee_number)) break;
      }
       return employee;
    }
    
    public IEmployee GetEmployeeByIndex(int index){
      if((index < 0) || (index >= _employee_list.Count)){ // adjust index
         index = _employee_list.Count-1;    
      }
      if(_employee_list.Count > 0) {
        return _employee_list[index];
      } 
      return null;
    }

    public void SortEmployees(){
     _employee_list.Sort();
    }
    
    public void DeleteEmployeeByIndex(int index){
      if((index < 0) || (index >= _employee_list.Count)){ // adjust index if out of range
         index = _employee_list.Count-1;
      }
      if(_employee_list.Count > 0) {
          _employee_list.RemoveAt(index);
        }
    }
    
    public void SaveEmployeesToFile(String filename){
     if((filename == null) || (filename == String.Empty)){
        filename = "employees.dat";
     }
       FileStream fs = null;
       try {
         fs = new FileStream(filename, FileMode.Create);
         BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(fs, _employee_list);
       }catch(Exception e){
         Console.WriteLine(e);
       }finally{
         if(fs != null){
           fs.Close();
         }
       }
     
    } 
    
    public void LoadEmployeesFromFile(String filename){
      if((filename == null) || (filename == String.Empty)){
        filename = "employees.dat";
     }
      FileStream fs = null;
      try {
        fs = new FileStream(filename, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        _employee_list  = (List<IEmployee>)bf.Deserialize(fs);
      }catch(FileNotFoundException fnfe){
        Console.WriteLine("employees.dat file not found!");
      }catch(Exception ex){
        Console.WriteLine(ex);
      }finally{
        if(fs != null){
          fs.Close();
        }
      }
    }
  } // end Model class definition
} // namespace