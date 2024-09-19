using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Buttons
{
    public class UnderstandingButtons : BaseCommandModule
    {
        [Command("button")]
        public async Task Buttons(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.CornflowerBlue,
                Title = "Title",
            };

            var button = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Danger, "button1", "Button1", false, null);
            var button2 = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Danger, "button2", "Button2", false, null);

            var message = new DiscordMessageBuilder().AddEmbed(embed).AddComponents(button, button2);

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
