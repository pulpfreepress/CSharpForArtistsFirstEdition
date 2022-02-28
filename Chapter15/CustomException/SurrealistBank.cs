/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

/***************************************************
  This program depends on the Person class.
****************************************************/

using System;
using System.Collections.Generic;

public class SurrealistBank {
    Dictionary<String, Person> surrealists;

    public SurrealistBank() {
        surrealists = new Dictionary<String, Person>();
        InitializeDictionary();
    }

    private void InitializeDictionary() {
        Person p1 = new Person("Max", "", "Ernst", Person.Sex.MALE, new DateTime(1891, 04, 02));
        Person p2 = new Person("Andre", "", "Breton", Person.Sex.MALE, new DateTime(1896, 02, 19));
        Person p3 = new Person("Roland", "", "Penrose", Person.Sex.MALE, new DateTime(1900, 10, 14));
        Person p4 = new Person("Lee", "", "Miller", Person.Sex.FEMALE, new DateTime(1907, 04, 23));
        Person p5 = new Person("Henri-Robert-Marcel", "", "Duchamp", Person.Sex.MALE, new DateTime(1887, 07, 28));
        surrealists.Add(p1.LastName, p1);
        surrealists.Add(p2.LastName, p2);
        surrealists.Add(p3.LastName, p3);
        surrealists.Add(p4.LastName, p4);
        surrealists.Add(p5.LastName, p5);
    }

    public Person LookUp(String last_name) {
        Person p = null;
        try {
            if (surrealists.TryGetValue(last_name, out p)) {
                return p;
            }
            else {
                throw new SurrealistNotFoundException("That name is not in the surrealist collection!");
            }
        }
        catch (ArgumentNullException ane) {
            throw new SurrealistNotFoundException("A null string name was entered!", ane);
        }

    }

} // end SurrealistBank class definition
