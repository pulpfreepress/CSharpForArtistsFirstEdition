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
        private Compressor its_compressor = null;
        private FuelPump its_fuelpump = null;
        private OilPump its_oilpump = null;
        private OxygenSensor its_oxygensensor = null;
        private TemperatureSensor its_temperaturesensor = null;
        private int its_engine_number = 0;
        private bool is_running = false;
        private PartStatus its_status;

        public Engine(int engine_number) {
            its_engine_number = engine_number;
            its_compressor = new Compressor(PartStatus.WORKING, its_engine_number);
            its_fuelpump = new FuelPump(PartStatus.WORKING, its_engine_number);
            its_oilpump = new OilPump(PartStatus.WORKING, its_engine_number);
            its_oxygensensor = new OxygenSensor(PartStatus.WORKING, its_engine_number);
            its_temperaturesensor = new TemperatureSensor(PartStatus.WORKING, its_engine_number);
            its_status = PartStatus.WORKING;
            Console.WriteLine("Engine #" + its_engine_number + " created!");
        }

        public void SetCompressorStatus(PartStatus status) {
            its_compressor.Status = status;
            CheckEngineStatus();
        }

        public void SetFuelPumpStatus(PartStatus status) {
            its_fuelpump.Status = status;
            CheckEngineStatus();

        }

        public void SetOilPumpStatus(PartStatus status) {
            its_oilpump.Status = status;
            CheckEngineStatus();
        }

        public void SetOxygenSensorStatus(PartStatus status) {
            its_oxygensensor.Status = status;
            CheckEngineStatus();
        }

        public void setTemperatureSensor(PartStatus status) {
            its_temperaturesensor.Status = status;
            CheckEngineStatus();
        }

        public bool CheckEngineStatus() {
            if (its_compressor.IsWorking && its_fuelpump.IsWorking &&
               its_oilpump.IsWorking && its_oxygensensor.IsWorking &&
               its_temperaturesensor.IsWorking) {
                its_status = PartStatus.WORKING;
                Console.WriteLine("All engine #" + its_engine_number + " components working properly.");
            }
            else {
                its_status = PartStatus.NOT_WORKING;
                Console.WriteLine("Engine #" + its_engine_number + " malfunction.");
                if (is_running) {
                    Console.WriteLine("Engine #" + its_engine_number + " shutting down!");
                    StopEngine();
                }
            }

            return its_status == PartStatus.WORKING ? true : false;
        }

        public void StartEngine() {
            if (!is_running) {
                if (CheckEngineStatus()) {
                    is_running = true;
                    Console.WriteLine("Engine #" + its_engine_number + " is running!");
                }
                else {
                    Console.WriteLine("There is a problem with an engine #" + its_engine_number 
                                      + " component. Engine cannot start.");
                }
            }
            else {
                Console.WriteLine("Engine #" + its_engine_number + " is already running!");
            }
        }

        public void StopEngine() {
            is_running = false;
            Console.WriteLine("Engine #" + its_engine_number + " has been stopped!");
        }

    } // end class definition
} // end namespace
