//title:
//authors: [alexis-hiniker, "Miriam Rosenberg-Lee", "Vinod Menon"] < --some link to local ppl and some don't
//venue:
//keywords: []
//download-link:
//citation:
//research-areas:
//publicationtype: journal, conference
//doi:
//materials:
//image:
//date:
//award:
//acceptance:


using Azure;
using Azure.Core.Serialization;
using System.Text;

// Handle the input JSON bytes
byte[] bytes = File.ReadAllBytes(@"C:\src\sample-pages\tools\temp\paper.json");
BinaryData data = new(bytes);
dynamic json = data.ToDynamicFromJson(JsonPropertyNames.CamelCase);
dynamic appsWarmupData = json.appsWarmupData;
dynamic dataBinding = appsWarmupData.dataBinding;
dynamic dataStore = dataBinding.dataStore;
dynamic records = dataStore.recordsByCollectionId;

// Set up the output: this is not optimal, but quick and dirty.
StringBuilder output = new("authors,year,title,venue,download-link,image,award,slug\n");

foreach (dynamic collection in records)
{
    Console.WriteLine(" ***" + (string)collection.Name);
    Console.WriteLine();

    foreach (dynamic paper in collection.Value)
    {
        string titleField = (string)paper.Value.title;
        Console.WriteLine("Title: " + titleField);

        // Parse the title field into authors, year, title, venue
        int yearOffset = titleField.IndexOf('2');
        string authors = titleField.Substring(0, yearOffset - 1);
        string remaining = titleField.Substring(yearOffset);
        string year = remaining.Substring(0, 4);
        remaining = remaining.Substring(6);
        string title = string.Empty;
        if (remaining.StartsWith("\""))
        {
            int titleEndOffset = remaining.Substring(1).IndexOf("\"");
            title = remaining.Substring(1, titleEndOffset);
            remaining = remaining.Substring(titleEndOffset + 1);
        }
        else
        {
            int titleEndOffset = remaining.IndexOf(".");
            title = remaining.Substring(0, titleEndOffset);
            remaining = remaining.Substring(titleEndOffset + 1);
        }

        string venue = remaining;

        output.Append(authors);
        output.Append(',');
        output.Append(year);
        output.Append(',');
        output.Append(title);
        output.Append(',');
        output.Append(venue);
        output.Append(',');

        string url = paper.Value.url;
        string link = paper.Value.link;
        string loc = url == null ? link : url;
        Console.WriteLine("Link: " + loc);

        output.Append(loc);
        output.Append(',');

        string paperImage = paper.Value.paperImage;
        string image = paper.Value.image;
        string img = paperImage == null ? image : paperImage;
        Console.WriteLine("Image: " + img);

        output.Append(img);
        output.Append(',');

        Console.WriteLine("Award: " + (string)paper.Value.award);

        output.Append((string)paper.Value.award);
        output.Append(',');

        string slug = "***";
        if (loc is not null)
        {
            string[] vals = loc.Split('/', '.');
            // the last value should be "pdf", we want the one before that, so minus 2.
            slug = vals[vals.Length - 2];
        }
        Console.WriteLine("Slug: " + slug);

        output.Append(slug);

        Console.WriteLine();
    }
}

using (FileStream fs = File.OpenWrite(@"C:\src\sample-pages\tools\temp\papers-out.csv"))
{
    string outputstr = output.ToString();
    BinaryData outbytes = BinaryData.FromString(outputstr);
    fs.Write(outbytes);
}

Console.ReadLine();
