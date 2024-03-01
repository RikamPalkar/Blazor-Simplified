
using Microsoft.AspNetCore.Components;

namespace Test.Pages
{
    [EventHandler("onBroadcast", typeof(BroadcastEventArgs))]
    public static class EventHandlers
    {
    }

    public class BroadcastEventArgs : EventArgs
    {
        public string data { get; set; }
    }
}

