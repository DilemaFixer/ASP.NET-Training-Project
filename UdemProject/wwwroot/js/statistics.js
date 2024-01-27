
var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
        fetch('/api/statistics') // Assuming your API endpoint is at /Admin/api/statistics
            .then(response => response.json())
            .then(data => {
                const ctx = document.getElementById('StatisticChart');
                new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: data.data.map(item => item.product),
                        datasets: [{
                            label: 'Count of product views',
                            data: data.data.map(item => item.views),
                            borderWidth: 1,
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
            })
            .catch(error => {
                console.error('Error fetching statistics:', error);
            });
    });
