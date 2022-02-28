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
  public class NewSalariedEmployeeCommand : BaseCommand {
    public override void Execute(){
      if(its_view != null){
        its_view.EnableHourlyFields(false);
        its_view.EnableSalaryFields(true);
        its_view.ClearInputFields();
        its_view.EnableSubmitButton(true);
        its_view.Mode = ViewMode.SALARIED;
        its_view.SetWindowTitleBasedOnMode();
      }
    } // end Execute() method
  } // end NewSalariedEmployeeCommand class definition
} // end namespace