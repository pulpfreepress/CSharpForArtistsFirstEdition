/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class NukePlant : Plant {     public NukePlant(String model):base(model) {     Console.WriteLine("NukePlant object created!");   }  public override void LightoffPlant(){    Console.WriteLine("Nuke plant is critical!");  }  public override void ShutdownPlant(){    Console.WriteLine("Nuke plant is secure!");  }}