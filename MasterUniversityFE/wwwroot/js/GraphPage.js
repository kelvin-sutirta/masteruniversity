
$(document).ready(function () {

    $.ajax({
        method: "POST",
        url: '/Graph/GraphInsert',
        data: JSON.stringify({}),
        dataType: "json",
        success: function (result) {
            if (result.success) {
                if (result.data.length > 0) {
                    JSON.stringify(data);
                }
                const myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ['Critical', 'Major', 'Minor'],
                        datasets: [{
                            label: 'Based On Category',
                            data: [critical, major, minor],
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255, 99, 132, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        }, legend: {
                            display: false
                        }, title:
                        {
                            display: true,
                            text: "Based On Category"
                        }, animation: {
                            onComplete: function () {
                                chartImage = myChart.toBase64Image();
                            }
                        }
                    }
                });
            }
        },
        error: function (error) {
            $('#loadeux').css('display', 'none');
            msgError(error);
        }


    })
});






Highcharts.chart('container', {
    chart: {
        type: 'line'
    },
    title: {
        text: 'Monthly Average Temperature'
    },
    subtitle: {
        text: 'Source: ' +
            '<a href="https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature" ' +
            'target="_blank">Wikipedia.com</a>'
    },
    xAxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    },
    yAxis: {
        title: {
            text: 'Temperature (°C)'
        }
    },
    plotOptions: {
        line: {
            dataLabels: {
                enabled: true
            },
            enableMouseTracking: false
        }
    },
    series: [{
        name: 'Reggane',
        data: [16.0, 18.2, 23.1, 27.9, 32.2, 36.4, 39.8, 38.4, 35.5, 29.2,
            22.0, 17.8]
    }, {
        name: 'Tallinn',
        data: [-2.9, -3.6, -0.6, 4.8, 10.2, 14.5, 17.6, 16.5, 12.0, 6.5,
            2.0, -0.9]
    }]
});
