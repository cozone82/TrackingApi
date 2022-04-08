using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tracking.Client;



HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7165");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

// Retreive all of the issues and display in console app
HttpResponseMessage response = await client.GetAsync("api/issue");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();

    foreach (var issue in issues)
    {
        Console.Write(issue.Title + "\n");
    }
}
else
{
    Console.WriteLine("No results");
}
Console.ReadLine();


