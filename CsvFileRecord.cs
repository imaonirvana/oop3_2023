namespace oop_lab3;

public class CsvFileRecord
{
    public string Date;
    public double Money;

    public static List<CsvFileRecord> From(Dictionary<string, double> dictionary)
    {
        var result = new List<CsvFileRecord>();
        
        foreach (var entry in dictionary)
        {
            var model = new CsvFileRecord();
            
            model.Date = entry.Key;
            model.Money = entry.Value;
            
            result.Add(model);
        }

        return result;
    }

    public static string Serialize(IEnumerable<CsvFileRecord> records)
    {
        var result = "Date,Money";

        foreach (var record in records)
        {
            if (record == null)
            {
                break;
            }
            
            result += $"\n{record.Date},\"{record.Money}\"";
        }

        return result;
    }
}