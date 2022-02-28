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
using System.Reflection;
using Com.PulpFreePress.Commands;
using Com.PulpFreePress.Exceptions;

namespace Com.PulpFreePress.Utils {
  public class CommandFactory {

  private static CommandFactory command_factory_instance = null;
  private static CommandProperties command_properties = null;
  private static string working_directory = string.Empty;

  static CommandFactory() {
     command_properties = CommandProperties.GetInstance();
   }


  private CommandFactory(){}

  public static CommandFactory GetInstance(){
    if(command_factory_instance == null){
      command_factory_instance = new CommandFactory();
    }
    return command_factory_instance;
  }
  
  
  public string WorkingDirectory {
    get { return working_directory; }
    set { working_directory = value; }
  }
  

  /******************************************************************
    Thorws CommandNotFoundException if command does not exist or 
    command_string equals null.
  ****************************************************************/
  public BaseCommand GetCommand(String command_string){
    BaseCommand command = null;
    if(command_string == null){
       throw new CommandNotFoundException( command_string + " command class not found!");
     } else{ 
     try {
          Assembly assembly = Assembly.LoadFrom(working_directory + "\\Commands.dll"); // expect to find commands in Commands.dll
          String command_type_name = command_properties.GetProperty(command_string);
        foreach(Type t in assembly.GetTypes()){
          if(t.Name == command_type_name){
            command = (BaseCommand) Activator.CreateInstance(t);
          }
        }
          }catch(Exception ex){
            Console.WriteLine(ex);
            throw new CommandNotFoundException(ex.ToString(), ex);
           }
      } // end else
      return command;
   } // end etCommand() method

  } // end CommandFactory class definition
} // end namespace