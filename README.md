<b font-size:20px>F1 Telemetry Simulator</b>

A C# console application that simulates Formula 1 telemetry data (speed, RPM, throttle, braking, engine temperature) based on track-specific profiles stored in an SQLite database.

Each track has realistic ranges for Speed, Brake %, Throttle %, and Engine Temperature.
The simulator loads track parameters from the database, validates the user’s input, and generates realistic lap-by-lap telemetry.

Features

✔️ Track data loaded dynamically from SQLite

✔️ User can only start simulation if the track exists

✔️ Realistic telemetry generation per lap

✔️ Controlled speed, RPM, gear, throttle & brake values

✔️ Engine temperature increases per lap

✔️ Clean console output with per-lap summaries

✔️ Supports any number of laps

✔️ Easily expandable (add more tracks to the database)

Project Structure
/F1 Telemetry
│
├── Program.cs               # Main entry point
├── TrackData.cs             # Track model containing speed/throttle/brake ranges
├── TelemetryFrame.cs        # Holds one telemetry snapshot
├── TelemetryGenerator.cs    # Creates telemetry based on track data
├── Database.cs              # Loads track data from SQLite
│
└── tracks.db                # SQLite database with track definitions

Requirements
Software

.NET 8.0 SDK or later

SQLite (included in tools or downloaded manually)

NuGet Dependency

Install SQLite provider:

Install-Package System.Data.SQLite.Core
Database Setup

Your SQLite database must contain a table called Tracks:

CREATE TABLE IF NOT EXISTS Tracks (
    Name TEXT PRIMARY KEY,
    MinSpeed INTEGER,
    MaxSpeed INTEGER,
    MinBrake INTEGER,
    MaxBrake INTEGER,
    MinThrottle INTEGER,
    MaxThrottle INTEGER,
    MinEngineTemp INTEGER,
    MaxEngineTemp INTEGER
);

Insert Tracks

Example:

INSERT INTO Tracks VALUES
('Monza', 200, 350, 5, 20, 60, 95, 50, 100);


Add all tracks the program should support.

<b>How to Run</b>

Navigate to project folder:

cd F1 Telemetry/bin/Debug/net8.0


Run the program:

F1_Telemetry.exe


Enter a track name (case-insensitive):

Enter the track name:
Monza


If the track is not found, you must re-enter until correct:

? Track not found in database. Try again.


Enter number of laps:

Enter number of laps:
5


Simulation begins:

Lap 1:
--------------------------
Speed: 183 km/h | RPM: 13221 | Gear: 5 | Throttle: 90% | Brake: 23% | Temp: 73°C
--------------------------
