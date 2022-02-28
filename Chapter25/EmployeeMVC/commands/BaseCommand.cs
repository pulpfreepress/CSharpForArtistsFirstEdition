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
  public abstract class BaseCommand {
     protected static IModel its_model = null;
     protected static IView  its_view = null;

     public IModel Model {
  	  set { 
         if(its_model == null){
  		   its_model = value;
         }
       }
     }

     public IView View {
  	   set {
         if(its_view == null){
         its_view = value;
         }
       }
     }

     public abstract void Execute(); // must be implemented in derived classes

  } // end BaseCommand class definition
} // end namespace