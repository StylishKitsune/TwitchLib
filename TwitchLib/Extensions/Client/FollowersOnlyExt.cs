﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;

namespace TwitchLib.Extensions.Client
{
    /// <summary>Extension for implementing followers online mode functionality in TwitchClient</summary>
    public static class FollowersOnlyExt
    {
        // Using variable so it's easily changed if Twitch changes their requirement.
        private static int maximumDurationAllowedDays = 90;

        /// <summary>
        /// Enables follower only chat, requires a TimeSpan object to indicate how long a viewer must have been following to chat. Maximum time is 90 days (3 months).
        /// </summary>
        /// <param name="channel">JoinedChannel object representing which channel to send command to.</param>
        /// <param name="requiredFollowTime">Amount of time required to pass before a viewer can chat. Maximum is 3 months (90 days).</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void ChangeChatColor(this TwitchClient client, JoinedChannel channel, TimeSpan requiredFollowTime)
        {
            if (requiredFollowTime > TimeSpan.FromDays(maximumDurationAllowedDays))
                throw new Exceptions.Client.InvalidParameterException("The amount of time required to chat exceeded the maximum allowed by Twitch, which is 3 months.", client.TwitchUsername);

            string duration = $"{requiredFollowTime.Days}d {requiredFollowTime.Hours}h {requiredFollowTime.Minutes}m";

            client.SendMessage(channel, $".followers {duration}");
        }

        /// <summary>
        /// Enables follower only chat, requires a TimeSpan object to indicate how long a viewer must have been following to chat. Maximum time is 90 days (3 months).
        /// </summary>
        /// <param name="channel">String representing the channel to send the command to.</param>
        /// <param name="requiredFollowTime">Amount of time required to pass before a viewer can chat. Maximum is 3 months (90 days).</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void ChangeChatColor(this TwitchClient client, string channel, TimeSpan requiredFollowTime)
        {
            if (requiredFollowTime > TimeSpan.FromDays(maximumDurationAllowedDays))
                throw new Exceptions.Client.InvalidParameterException("The amount of time required to chat exceeded the maximum allowed by Twitch, which is 3 months.", client.TwitchUsername);

            string duration = $"{requiredFollowTime.Days}d {requiredFollowTime.Hours}h {requiredFollowTime.Minutes}m";

            client.SendMessage(channel, $".followers {duration}");
        }

        /// <summary>
        /// Enables follower only chat, requires a TimeSpan object to indicate how long a viewer must have been following to chat. Maximum time is 90 days (3 months).
        /// </summary>
        /// <param name="requiredFollowTime">Amount of time required to pass before a viewer can chat. Maximum is 3 months (90 days).</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void ChangeChatColor(this TwitchClient client, TimeSpan requiredFollowTime)
        {
            if (requiredFollowTime > TimeSpan.FromDays(maximumDurationAllowedDays))
                throw new Exceptions.Client.InvalidParameterException("The amount of time required to chat exceeded the maximum allowed by Twitch, which is 3 months.", client.TwitchUsername);

            string duration = $"{requiredFollowTime.Days}d {requiredFollowTime.Hours}h {requiredFollowTime.Minutes}m";

            client.SendMessage($".followers {duration}");
        }

        /// <summary>
        /// Disables follower only chat.
        /// </summary>
        /// <param name="channel">JoinedChannel representation of channel to send command to</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void FollowersOnlyOff(this TwitchClient client, JoinedChannel channel)
        {
            client.SendMessage(channel, ".followersoff");
        }

        /// <summary>
        /// Disables follower only chat.
        /// </summary>
        /// <param name="channel">String representation of which channel to send the command to.</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void FollowersOnlyOff(this TwitchClient client, string channel)
        {
            client.SendMessage(".followersoff");
        }

        /// <summary>
        /// Disables follower only chat.
        /// </summary>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void FollowersOnlyOff(this TwitchClient client)
        {
            client.SendMessage(".followersoff");
        }
    }
}
