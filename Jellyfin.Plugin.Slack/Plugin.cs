using System;
using System.Collections.Generic;
using Jellyfin.Plugin.Slack.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Slack
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public override string Name => "Slack Notifications";

        public IEnumerable<PluginPageInfo> GetPages() =>
            new[]
            {
                new PluginPageInfo
                {
                    Name = "slacknotifications",
                    EmbeddedResourcePath = GetType().Namespace + ".Web.slacknotifications.html",
                },
                new PluginPageInfo
                {
                    Name = "slacknotificationsjs",
                    EmbeddedResourcePath = GetType().Namespace + ".Web.slacknotifications.js"
                }
            };

        public override string Description => "Sends notifications to Slack.";

        private readonly Guid _id = new Guid("94FB77C3-55AD-4C50-BF4E-4E5497467B79");
        public override Guid Id => _id;

        public static Plugin Instance { get; private set; }
    }
}
