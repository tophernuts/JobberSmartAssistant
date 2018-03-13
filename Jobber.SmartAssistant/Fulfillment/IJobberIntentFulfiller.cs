﻿using System.Threading.Tasks;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;

namespace Jobber.SmartAssistant.Fulfillment
{
    public interface IJobberIntentFulfiller
    {
        bool CanFulfill(FulfillmentRequest fulfillmentRequest);
        Task<FullfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService);
    }
}