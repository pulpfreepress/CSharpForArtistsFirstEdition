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
  public class NewHourlyEmployeeCommand : BaseCommand {
    public override void Execute(){
      if(its_view != null){
        its_view.EnableHourlyFields(true);
        its_view.EnableSalaryFields(false);
        its_view.ClearInputFields();
        its_view.EnableSubmitButton(true);
        its_view.Mode = ViewMode.HOURLY;
        its_view.SetWindowTitleBasedOnMode();
      }       
    } // end Execute() method
  } // end NewHourlyEmployeeCommand class definition
} // end namespace