using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.BotBuilderSamples.Dialogs
{
    public class PullRequestDialog : CancelAndHelpDialog
    {
        

        public PullRequestDialog() : base(nameof(PullRequestDialog))
        {
            
        }
    }
}