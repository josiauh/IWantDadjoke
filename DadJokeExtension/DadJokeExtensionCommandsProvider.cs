// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DadJokeExtension;

public partial class DadJokeExtensionCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public DadJokeExtensionCommandsProvider()
    {
        DisplayName = "I Can Haz Dad Joke";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new DadJokeExtensionPage()) { Title = DisplayName, Subtitle = "Not affiliated with the icanhazdadjoke API." },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
