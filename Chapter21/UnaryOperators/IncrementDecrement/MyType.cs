/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MyType {
  private int _intField;
  
  public int IntField {
    get { return _intField; }
    set { _intField = value; }
  }
  
  public MyType():this(5){
  }
  
  public MyType(int intField){
    _intField = intField;
  }
  
  public static MyType operator +(MyType mt){
    mt.IntField = (+mt.IntField);
    return mt;
  }
  
  public static MyType operator -(MyType mt){
    mt.IntField = (-mt.IntField);
    return mt;
  }
  
  public static bool operator ! (MyType mt){
    bool retVal = true;
    if(mt.IntField >= 0){
      retVal = false;
    } 
    return retVal;
  }
  
  public static bool operator true(MyType mt){
    return !mt;
  }
  
  public static bool operator false(MyType mt){
   return !mt;
  }
  
  public static MyType operator ++(MyType mt){
    MyType result = new MyType(mt.IntField);
    ++result.IntField;
    return result;
  }
  
  public static MyType operator --(MyType mt){
    MyType result = new MyType(mt.IntField);
    --result.IntField;
    return result;
  }
  
  public override String ToString(){
    return IntField.ToString();
  }
  
}