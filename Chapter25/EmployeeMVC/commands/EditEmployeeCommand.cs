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
  public class EditEmployeeCommand : BaseCommand {

    public override void Execute(){
      if((its_model != null) && (its_view != null)){
         int index = its_view.SelectedLineNumber();
         Console.WriteLine(index);
         IEmployee employee = its_model.GetEmployeeByIndex(index);
         if(employee != null){
           its_view.EditingEmployee = employee;
           its_view.EnableSubmitButton(true);
           its_view.Mode = ViewMode.EDIT;
         }
      }
    } // end Execute() method
  } // end EditEmployeeCommand class definition
} // end namespace