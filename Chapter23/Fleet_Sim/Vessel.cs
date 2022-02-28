/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public abstract class Vessel {
  private Plant its_plant = null;
  private Weapon its_weapon = null;
  private String its_name = null;
    // protected properties  protected Weapon Weapon {     get { return its_weapon; }  }  
  protected Plant Plant {     get { return its_plant; }  }  
  public Vessel(Plant plant, Weapon weapon, String name){
    its_weapon = weapon;
    its_plant = plant;
    its_name = name;
    Console.WriteLine("The vessel " + its_name + " created!");
  }
  
  /* ********************************************************
      Public Abstract Methods - must be implemented in
      derived classes.
  *********************************************************/
  public abstract void LightoffPlant();
  public abstract void ShutdownPlant();
  public abstract void TrainWeapon();
  public abstract void FireWeapon();
  
  /* ********************************************************
      ToString() Method - may be overridden in subclasses.
  *********************************************************/
  public override String ToString(){
    return "Vessel name: " + its_name + " " + its_plant.ToString() +
            " " + its_weapon.ToString();
  }
  

}// end Vessel class definition
