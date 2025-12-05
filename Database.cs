using System.Data.SQLite;

public static class Database
{
    private const string DbPath = "Data Source=tracks.db"; // path to your database

    public static TrackData? GetTrack(string name)
    {
        using var connection = new SQLiteConnection(DbPath);
        connection.Open();

        string query = "SELECT * FROM Tracks WHERE Name = @name LIMIT 1";

        using var cmd = new SQLiteCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", name);

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return null; // track not found

        return new TrackData(
            reader.GetString(0),   // Name
            reader.GetInt32(1),    // MinSpeed
            reader.GetInt32(2),    // MaxSpeed
            reader.GetInt32(3),    // MinBrake
            reader.GetInt32(4),    // MaxBrake
            reader.GetInt32(5),    // MinThrottle
            reader.GetInt32(6),    // MaxThrottle
            reader.GetInt32(7),    // MinEngineTemp
            reader.GetInt32(8)     // MaxEngineTemp
        );
    }
}
