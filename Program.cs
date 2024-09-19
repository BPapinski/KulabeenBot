using ChwesiukBotV2.commands;
using ChwesiukBotV2.commands.Buttons;
using ChwesiukBotV2.commands.Slash;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChwesiukBotV2
{
    internal class Program
    {
        public static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }

        static async Task Main(string[] args)
        {
            
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();
            //Console.WriteLine(jsonReader.token);

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(discordConfig);

            Client.UseInteractivity(new InteractivityConfiguration(){
                Timeout = TimeSpan.FromMinutes(2)
            });

            Client.Ready += Client_Ready;
            Client.ComponentInteractionCreated += Client_ComponentInteractionCreated;


            // Command Config Configuration
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {jsonReader.prefix},
                EnableMentionPrefix = true,
                EnableDms = true,
                // a lot of available setting here
                EnableDefaultHelp = false,

            };
            
            Commands = Client.UseCommandsNext(commandsConfig);


            // Enabling Client to use slash commands
            var slashCommandsConfiguration = Client.UseSlashCommands();

            // Registering prefix commands
            Commands.RegisterCommands<TestCommands>(); 
            Commands.RegisterCommands<Interactivity>();
            Commands.RegisterCommands<InteractionComponents>();

            // Registering slash commands
            slashCommandsConfiguration.RegisterCommands<BasicSL>();
            slashCommandsConfiguration.RegisterCommands<Calculator>();

            //Registering Buttons commands
            Commands.RegisterCommands<UnderstandingButtons>();

            await Client.ConnectAsync();
            await Task.Delay(-1); // keeps bot online infinitly ( as long as program is running)
        }

        // Buttons Interactions section

        private static async Task Client_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs args)
        {
            switch (args.Interaction.Data.CustomId)
            {
                case "button1":
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Button1 has been pressed by {args.User.Username}"));
                    break;
                case "button2":
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Button2 has been pressed by {args.User.Username}"));
                    break;
                case "basicsButton":
                    await args.Interaction.DeferAsync();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("!test ---> Sends basic message");
                    sb.AppendLine("!embed ---> Sends a basic embed message");
                    sb.AppendLine("!calculator ---> Performs an operation on 2 numbers");
                    var basicCommandsEmbed = new DiscordEmbedBuilder
                    {
                        Color = DiscordColor.Black,
                        Title = "Basic Commands",
                        Description = sb.ToString()
                    };
                    await args.Interaction.EditOriginalResponseAsync(new DiscordWebhookBuilder().AddEmbed(basicCommandsEmbed));
                    break;
                case "calculatorButton":
                    await args.Interaction.DeferAsync();
                    StringBuilder sb2 = new StringBuilder();
                    sb2.AppendLine("/calculator Add ---> Adds 2 numbers");
                    sb2.AppendLine("/calculator Subrtact ---> Subrtact 2 numbers");;
                    var calculatorCommandsEmbed = new DiscordEmbedBuilder
                    {
                        Color = DiscordColor.Black,
                        Title = "Basic Commands",
                        Description = sb2.ToString()
                    };
                    await args.Interaction.EditOriginalResponseAsync(new DiscordWebhookBuilder().AddEmbed(calculatorCommandsEmbed)); 
                    break;
            }
        }

        // ends here

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
