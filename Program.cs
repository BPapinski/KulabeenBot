﻿using ChwesiukBotV2.commands;
using ChwesiukBotV2.commands.Slash;
using DSharpPlus;
using DSharpPlus.CommandsNext;
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

            // Registering slash commands
            slashCommandsConfiguration.RegisterCommands<BasicSL>();
            slashCommandsConfiguration.RegisterCommands<Calculator>();

            await Client.ConnectAsync();
            await Task.Delay(-1); // keeps bot online infinitly ( as long as program is running)
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
