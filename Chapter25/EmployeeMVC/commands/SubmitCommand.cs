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
  public class SubmitCommand : BaseCommand {
    public override void Execute(){
     if((its_view != null) && (its_model != null)){
       switch(its_view.Mode){
         case ViewMode.SALARIED: 
                 its_model.AddEmployee(its_view.GetNewSalariedEmployee());
                  its_view.DisplayEmployeeInfo(its_model.GetAllEmployeesInfo());
                  its_view.ClearInputFields();
                  its_view.EnableSubmitButton(false);
                  its_view.EnableSalaryFields(false);
                  its_view.Mode = ViewMode.RESTING;
                 break;
         case ViewMode.HOURLY:   
                 its_model.AddEmployee(its_view.GetNewHourlyEmployee());
                  its_view.DisplayEmployeeInfo(its_model.GetAllEmployeesInfo());
                  its_view.ClearInputFields();
                  its_view.EnableSubmitButton(false);
                  its_view.EnableHourlyFields(false);
                  its_view.Mode = ViewMode.RESTING;
                 break;
         case ViewMode.EDIT:    
                 int index = its_view.SelectedLineNumber();
                 its_model.EditEmployee(its_view.GetEditedEmployee(), index);
                 its_view.DisplayEmployeeInfo(its_model.GetAllEmployeesInfo());
                 its_view.ClearInputFields();
                 its_view.EnableSubmitButton(false);
                 its_view.EnableHourlyFields(false);
                 its_view.EnableSalaryFields(false);
                 its_view.Mode = ViewMode.RESTING;
                 break;
       }
     }
    } // end Execute() method
    
  } // end NewSalariedEmployeeCommand class definition
} // end namespace