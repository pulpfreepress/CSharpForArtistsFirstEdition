/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public abstract class Weapon {  private String its_model = null;    public Weapon(String model){    its_model = model;    Console.WriteLine("Weapon object created!");  }    public abstract void TrainWeapon();  public abstract void FireWeapon();    public override String ToString(){ return "Weapon model: " + its_model; }}