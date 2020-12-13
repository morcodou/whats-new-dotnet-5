using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WiredBrainCoffee.Api.Hubs
{
    public class ChatHubFilter : IHubFilter
    {
        public async ValueTask<object> InvokeMethodAsync
            (HubInvocationContext invocationContext, Func<HubInvocationContext, 
                ValueTask<object>> next)
        {
            var messageText = JsonConvert.SerializeObject(invocationContext.HubMethodArguments);

            Debug.WriteLine("Conversation log ", messageText);

            Debug.WriteLine("Before the Hub execution");

            var nexRun = await next(invocationContext);

            Debug.WriteLine("After the Hub execution");

            return nexRun;
        }

    }
}
