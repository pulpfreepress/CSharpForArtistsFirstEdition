/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


public class RemotingServer {
  public static void Main(){
   try {
     RemotingConfiguration.Configure("server.config", false);
     Console.WriteLine("Listening for remote requests. Press any key to exit...");
     Console.ReadLine();
    }catch(Exception e){
      Console.WriteLine(e);
    }
  }
}