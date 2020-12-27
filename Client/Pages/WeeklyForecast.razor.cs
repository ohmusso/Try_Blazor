using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Try_Blazor.Shared;

namespace Try_Blazor.Client.Pages{
    public partial class WeeklyForecast : ComponentBase{
        [Inject] HttpClient http { get; set; }
        private WeatherForecast[] forecasts;
        protected override async Task OnInitializedAsync()
        {
            forecasts = await http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }

        void HandleItemSelected(DayOfWeek selectedValue){
            foreach( var item in forecasts ){
                item.Selected = false;
            }

            forecasts.First( f => f.Date.DayOfWeek == selectedValue).Selected = true;
        }
    }
}