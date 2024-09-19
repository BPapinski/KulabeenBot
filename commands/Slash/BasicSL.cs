using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("test", "This is my first slash command")]
        public async Task myFirstSlashCommand(InteractionContext ctx)
        {
            await ctx.DeferAsync();

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Hello World"));
        }

        [SlashCommand("embed", "send Embed using slash command")]
        public async Task sendEmbed(InteractionContext ctx)
        {
            await ctx.DeferAsync(); // sending empty response

            var emberMessage = new DiscordEmbedBuilder { 
                Color = DiscordColor.Blue,
                Title = "title" 
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(emberMessage)); // editting response
        }

        [SlashCommand("mix", "sends embed with a message")]
        public async Task sendEmbedWithMessage(InteractionContext ctx)
        {
            await ctx.DeferAsync();

            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Azure,
                Title = "my Embed"
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage).WithContent("Hi"));
        }

        [SlashCommand("MakeYourEmbed", "Allows you to make your own embed message")]
        public async Task SlashCommandParameters(InteractionContext ctx, [Option("EmbedContent", "Type in anything you want")] string testParameter) // there is a lot of other thing that can be attached to discord message as file, user or anything
        {
            await ctx.DeferAsync();

            var embedMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Azure,
                Title = "Embed With Your Content",
                Description = testParameter
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embedMessage));
        }

        [SlashCommand("CastUser", "Allows you to cast specific server member to discord user")]
        public async Task CastingUser(InteractionContext ctx, [Option("user", "Pass in a Discord User")] DiscordUser user)
        {
            await ctx.DeferAsync();

            var discordMember = (DiscordMember)user; // casting discord user (global discord user) to discord member (member of specific discord server )

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"discordMember nickname: {discordMember.Nickname},\n discordMember username: {discordMember.Username}\n discordUser username: {user.Username}"));
        }
    }
}
