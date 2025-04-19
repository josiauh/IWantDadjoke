// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.ComponentModel;

namespace DadJokeExtension;

internal sealed partial class DadJokeExtensionPage : ListPage
{
    public DadJokeExtensionPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        Title = "I Can Haz Dad Joke";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        return [
            new ListItem(new DadJokeFinalPage()) { Title = "Get a random joke" },
            new ListItem(new OpenUrlCommand("https://github.com/josiauh/IWantDadjoke/")) { Title = "This is not an official extension." }
        ];
    }
}
