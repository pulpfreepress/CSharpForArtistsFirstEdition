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
  public interface IEmployeeFactory {
    IEmployee GetNewSalariedEmployee(String f_name, String m_name, String l_name,Sex gender,  
                                     DateTime birthday, String employee_number);
    IEmployee GetNewHourlyEmployee(String f_name, String m_name, String l_name, Sex gender, 
                                   DateTime birthday, String employee_number);
  }
} // end namespace