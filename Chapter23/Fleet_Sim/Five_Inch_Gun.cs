/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class Five_Inch_Gun : Weapon {    public Five_Inch_Gun(String model):base(model){    Console.WriteLine("Five Inch Gun object created!");   }     public override void TrainWeapon(){    Console.WriteLine("Five Inch Gun is locked on target!");   }   public override void FireWeapon(){    Console.WriteLine("Blam! Blam! Blam!");   }}