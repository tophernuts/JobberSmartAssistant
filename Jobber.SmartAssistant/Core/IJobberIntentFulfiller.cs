﻿using System.Threading.Tasks;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;

namespace Jobber.SmartAssistant.Core
{
    public interface IJobberIntentFulfiller
    {
        bool CanFulfill(FulfillmentRequest fulfillmentRequest);
        Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService);
    }
}