// Function to handle switching between individual and total performance views
function totalPerformanceChart() { 
document.getElementById('individualViewBtn').addEventListener('click', function () {
    // Show the individual vehicle performance section
    document.getElementById('vehiclePerformanceSection').style.display = 'block';
    // Hide the total performance section
    document.getElementById('totalPerformanceSection').style.display = 'none';

    // Switch button styles
    document.getElementById('individualViewBtn').classList.add('active');
    document.getElementById('totalViewBtn').classList.remove('active');
});

document.getElementById('totalViewBtn').addEventListener('click', function () {
    // Hide the individual vehicle performance section
    document.getElementById('vehiclePerformanceSection').style.display = 'none';
    // Show the total performance section
    document.getElementById('totalPerformanceSection').style.display = 'block';

    // Switch button styles
    document.getElementById('individualViewBtn').classList.remove('active');
    document.getElementById('totalViewBtn').classList.add('active');
});
// Get context for Active Hours Chart
var activeCtx = document.getElementById('totalActivePerformanceChart').getContext('2d');
var activePerformanceData = @Html.Raw(Json.Serialize(Model.VehiclePerformanceData.Select(v => v.VehiclePlate).ToArray()));
var activeHoursData = @Html.Raw(Json.Serialize(Model.VehiclePerformanceData.Select(v => v.WeeklyData.Select(wd => wd.Ratio * 100).ToArray()).ToArray()));

// Active Hours Chart
var totalActivePerformanceChart = new Chart(activeCtx, {
    type: 'bar', // Bar chart for active hours
    data: {
        labels: activePerformanceData, // Vehicle Plates
        datasets: [{
            label: 'Active Hours / Total Hours',
            data: activeHoursData.flat(), // Flattened array of active hours data
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        scales: {
            y: {
                beginAtZero: true,
                max: 100,
                ticks: {
                    stepSize: 10,
                    callback: function (value) {
                        return value + '%';
                    }
                }
            }
        },
        plugins: {
            legend: { display: true },
            datalabels: {
                anchor: 'end',
                align: 'top',
                formatter: function (value) { return value.toFixed(0) + '%'; },
                color: '#000'
            }
        }
    },
    plugins: [ChartDataLabels]
});

// Get context for Idle Hours Chart
var idleCtx = document.getElementById('totalIdlePerformanceChart').getContext('2d');
var idleHoursData = @Html.Raw(Json.Serialize(Model.VehiclePerformanceData.Select(v => v.WeeklyData.Select(wd => (168 - (wd.ActiveHours + wd.MaintenanceHours)) / 168 * 100).ToArray()).ToArray()));

// Idle Hours Chart
var totalIdlePerformanceChart = new Chart(idleCtx, {
    type: 'line', // Line chart for idle hours
    data: {
        labels: activePerformanceData, // Vehicle Plates
        datasets: [{
            label: 'Idle Hours / Total Hours',
            data: idleHoursData.flat(), // Flattened array of idle hours data
            borderColor: 'rgba(255, 159, 64, 1)',
            backgroundColor: 'rgba(255, 159, 64, 0.2)',
            borderWidth: 2,
            fill: false,  // No fill for the line chart
            tension: 0.3  // Smooth curves for the line
        }]
    },
    options: {
        responsive: true,
        scales: {
            y: {
                beginAtZero: true,
                max: 100,
                ticks: {
                    stepSize: 10,
                    callback: function (value) {
                        return value + '%';
                    }
                }
            }
        },
        plugins: {
            legend: { display: true },
            datalabels: {
                anchor: 'end',
                align: 'top',
                formatter: function (value) { return value.toFixed(0) + '%'; },
                color: '#000'
            }
        }
    },
    plugins: [ChartDataLabels]
});
}