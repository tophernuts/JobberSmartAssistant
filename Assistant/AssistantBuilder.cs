﻿using System;
using Assistant.BuiltIns;
using Assistant.Core;
using Microsoft.AspNetCore.Hosting;

namespace Assistant
{
    public class AssistantBuilder
    {
        private IIntentRegistry intentRegistry;
        private IIntentSynchronizer intentSynchronizer;
        private IAuthenticationExtractor authenticationExtractor;
        private IIntentFulfiller intentFulfiller;
        private IWebHostBuilder webHostBuilder;

        public AssistantBuilder()
        {
            authenticationExtractor = new HeaderBasedAuthenticationExtractor();
        }

        public AssistantBuilder UseIntentRegistry(IIntentRegistry intentRegistry)
        {
            this.intentRegistry = intentRegistry;
            return this;
        }

        public AssistantBuilder UseIntentSynchronizer(IIntentSynchronizer intentSynchronizer)
        {
            this.intentSynchronizer = intentSynchronizer;
            return this;
        }

        public AssistantBuilder UseAuthenticationExtractor(IAuthenticationExtractor authenticationExtractor)
        {
            this.authenticationExtractor = authenticationExtractor;
            return this;
        }

        public AssistantBuilder UseIntentFulfiller(IIntentFulfiller intentFulfiller)
        {
            this.intentFulfiller = intentFulfiller;
            return this;
        }

        public AssistantBuilder UseWebHostBuilder(IWebHostBuilder webHostBuilder)
        {
            this.webHostBuilder = webHostBuilder;
            return this;
        }

        public Assistant Build()
        {
            if (intentRegistry == null || intentSynchronizer == null ||
                authenticationExtractor == null || intentFulfiller == null ||
                webHostBuilder == null)
            {
                throw new Exception();
            }
            
            return new Assistant(intentRegistry, intentSynchronizer, 
                authenticationExtractor, intentFulfiller, webHostBuilder);
        }
    }
}