﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAssignedVisitsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetAssignedVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var userId = fulfillmentRequest.GetCurrentUserId();
            var visits = await jobberClient.GetTodayAssignedVisitsAsync(userId);
            
            switch (visits.Count)
            {
                case 0:
                    return BuildNoVisitResponse();
                case 1:
                    return BuildVisitFoundResponse(visits.Visits.First());
                default:
                    return buildMultipleVisitsFoundResponse(visits);
            }
        }

        private static FulfillmentResponse BuildNoVisitResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You don't have any assigned visits today.")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildVisitFoundResponse(Visit visit) 
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have one visit today. {visit.Description}")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse buildMultipleVisitsFoundResponse(VisitsCollections visits)
        {
            // This is temporary, need to specify date range
            var first2_visits = visits.Visits.Take(2);
            StringBuilder sb = new StringBuilder();
            foreach (Visit visit in first2_visits)
            {
                sb.Append(visit.Description + ". ");
            }
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {visits.Count} visits today. Visits include: {sb.ToString()}")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}