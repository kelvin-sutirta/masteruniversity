
$(document).ready(function(){
   /* beberapa cara ajax yg gw coba"
    $.ajax({
        method: "POST",
        url: '/Graph/GraphInsert',
        data: JSON.stringify({}),
        contentType:"application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
           // debugger
            var values = json.graphInsert;
            var dataamountc = values[0];
            var averagea = values[1];

            Highcharts.chart('container', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Ini adalah uji coba'
                },
                subtitle: {
                    text: 'Source: ' +
                        '<a href="https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature" ' +
                        'target="_blank">Wikipedia.com</a>'
                },
                xAxis: {
                    categories: dataamountc
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
                    data: dataamountc
                }, {
                    name: 'Tallinn',
                    data: [-2.9, -3.6,]
                }]
            });

        }

        })  
        */
   /* 
    $.ajax({
        method: "GET",
        url: '/Graph/GraphInsert',
        data: JSON.stringify({}),
        dataType: "json",
        async: false,
    })
        .done(function (data) {
            console.log(data);
            JSON.stringify(data);
            console.log(data.averagePerformanceSpeed);

       
        })
        */


});
