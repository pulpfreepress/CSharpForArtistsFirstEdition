/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class Submarine : Vessel {     public Submarine(Plant plant, Weapon weapon, String name):base(plant, weapon, name){     Console.WriteLine("Submarine object created: " + base.ToString());   }   public override void LightoffPlant(){     Plant.LightoffPlant();   }   public override void ShutdownPlant(){     Plant.ShutdownPlant();   }   public override void TrainWeapon(){     Weapon.TrainWeapon();   }   public override void FireWeapon(){     Weapon.FireWeapon();   }} // end Submarine class definition