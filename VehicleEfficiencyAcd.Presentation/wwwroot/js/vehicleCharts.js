export class VehicleChart {
    constructor(vehicleData) {
        this.vehicleData = vehicleData;
    }

    createActiveHoursChart(ctx, weeklyData) {
        return new Chart(ctx, {
            type: 'bar',
            data: {
                labels: weeklyData.map(wd => wd.Week),
                datasets: [{
                    label: 'Active Hours / Total Hours',
                    data: weeklyData.map(wd => wd.Ratio * 100),
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }]
            },
            options: this.getChartOptions()
        });
    }

    createIdleTimeChart(ctx, weeklyData) {
        return new Chart(ctx, {
            type: 'bar',
            data: {
                labels: weeklyData.map(wd => wd.Week),
                datasets: [{
                    label: 'Idle Time / Total Hours',
                    data: weeklyData.map(wd =>
                        (168 - (wd.ActiveHours + wd.MaintenanceHours)) / 168 * 100
                    ),
                    backgroundColor: 'rgba(255, 159, 64, 0.2)',
                    borderColor: 'rgba(255, 159, 64, 1)',
                    borderWidth: 1
                }]
            },
            options: this.getChartOptions()
        });
    }

    getChartOptions() {
        return {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    max: 100,
                    ticks: {
                        stepSize: 10,
                        callback: value => value + '%'
                    }
                }
            },
            plugins: {
                legend: { display: false },
                datalabels: {
                    anchor: 'end',
                    align: 'top',
                    formatter: value => value.toFixed(0) + '%',
                    color: '#000'
                }
            }
        };
    }
}