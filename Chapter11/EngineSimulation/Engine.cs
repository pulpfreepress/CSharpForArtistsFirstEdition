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
	public class Engine {
		private int _engineNumber;
		private bool _isRunning;
		private EnginePart[] _itsParts;
		
		public int EngineNumber {
			get { return _engineNumber; }
			set { _engineNumber = value; }
		}
		
		public bool IsRunning {
			get { return _isRunning; }
			set { _isRunning = value; }
		}
		
		public Engine(int engineNumber){
			EngineNumber = engineNumber;
			IsRunning = false;
			_itsParts = new EnginePart[6];
			_itsParts[0] = new Compressor(PartStatus.WORKING, EngineNumber);
			_itsParts[1] = new FuelPump(PartStatus.WORKING, EngineNumber);
			_itsParts[2] = new OilPump(PartStatus.WORKING, EngineNumber);
			_itsParts[3] = new WaterPump(PartStatus.WORKING, EngineNumber);
			_itsParts[4] = new OxygenSensor(PartStatus.WORKING, EngineNumber);
			_itsParts[5] = new TemperatureSensor(PartStatus.WORKING, EngineNumber);
			Console.WriteLine("Engine number {0} created", EngineNumber);
		}
		
		
		private bool CheckEngine(){
			Console.WriteLine("Checking engine number {0}...", EngineNumber);
			bool is_working = false;
			
			for(int i=0; i<_itsParts.Length; i++){
				is_working = _itsParts[i].IsWorking;
				if(!is_working){
					Console.WriteLine(_itsParts[i].PartIdentifier + " " + _itsParts[i].Status);
					break;
					
					}
			}
			   
			if(is_working){
				Console.WriteLine("Engine number {0} working properly!", EngineNumber);
			}else{
				Console.WriteLine("Engine number {0} malfunction!", EngineNumber);
				StopEngine();
			}
			return is_working;
		}
		
		
		
		public void StartEngine(){
			if(!IsRunning){
				IsRunning = CheckEngine();
				if(!IsRunning){
					Console.WriteLine("Engine number {0} failed to start!", EngineNumber);
				}else{
					Console.WriteLine("Engine number {0} started!", EngineNumber);
				}
			}else{
				Console.WriteLine("Engine number {0} is already running!", EngineNumber);
			}
		}
		
		public void StopEngine(){
			if(IsRunning){
				IsRunning = false;
				Console.WriteLine("Engine number {0} has been stopped!", EngineNumber);
			}else{
				Console.WriteLine("Engine number {0} is not running!", EngineNumber);
			}
		}
		
		
		public void SetPartFault(String partName){
			for(int i=0; i<_itsParts.Length; i++){
				if(_itsParts[i].PartName.Equals(partName)){
					_itsParts[i].SetFault();
					Console.WriteLine("The status of Engine number {0}'s {1} is {2}", EngineNumber, 
					                   _itsParts[i].PartName, _itsParts[i].Status);
				}
			}
		}
		
		public void ClearPartFault(String partName){
					for(int i=0; i<_itsParts.Length; i++){
						if(_itsParts[i].PartName.Equals(partName)){
							_itsParts[i].ClearFault();
							Console.WriteLine("The status of Engine number {0}'s {1} is {2}", EngineNumber, 
							                   _itsParts[i].PartName, _itsParts[i].Status);
						}
					}
		}
		
		
				
		
	} // end class
} // end namespace