public class TrackData
{
    public string Name { get; set; }

    // Speed range (km/h)
    public int MinSpeed { get; set; }
    public int MaxSpeed { get; set; }

    // Brake percentage range
    public int MinBrake { get; set; }
    public int MaxBrake { get; set; }

    // Throttle percentage range
    public int MinThrottle { get; set; }
    public int MaxThrottle { get; set; }

    // Engine temperature typical range (°C)
    public int MinEngineTemp { get; set; }
    public int MaxEngineTemp { get; set; }

    public TrackData(
        string name,
        int minSpeed, int maxSpeed,
        int minBrake, int maxBrake,
        int minThrottle, int maxThrottle,
        int minEngineTemp = 50, int maxEngineTemp = 100)
    {
        Name = name;
        MinSpeed = minSpeed;
        MaxSpeed = maxSpeed;
        MinBrake = minBrake;
        MaxBrake = maxBrake;
        MinThrottle = minThrottle;
        MaxThrottle = maxThrottle;
        MinEngineTemp = minEngineTemp;
        MaxEngineTemp = maxEngineTemp;
    }
   

}
