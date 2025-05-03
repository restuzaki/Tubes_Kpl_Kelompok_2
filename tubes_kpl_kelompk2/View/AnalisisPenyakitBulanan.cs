using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AnalisisPenyakit
{
    private List<Penyakit> diseaseAnalyses;

    public AnalisisPenyakit(string configFilePath)
    {
        var configJson = File.ReadAllText(configFilePath);
        diseaseAnalyses = JsonSerializer.Deserialize<List<Penyakit>>(configJson);
    }

    public IEnumerable<Penyakit> GetDiseaseAnalyses()
    {
        return diseaseAnalyses;
    }
}
