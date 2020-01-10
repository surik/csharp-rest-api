﻿using System;
using MessageBird;
using MessageBird.Exceptions;
using System.Linq;
using MessageBird.Objects.Voice;

namespace Examples.Webhooks
{
    internal class ViewWebhook
    {
        const string YOUR_ACCESS_KEY = "YOUR_ACCESS_KEY";

        internal static void Main(string[] args)
        {
            var client = Client.CreateDefault(YOUR_ACCESS_KEY);

            try
            {
                string webhookId = "WEBHOOK ID";
                var webhookResponse = client.ViewWebhook(webhookId);

                var webhook = webhookResponse.Data.FirstOrDefault();
                Console.WriteLine("The Webhook Id is: {0}", webhook.Id);
                Console.WriteLine("The Webhook URL is: {0}", webhook.url);
                Console.WriteLine("The Webhook Token is: {0}", webhook.token);
            }
            catch (ErrorException e)
            {
                // Either the request fails with error descriptions from the endpoint.
                if (e.HasErrors)
                {
                    foreach (var error in e.Errors)
                    {
                        Console.WriteLine("code: {0} description: '{1}' parameter: '{2}'", error.Code, error.Description, error.Parameter);
                    }
                }
                // or fails without error information from the endpoint, in which case the reason contains a 'best effort' description.
                if (e.HasReason)
                {
                    Console.WriteLine(e.Reason);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
