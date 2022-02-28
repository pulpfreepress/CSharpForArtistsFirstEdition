/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.Commands {
  public class SortEmployeesCommand : BaseCommand {
    public override void Execute(){
      if(its_model != null){
         its_model.SortEmployees();
         its_view.DisplayEmployeeInfo(its_model.GetAllEmployeesInfo());
      }
    } // end Execute() method
  } // end SortEmployeesCommand class definition
} // end namespace