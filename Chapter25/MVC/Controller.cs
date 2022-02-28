/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Windows.Forms;

public class Controller {
   private Model its_model = null;
   private View its_view = null;

   public Controller(){
	   its_model = new Model();
	   its_view = new View(this);
     Application.Run(its_view);
   }

   public void ClickHandler(Object sender, EventArgs e){
	     its_view.SetMessage(its_model.GetMessage());
	   }

  public static void Main(){
	  new Controller();
  }

} // end Controller class definition