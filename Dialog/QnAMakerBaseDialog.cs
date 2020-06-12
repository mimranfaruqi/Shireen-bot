// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Dialog
{
    /// <summary>
    /// QnAMaker action builder class
    /// </summary>
    public class QnAMakerBaseDialog : QnAMakerDialog
    {
        // Dialog Options parameters
        public const string DefaultNoAnswer = "Thank you for query we will never update you lol.";
        public const string DefaultCardTitle = "Did you mean:";
        public const string DefaultCardNoMatchText = "None of the above.";
        public const string DefaultCardNoMatchResponse = "Thanks for the feedback.";

        private readonly IBotServices _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="QnAMakerBaseDialog"/> class.
        /// Dialog helper to generate dialogs.
        /// </summary>
        /// <param name="services">Bot Services.</param>
        // email code
        public QnAMakerBaseDialog(IBotServices services): base()
        {
            this._services = services;
        }

        protected async override Task<IQnAMakerClient> GetQnAMakerClientAsync(DialogContext dc)
        {
            return this._services?.QnAMakerService;
        }

        protected override Task<QnAMakerOptions> GetQnAMakerOptionsAsync(DialogContext dc)
        {
            return Task.FromResult(new QnAMakerOptions
            {
                ScoreThreshold = DefaultThreshold,
                Top = DefaultTopN,
                QnAId = 0,
                RankerType = "Default",
                IsTest = false
            });
        }

        protected async override Task<QnADialogResponseOptions> GetQnAResponseOptionsAsync(DialogContext dc)
        {
            var noAnswer = (Activity)Activity.CreateMessageActivity();
            noAnswer.Text = DefaultNoAnswer;

            var cardNoMatchResponse = (Activity)MessageFactory.Text(DefaultCardNoMatchResponse);
      
      var serverId = 33396;
var injectionApiKey = "Ha92BgEx8w5W4Kdk6Q3J";

var client = new SocketLabsClient(serverId, injectionApiKey);

var message = new BasicMessage();

message.Subject = "Sending A Basic Message";
message.HtmlBody = "<html>This is the Html Body of my message.</html>";
message.PlainTextBody = "This is the Plain Text Body of my message.";
message.From.Email = "shireeniqbal02@yahoo.com";
message.To.Add("shireeniqbal02@gmail.com");

var response = client.Send(message);


            var responseOptions = new QnADialogResponseOptions
            {
                ActiveLearningCardTitle = DefaultCardTitle,
                CardNoMatchText = DefaultCardNoMatchText,
                NoAnswer = noAnswer,
                CardNoMatchResponse = cardNoMatchResponse,
               
            };

            return responseOptions;
        }
    }
}
