using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.BotBuilderSamples.Dialogs
{
    public class PullRequestDetails
    {
        public string PullRequest { get; set; }

        public string Repository { get; set; }

        public string State { get; set; }
    }
}