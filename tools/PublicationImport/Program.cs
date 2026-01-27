//FileStream fs = File.Open(@"C:\src\sample-pages\temp\paper.json", FileMode.Open, FileAccess.Read);

using Azure;
using Azure.Core.Serialization;

byte[] bytes = File.ReadAllBytes(@"C:\src\sample-pages\tools\temp\paper.json");
BinaryData data = new(bytes);
dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
dynamic appsWarmupData = json.appsWarmupData;
dynamic dataBinding = appsWarmupData.dataBinding;
dynamic dataStore = dataBinding.dataStore;
dynamic records = dataStore.recordsByCollectionId;

foreach (dynamic collection in records)
{
    Console.WriteLine("***" + (string)collection.Name);
    Console.WriteLine();

    foreach (dynamic paper in collection.Value)
    {
        Console.WriteLine("Title: " + (string)paper.Value.title);
        Console.WriteLine("Award: " + (string)paper.Value.award);

        string url = paper.Value.url;
        string link = paper.Value.link;
        string loc = url == null ? link : url;

        Console.WriteLine("Link: " + loc);

        string paperImage = paper.Value.paperImage;
        string image = paper.Value.image;
        string img = paperImage == null ? image : paperImage;

        Console.WriteLine("Image: " + img);
        Console.WriteLine();
    }
}

Console.ReadLine();
