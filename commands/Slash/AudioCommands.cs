using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.VoiceNext;
using System;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Slash
{
    public class AudioCommands : ApplicationCommandModule
    {
        [SlashCommand("join", "Makes the bot join your vc")]
        public async Task Join(InteractionContext ctx)
        {
            await ctx.DeferAsync();

            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = "Bot notification",
                Description = $"Successfully joined to a channel",
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed)); // this line has to be placed before "await channel.ConnectAsync();" beacause it causes throwing error

            var channel = ctx.Member?.VoiceState?.Channel;
            if (channel == null)
                throw new ArgumentNullException();

            VoiceNextConnection connection = await channel.ConnectAsync();
        }


        [SlashCommand("leave", "Makes the bot leave your vc")]
        public async Task Leave(InteractionContext ctx)
        {
            var vnext = ctx.Client.GetVoiceNext();
            var connection = vnext.GetConnection(ctx.Guild);

            connection.Disconnect();

            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Red,
                Title = "Bot notification",
                Description = $"Successfully left a channel",
            };

            var message = new DiscordMessageBuilder().AddEmbed(outputEmbed);

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
