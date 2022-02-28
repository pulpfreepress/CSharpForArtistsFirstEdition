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
using System.Drawing;

public class MainApp {
	
	private TableLayoutGUI _gui;
	private Bitmap _bitmap;
	public MainApp(){
		_gui = new TableLayoutGUI(this);
		_bitmap = new Bitmap("rat.gif");
		Application.Run(_gui);
	}
	
	public void MarkSpace(Object sender, EventArgs e){
	     ((Button)sender).BackColor = Color.Blue;
	     ((Button)sender).Image = _bitmap;
   }
	
	public static void Main(){
		new MainApp();
	} // end Main()	
} // end MainApp class definition