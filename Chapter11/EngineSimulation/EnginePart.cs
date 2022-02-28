/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace EngineSimulation {
  public abstract class EnginePart : Part, IManagedPart {
	  private int _registeredEngineNumber;
	
	  public int RegisteredEngineNumber {
		  get { return _registeredEngineNumber; }
	  	set { _registeredEngineNumber = value; }
	  }
	  
	  public String PartIdentifier {
			get { return PartName + " For Engine Number: " + RegisteredEngineNumber; }
		}
	
	  public EnginePart(PartStatus status, String partName, int engineNumber ):base(status, partName){
			RegisteredEngineNumber = engineNumber;
		}
		
		public void SetFault() { 
			Status = PartStatus.NOT_WORKING; 
			DisplayStatus();
		}
		
		public void ClearFault() { 
			Status = PartStatus.WORKING; 
			DisplayStatus();
		}
		
		private void DisplayStatus(){
			Console.WriteLine(PartIdentifier + " status is now: " + Status);
		}
	
  } // end class definition
} // end namespace