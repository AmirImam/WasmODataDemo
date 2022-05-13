using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using WasmODataDemo.WebUI;
using WasmODataDemo.WebUI.Shared;
using Simple.OData.Client;
using WasmODataDemo.Entities;

namespace WasmODataDemo.WebUI.Pages
{
    public partial class Index
    {
        private string Url => "https://localhost:7208/odata/";
        private ODataClient client;
        private IBoundClient<Product> bounder;
        private ODataClientSettings settings;
        private List<Product> productsList = new();
        
        private HttpClient http = new();
        protected override async Task OnInitializedAsync()
        {
            settings = new ODataClientSettings();
            settings.PreferredUpdateMethod = ODataUpdateMethod.Put;
            settings.IgnoreUnmappedProperties = true;
            settings.BaseUri = new Uri(Url);

            client = new ODataClient(settings);
            bounder = client.For<Product>();
        }

        public async void ODataLoad()
        {
            productsList = (await bounder.FindEntriesAsync()).ToList();
            StateHasChanged();
        }

        private async void HttpLoad()
        {
            productsList = (await http.GetFromJsonAsync<JsonRoot>($"{Url}Product")).value;
            StateHasChanged();
        }

        private void Clear() => productsList.Clear();
    }

    public class JsonRoot
    {
        public List<Product> value { get; set; }
    }
}