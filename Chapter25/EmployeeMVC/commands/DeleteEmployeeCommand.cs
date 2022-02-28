/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace Com.PulpFreePress.Commands {
  public class DeleteEmployeeCommand : BaseCommand {

    public override void Execute(){
      if((its_model != null) && (its_view != null)){
         int index = its_view.SelectedLineNumber();
         Console.WriteLine(index);
         its_model.DeleteEmployeeByIndex(index);
         its_view.DisplayEmployeeInfo(its_model.GetAllEmployeesInfo());
         its_view.ClearInputFields();
       }
    } // end Execute() method
  } // end DeleteEmployeeCommand class definition
} // end namespace