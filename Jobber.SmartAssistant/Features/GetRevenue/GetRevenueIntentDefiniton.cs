﻿using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;
using DialogFlow.Sdk.Models.Common;

namespace Jobber.SmartAssistant.Features.GetRevenue
{
    public class GetRevenueIntentDefiniton : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetRevenue)
               .TriggerOn("Get revenue")
               .TriggerOn($"Get revenue from [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]")
               .TriggerOn("How much money we made")
               .TriggerOn($"How much money we made [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]")
               .TriggerOn("How much were we paid")
               .TriggerOn($"How much were we paid [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]")
               .WithOptionalParameter(ParameterBuilder.Of(Constants.Variables.TimeUnit, Entity.DatePeriod))
               .WithOptionalParameter(ParameterBuilder.Of(Constants.Variables.TimeUnitOriginal, Entity.DatePeriod, Constants.Variables.TimeUnit))
               .FulfillWithWebhook()
               .Build();
        }
    }
}
