/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

  public class EmployeeFactory : IEmployeeFactory {

    public IEmployee GetNewSalariedEmployee(String f_name, String m_name, String l_name, Sex gender,  
                                            DateTime birthday, String employee_number){
         return new SalariedEmployee(f_name, m_name, l_name, gender, birthday, employee_number);                       
    }
     
    public IEmployee GetNewHourlyEmployee(String f_name, String m_name, String l_name, Sex gender,  
                                          DateTime birthday, String employee_number){
         return new HourlyEmployee(f_name, m_name, l_name, gender, birthday,  employee_number);                       
    }
  } // end EmployeeFactory class definition
