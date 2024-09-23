using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChwesiukBotV2.commands.Components
{
    public class DiscordComponentsCommands : BaseCommandModule
    {


        [Command("dropdown-list")]
        public async Task DropdownList(CommandContext ctx)
        {
            List<DiscordSelectComponentOption> optionList = new List<DiscordSelectComponentOption>();

            optionList.Add(new DiscordSelectComponentOption("Option 1", "o1")); // label , "id"
            optionList.Add(new DiscordSelectComponentOption("Option 2", "o2")); // label , "id"
            optionList.Add(new DiscordSelectComponentOption("Option 3", "o3")); // label , "id"

            var options = optionList.AsEnumerable();

            var dropDown = new DiscordSelectComponent("dropDownList", "Select...", options);

            var dropDownMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Gold)
                    .WithTitle("This embed has a drop-down list on it"))
                    .AddComponents(dropDown);
            await ctx.Channel.SendMessageAsync(dropDownMessage);
        }

        [Command("channel-list")]
        public async Task ChannelList(CommandContext ctx)
        {
            var channelComponent = new DiscordChannelSelectComponent("channelDropDownList", "Select...");

            var dropDownMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Gold)
                    .WithTitle("This embed has a channel drop-down list on it"))
                    .AddComponents(channelComponent);
            await ctx.Channel.SendMessageAsync(dropDownMessage);
        }

        [Command("mention-list")]
        public async Task MentionlList(CommandContext ctx)
        {
            var mentionComponent = new DiscordMentionableSelectComponent("mentionDropDownList", "Select...");
            var dropDownMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Gold)
                    .WithTitle("This embed has a mention drop-down list on it"))
                    .AddComponents(mentionComponent);
            await ctx.Channel.SendMessageAsync(dropDownMessage);
        }
    }
}
