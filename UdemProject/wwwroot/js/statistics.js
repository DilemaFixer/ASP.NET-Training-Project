
document.addEventListener('DOMContentLoaded', function () {
    loadDataTable(); // Вызываем функцию отображения статистики
});

function loadDataTable(statisticNams , statisticValues) {
    const ctx = document.getElementById('StatisticChart');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: statisticNams,
            datasets: [{
                label: 'Count of views',
                data: statisticValues,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    });
