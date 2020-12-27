using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Try_Blazor.Client.Pages
{
    public class PositionOptions{
        public bool EnableHighAccuracy { get; set;} = false;
        public int Timeout { get; set;}
        public int MaximumAge { get; set;} = 0;
    }
    public class Coords{
        public double latitude { get; set; }
        public double longitude { get; set; }        
    }
    public class Position{
        public Coords coords { get; set; }
        public DateTime timestamp { get; set;}
    }
    public enum PositionError {
        PERMISSION_DENIED = 1,
        POSITION_UNAVAILABLE,
        TIMEOUT
    }
    public class Geolocation
    {
        private readonly IJSRuntime js;
        public Geolocation(IJSRuntime js){
            this.js = js;
        }
        public Action<Position> OnGetPosition;
        [JSInvokable]
        public void RaiseOnGetPosition(Position p) =>
            OnGetPosition?.Invoke(p);
        public Action<PositionError> OnGetPositionError;
        [JSInvokable]
        public void RaiseOnGetPositionError(PositionError err) =>
            OnGetPositionError?.Invoke(err);
        public async ValueTask GetCurrentPosition(
            Action<Position> onSuccess,
            Action<PositionError> onError,
            PositionOptions options = null
        ){
            OnGetPosition = onSuccess;
            OnGetPositionError = onError;
            await js.InvokeVoidAsync(
                "blazorGeolocation.getCurrentPosition",
                DotNetObjectReference.Create(this),
                options
            );
        }

        public async ValueTask<bool> HasGeolocation() => 
            await js.InvokeAsync<bool>("blazorGeolocation.hasGeolocationFeature");
    }
}
