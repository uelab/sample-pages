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
// Use pipes not commas because commas are used in the fields.
StringBuilder output = new("authors|year|title|venue|download-link|image|award|slug\n");

foreach (dynamic collection in records)
{
    Console.WriteLine(" ***" + (string)collection.Name);
    Console.WriteLine();

    foreach (dynamic paper in collection.Value)
    {
        string titleField = (string)paper.Value.title;
        titleField = titleField.Replace('“', '"');
        titleField = titleField.Replace('”', '"');
        
        Console.WriteLine("Title field: " + titleField);

        // Parse the title field into authors, year, title, venue
        int yearOffset = titleField.IndexOf('2');
        string authors = titleField.Substring(0, yearOffset - 2); // remove '.' at end
        authors = authors.Replace(" and", "");
        authors = authors.Replace(" &", "");
        authors = authors.Replace("Hiniker, A", "alexis-hiniker");
        Console.WriteLine("authors: " + authors);

        string remaining = titleField.Substring(yearOffset);
        string year = remaining.Substring(0, 4);

        Console.WriteLine("year: " + year);

        remaining = remaining.Substring(6);
        string title = string.Empty;
        if (remaining.StartsWith('"'))
        {
            int titleEndOffset = remaining.Substring(1).IndexOf('"');
            title = remaining.Substring(1, titleEndOffset - 1); // -1 to remove '.' at end.
            remaining = remaining.Substring(titleEndOffset + 2); // 2 to remove both '.' and space.
        }
        else
        {
            int titleEndOffset = remaining.IndexOf(".");
            title = remaining.Substring(0, titleEndOffset);
            remaining = remaining.Substring(titleEndOffset + 1);
        }


        string venue = remaining.Substring(1, remaining.Length - 2); // remove leading space and final '.'

        Console.WriteLine("title: " + title);
        Console.WriteLine("venue: " + venue);


        output.Append(authors);
        output.Append('|');
        output.Append(year);
        output.Append('|');
        output.Append(title);
        output.Append('|');
        output.Append(venue);
        output.Append('|');

        string url = paper.Value.url;
        string link = paper.Value.link;
        string loc = url == null ? link : url;
        Console.WriteLine("Link: " + loc);

        output.Append(loc);
        output.Append('|');

        string paperImage = paper.Value.paperImage;
        string image = paper.Value.image;
        string img = paperImage == null ? image : paperImage;
        Console.WriteLine("Image: " + img);

        output.Append(img);
        output.Append('|');

        string award = paper.Value.award;
        Console.WriteLine("Award: " + award);

        output.Append((string)paper.Value.award);
        output.Append('|');

        string slug = string.Empty;
        if (loc is not null)
        {
            string[] vals = loc.Split('/', '.');
            // the last value should be "pdf", we want the one before that, so minus 2.
            slug = vals[vals.Length - 2];
        }
        Console.WriteLine("Slug: " + slug);

        output.Append(slug);
        output.AppendLine();

        Console.WriteLine();

        // authors|year|title|venue|download-link|image|award|slug
        WriteMarkdownFile(slug, authors, year, title, venue, loc, image, award);
    }
}

void WriteMarkdownFile(string slug, string authors, string year, string title, string venue, string? loc, string image, string award)
{
    if (slug.Length == 0)
    {
        slug = title;
    }

    StringBuilder sb = new();
    sb.AppendLine("---");
    sb.Append("title: ");
    sb.AppendLine(title);
    sb.Append("authors: [");
    sb.Append(authors);
    sb.AppendLine("]");
    sb.Append("venue: ");
    sb.AppendLine(venue);
    sb.AppendLine("keywords: []");
    sb.Append("download-link: ");
    sb.AppendLine(loc);
    sb.AppendLine("citation: #");
    sb.AppendLine("research-areas: []");
    sb.AppendLine("publicationtype: ");
    sb.AppendLine("doi: ");
    sb.Append("image: ");
    sb.AppendLine(image);
    sb.Append("year: ");
    sb.AppendLine(year);
    sb.AppendLine("---");

    string fileName = @"C:\src\sample-pages\tools\temp\files\" + slug + ".md";
    try
    {
        using (FileStream fs = File.OpenWrite(fileName))
        {
            string outputstr = sb.ToString();
            BinaryData outbytes = BinaryData.FromString(outputstr);
            fs.Write(outbytes);
        }
    }
    catch (Exception ex)
    {
        // Dump this for debugging and manual correction.
        Console.WriteLine(ex.ToString());
    }
}


using (FileStream fs = File.OpenWrite(@"C:\src\sample-pages\tools\temp\papers-out.txt"))
{
    string outputstr = output.ToString();
    BinaryData outbytes = BinaryData.FromString(outputstr);
    fs.Write(outbytes);
}

Console.ReadLine();
