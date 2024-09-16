using ChwesiukBotV2.commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChwesiukBotV2
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
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

            Client.Ready += Client_Ready;


            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {jsonReader.prefix},
                EnableMentionPrefix = true,
                EnableDms = true,
                // a lot of available setting here
                EnableDefaultHelp = false,

            };
            
            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<TestCommands>(); 

            await Client.ConnectAsync();
            await Task.Delay(-1); // keeps bot online infinitly ( as long as program is running)
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
