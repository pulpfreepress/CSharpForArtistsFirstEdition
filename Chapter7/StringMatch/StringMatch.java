/*****************************************************************  Copyright 2006 Rick Miller, Raffi Kasparian - Pulp Free Press         This source code accompanies the text Java For Artists and is
   provided for instructional purposes only. No warranty concerning
   the quality of this code is expressed or implied. You are free to 
   use this code in your programs so long as this copyright notice
   is included in its entirety.*****************************************************************/

public class StringMatch {
  public static void main(String[] args){
   String name_1 = args[0];
   String name_2 = args[1];

   if(name_1.equals(name_2)){
      System.out.println("The names " + name_1 + " and " + name_2 + " match!");
     } else { 
        System.out.println("The names " + name_1 + " and " + name_2 + " do not match!");
     }

 }
}