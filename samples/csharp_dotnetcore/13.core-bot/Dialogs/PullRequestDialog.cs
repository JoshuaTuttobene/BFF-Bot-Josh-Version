using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Dialogs
{
    public class PullRequestDialog : CancelAndHelpDialog
    {
        private const string RepositoryStepMsgText = "Which repository would you like to see pull requests from?";
        private const string StateStepMsgText = "Would you like to see the open, closed, or all pull requests?";

        public PullRequestDialog() : base(nameof(PullRequestDialog))
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                RepositoryStepAsync,
                StateStepAsync,
                ConfirmStepAsync,
                FinalStepAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }


        private async Task<DialogTurnResult> RepositoryStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var PullRequestDetails = (PullRequestDetails)stepContext.Options;

            if (PullRequestDetails.Repository ==  null)
            {
                var promptMessage = MessageFactory.Text(RepositoryStepMsgText, RepositoryStepMsgText, InputHints.ExpectingInput);
                return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
            }

            return await stepContext.NextAsync(PullRequestDetails.Repository, cancellationToken);

        }


        private async Task<DialogTurnResult> StateStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var PullRequestDetails = (PullRequestDetails)stepContext.Options;

            if (PullRequestDetails.State == null)
            {
                var promptMessage = MessageFactory.Text(StateStepMsgText, StateStepMsgText, InputHints.ExpectingInput);
                return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
            }

            return await stepContext.NextAsync(PullRequestDetails.State, cancellationToken);

        }

        private async Task<DialogTurnResult> ConfirmStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var PullRequestDetails = (PullRequestDetails)stepContext.Options;


            var messageText = $"Please confirm, you want to view {PullRequestDetails.State} pull requests from {PullRequestDetails.Repository}. Is this correct?";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);

            return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }


        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if ((bool)stepContext.Result)
            {
                var PullRequestDetails = (PullRequestDetails)stepContext.Options;

                return await stepContext.EndDialogAsync(PullRequestDetails, cancellationToken);
            }

            return await stepContext.EndDialogAsync(null, cancellationToken);
        }


        

    }
}