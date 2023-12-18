using Newtonsoft.Json;
using quizTimeBas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public static class DataHelper
{
    public static List<Question> questions { get; set; }

    public static async Task LoadJSON()
    {
        FileInfo JsonFile = new FileInfo(@".\quizes\questions.json");
        using (StreamReader sr = JsonFile.OpenText())
        {
            string JsonContent = sr.ReadToEnd();
            questions = JsonConvert.DeserializeObject<List<Question>>(JsonContent);

        }

    }
    public static async Task SaveJSON()
    {
        FileInfo JsonFile = new FileInfo(@".\quizes\questions.json");
        using (StreamWriter sw = new StreamWriter(JsonFile.OpenWrite()))
        {
            string JsonContent = JsonConvert.SerializeObject(questions);
            sw.Write(JsonContent);
        }
    }
}

