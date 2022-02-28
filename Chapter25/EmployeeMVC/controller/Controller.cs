/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;
using System.Windows.Forms;
using Com.PulpFreePress.Common;
using Com.PulpFreePress.Exceptions;
using Com.PulpFreePress.Commands;
using Com.PulpFreePress.Model;
using Com.PulpFreePress.View;
using Com.PulpFreePress.Utils;

public class Controller : IController {
   
   private CommandFactory command_factory = null;
   private IModel its_model;
   private IView its_view;
   
   public Controller(){
     command_factory = CommandFactory.GetInstance();
     command_factory.WorkingDirectory = Directory.GetCurrentDirectory();
     its_model = new Model();
     its_view = new Com.PulpFreePress.View.View(this);
     Application.Run((Form)its_view);
   }
  
  
  public void UniversalHandler(Object sender, EventArgs e){
    try{
     BaseCommand command = null;
     if(sender.GetType() == typeof(Button)){
       command = command_factory.GetCommand(((Button)sender).Name);
     }else{
       command = command_factory.GetCommand(((ToolStripMenuItem)sender).Name);
      }
     command.Model = its_model;
     command.View = its_view;
     command.Execute();
     }catch(CommandNotFoundException cnfe){
        Console.WriteLine("Command not found!");
     }
  }

  public static void Main(){
     new Controller();
  } // end Main() method
} // end Controller class definition
