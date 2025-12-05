using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Telemetry
{
    internal class TelemetryData
    {
        public double Speed;
        public int RPM;
        public int Gear;
        public int Throttle;
        public int Brake;
        public double EngineTemperature;


        public TelemetryData(double speed, int rpm, int gear, int throttle, int brake, double enginetemperature)
        {
            Speed = speed;
            RPM = rpm;
            Gear = gear;
            Throttle = throttle;
            Brake = brake;
            EngineTemperature = enginetemperature;
        }

        public override string ToString()
        {
            return $"Speed: {Speed} km/h | RPM: {RPM} | Gear: {Gear} | Throttle: {Throttle}% | Brake: {Brake}% | Temp: {EngineTemperature}°C";
        }
    }
}
