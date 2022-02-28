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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class MainApp {
 public static void Main(String[] args){
 
   /***********************************************
     Create an array of Dogs and populate
   ***********************************************/
   Dog[] dog_array = new Dog[3];
 
   dog_array[0] = new Dog("Rick Miller", new DateTime(1965, 07, 08));
   dog_array[1] = new Dog("Coralie Powell", new DateTime(1973, 08, 10));
   dog_array[2] = new Dog("Kyle Miller", new DateTime(1990, 05, 01));
   
   /**********************************************
         Iterate over the dog_array and print values
       **********************************************/
   Console.WriteLine("-----Original Dog Array Contents---------------------");
   for(int i = 0; i<dog_array.Length; i++){
     Console.WriteLine(dog_array[i].Name + ", " + dog_array[i].Age);
   }
   
   /************************************************
       Serialize the array of dog objects to a file
       ************************************************/
   FileStream fs = null; 
   try{
     fs = new FileStream("DogFile.dat", FileMode.Create);
     BinaryFormatter bf = new BinaryFormatter();
     bf.Serialize(fs, dog_array); 
   
   }catch(IOException e){
     Console.WriteLine(e.Message);
   }catch(SerializationException se){
     Console.WriteLine(se.Message);
   }finally{
      fs.Close();
    }
    
    /************************************************
          Deserialize the array of dogs and print values
          *************************************************/
      fs = null;                          //start fresh
      Dog[] another_dog_array = null;     //here too!
      try{
        fs = new FileStream("DogFile.dat", FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        another_dog_array = (Dog[])bf.Deserialize(fs);
        Console.WriteLine("-----After Serialization and Deserialization---------");
        for(int i = 0; i<another_dog_array.Length; i++){
	     Console.WriteLine(another_dog_array[i].Name + ", " + another_dog_array[i].Age);
        }
      
      }catch(IOException e){
      
      Console.WriteLine(e.Message);
         }catch(SerializationException se){
           Console.WriteLine(se.Message);
         }finally{
            fs.Close();
    }
    
    

 } // end Main() definition
} // end MainApp class definition