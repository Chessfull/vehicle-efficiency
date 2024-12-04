using Microsoft.AspNetCore.SignalR;

namespace VehicleEfficiencyAcd.Presentation.SignalR
{
    public class VehiclePerformanceHub : Hub // -> I createad this part for possible live data updates maybe next operations ...
    {
        public async Task NotifyChartDataUpdated()
        {
            await Clients.All.SendAsync("ReceiveChartDataUpdate");
        }
    }
}
