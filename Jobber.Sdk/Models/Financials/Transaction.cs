﻿using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Financials
{
    public class Transaction
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("bad_debt")]
        public bool BadDebt { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("entry_date")]
        public int EntryDate { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("quote")]
        public int Quote { get; set; }

        [JsonProperty("invoice")]
        public int Invoice { get; set; }

        [JsonProperty("client")]
        public int ClientId { get; set; }
    }
}