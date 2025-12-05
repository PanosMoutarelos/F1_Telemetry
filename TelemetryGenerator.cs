using System;

namespace F1_Telemetry
{
    internal class TelemetryGenerator
    {
        private TelemetryData telemetryFrame;
        private Random rnd = new Random();

        // Nested class to decide gear and RPM based on speed
        private class TelemetryRules
        {
            private Random rnd = new Random();

            public (int gear, int rpm) GetGearAndRPM(double speed)
            {
                if (speed >= 0 && speed <= 50) return (1, rnd.Next(2000, 8000));
                else if (speed <= 90) return (2, rnd.Next(4000, 10000));
                else if (speed <= 130) return (3, rnd.Next(6000, 12000));
                else if (speed <= 180) return (4, rnd.Next(8000, 14000));
                else if (speed <= 230) return (5, rnd.Next(10000, 16000));
                else if (speed <= 280) return (6, rnd.Next(12000, 18000));
                else return (7, rnd.Next(14000, 20000));
            }
        }

        private TelemetryRules rules = new TelemetryRules();

        public TelemetryGenerator()
        {
            // Start with realistic starting conditions
            telemetryFrame = new TelemetryData(150, 8000, 3, 70, 0, 70);
        }

        // --- Driving states ---
        private void Acceleration()
        {
            telemetryFrame.Throttle = rnd.Next(80, 100);
            telemetryFrame.Brake = 0;
            telemetryFrame.Speed += rnd.Next(10, 20);
            telemetryFrame.Speed = Math.Max(telemetryFrame.Speed, 150); // never below 150
            telemetryFrame.EngineTemperature += rnd.Next(1, 3);
        }

        private void Cruising()
        {
            telemetryFrame.Throttle = rnd.Next(50, 70);
            telemetryFrame.Brake = 0;
            telemetryFrame.Speed += rnd.Next(-5, 6);
            telemetryFrame.Speed = Math.Max(telemetryFrame.Speed, 150);
            telemetryFrame.EngineTemperature += rnd.Next(0, 2);
        }

        private void LightBraking()
        {
            telemetryFrame.Brake = rnd.Next(10, 40);
            telemetryFrame.Throttle = rnd.Next(30, 60);
            telemetryFrame.Speed -= rnd.Next(5, 15);
            telemetryFrame.Speed = Math.Max(telemetryFrame.Speed, 150);
            telemetryFrame.EngineTemperature -= rnd.Next(1, 3); // cools slightly
        }

        private void HeavyBraking()
        {
            telemetryFrame.Brake = rnd.Next(60, 100);
            telemetryFrame.Throttle = rnd.Next(0, 40);
            telemetryFrame.Speed -= rnd.Next(10, 25);
            telemetryFrame.Speed = Math.Max(telemetryFrame.Speed, 150);
            telemetryFrame.EngineTemperature -= rnd.Next(2, 5); // stronger cooling
        }

        // --- Main frame generator ---
        public void GenerateNextFrame(TrackData track)
        {
            // Ensure minimum speed for lap summary
            telemetryFrame.Speed = rnd.Next(150, 220); // realistic F1 lap speed

            // Throttle mostly high, but can vary
            telemetryFrame.Throttle = rnd.Next(50, 100);

            // Brake always present, 10–30% for normal lap
            telemetryFrame.Brake = rnd.Next(10, 30);

            // Engine temperature rises slightly per lap
            telemetryFrame.EngineTemperature += rnd.Next(1, 4);
            if (telemetryFrame.EngineTemperature > 120)
                telemetryFrame.EngineTemperature = 120;

            // Determine gear & RPM based on speed
            (int gear, int rpm) = rules.GetGearAndRPM(telemetryFrame.Speed);
            telemetryFrame.Gear = gear;
            telemetryFrame.RPM = rpm;
        }


        // --- Print current frame summary ---
        public void PrintCurrentFrame()
        {
            Console.WriteLine($"Speed: {telemetryFrame.Speed} km/h | RPM: {telemetryFrame.RPM} | Gear: {telemetryFrame.Gear} | Throttle: {telemetryFrame.Throttle}% | Brake: {telemetryFrame.Brake}% | Temp: {telemetryFrame.EngineTemperature}°C");
        }
    }
}
