using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Slash
{
    [SlashCommandGroup("calculator", "Perform calculator operations")]
    public class Calculator : ApplicationCommandModule
    {
        [SlashCommand("add", "add two numbers together")]
        public async Task Add(InteractionContext ctx, [Option("number1", "Number 1")] double number1, [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();

            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = $"{number1} + {number2}",
                Description = $"{number1 + number2}"
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed).WithContent("Calculator"));

        }

        [SlashCommand("subrtact", "subrtact two numbers together")]
        public async Task Subrtact(InteractionContext ctx, [Option("number1", "Number 1")] double number1, [Option("number2", "Number 2")] double number2)
        {
            await ctx.DeferAsync();

            var outputEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Green,
                Title = $"{number1} - {number2}",
                Description = $"{number1 - number2}"
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(outputEmbed).WithContent("Calculator"));

        }
    }
}
