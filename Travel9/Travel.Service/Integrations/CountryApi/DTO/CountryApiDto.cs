using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Service.Integrations.CountryApi.DTO
{
    public class CountryApiDto
    {

        [JsonProperty("error")] public bool Error { get; set; }
        [JsonProperty("msg")] public string Msg { get; set; } = ""; // '= ""' Betekent dat je de objecten standaard als null invult
        [JsonProperty("data")] public List<CountryItem> Data { get; set; } = new(); // Je gaat de data die je krijgt omzetten naar een list
    }

    public class CountryItem
    {
        [JsonProperty("name")] public string Name { get; set; } = "";
        [JsonProperty("code")] public string Code { get; set; } = "";

    }
}
