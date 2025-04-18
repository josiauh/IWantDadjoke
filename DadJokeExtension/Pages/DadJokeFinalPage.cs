using Microsoft.CommandPalette.Extensions.Toolkit;
using Microsoft.CommandPalette.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace DadJokeExtension;

internal sealed partial class DadJokeFinalPage : ListPage
{

    static readonly HttpClient client = new HttpClient();

    public DadJokeFinalPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png"); // Checkmark
        Title = "Dad Joke - powered by icanhazdadjoke.com";
        Name = "Got a Dad Joke";

        client.DefaultRequestHeaders.UserAgent.ParseAdd("Freesmart Dad Joke Extension/2.7.63 (stupidity)");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
    }

    public override IListItem[] GetItems()
    {

        // GET icanhazdadjoke.com returns the dad joke
        // the API call goes here

        var joke = "Error: could not get a joke from icanhazdadjoke";
        var permalink = "https://icanhazdadjoke.com/";

        using HttpResponseMessage resp = client.GetAsync("https://icanhazdadjoke.com/", HttpCompletionOption.ResponseHeadersRead).Result;
        if (resp.IsSuccessStatusCode)
        {
            var json = resp.Content.ReadAsStringAsync().Result;
            joke = JsonDocument.Parse(json).RootElement.GetProperty("joke").GetString();
            if (joke == null) {
                // does this ever happen?
                joke = "Manufacturing seems like an easy task. I'm a man myself, and I'm using facts.";
                permalink = "https://youtu.be/dQw4w9WgXcQ"; // they're gonna get rickrolled
            } else
            {
                // get the ID of the joke
                var id = JsonDocument.Parse(json).RootElement.GetProperty("id").GetString();
                permalink = "https://icanhazdadjoke.com/j/" + id;
            }
        } else
        {
            return [
                new ListItem(new NoOpCommand()) { Title = "¯\\_(ツ)_/¯ i don't have a joke this time" },
                new ListItem(new DadJokeFinalPage()) { Title = "Try again" },
            ];
        }

        return [
            new ListItem(new NoOpCommand()) { Title = joke },
            new ListItem(new CopyTextCommand(joke)) { Title = "Copy the joke!" },
            new ListItem(new OpenUrlCommand(permalink)) { Title = "Open permalink" },
            new ListItem(new CopyTextCommand(permalink)) { Title = "Copy permalink" },
            new ListItem(new DadJokeFinalPage()) { Title = "Give me another" },
        ];
    }
}
