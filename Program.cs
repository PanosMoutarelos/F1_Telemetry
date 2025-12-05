using System;
using System.Threading;

namespace F1_Telemetry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the F1 Telemetry Simulator!");
            Console.WriteLine("---------------------------------------");

            TrackData? track = null;

            // Keep asking until a correct track name is entered
            while (track == null)
            {
                Console.WriteLine("\nEnter the track name:");
                string input = Console.ReadLine() ?? "";

                track = Database.GetTrack(input);

                if (track == null)
                {
                    Console.WriteLine("Track not found in database. Try again.");
                }
            }

            Console.WriteLine($"\nSelected Track: {track.Name}");

            Console.WriteLine("\nEnter number of laps:");
            int laps = int.Parse(Console.ReadLine() ?? "1");

            var generator = new TelemetryGenerator();

            for (int i = 0; i < laps; i++)
            {
                Console.WriteLine($"\nLap {i + 1}:");
                Console.WriteLine("--------------------------");

                generator.GenerateNextFrame(track);
                generator.PrintCurrentFrame();

                Console.WriteLine("--------------------------");
                Thread.Sleep(500);
            }

            Console.WriteLine("\nSimulation complete.");
            Console.ReadKey();
        }
    }
}
