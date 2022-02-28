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

public class MainApp {
	
	private FlowLayoutGUI _gui;
	private DateTime _appStart;
	public MainApp(){
		_gui = new FlowLayoutGUI(this);
		_appStart = DateTime.Now;
		Application.Run(_gui);
	}
	
	public void ButtonClickHandler(Object sender, EventArgs e){
			((Button)sender).Text = (DateTime.Now - _appStart).ToString();
	}
	
	public static void Main(){
			new MainApp();
	} // end Main()
} // end MyApp class definition