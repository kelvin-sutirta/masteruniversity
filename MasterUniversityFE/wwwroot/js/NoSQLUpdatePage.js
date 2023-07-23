
$("#buttonPerfUpdateNoSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfUpdateNoSQL();
      GetChart();
    }

});
function buttonPerfUpdateNoSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/NoSQL/NoSQLUpdatePerformance',
        data: { TestCases: TestCases },
        dataType: "json",
        async: false,
    })
        .done(function (data) {
            JSON.stringify(data);
            $('#perfresultsdata').html('Data Processed : ' + data.dataProcessed);
            $('#perfresultshour').html('Hours : ' + data.hours);
            $('#perfresultsminute').html('Minutes : ' + data.minutes);
            $('#perfresultssec').html('Seconds : ' + data.seconds);
            $('#perfresultsmilisec').html('MiliSeconds : ' + data.miliSeconds);
            $('#perfresults').html('Average Time : ' + data.averageTime);
        })

    NoSQLUpdateList();
}
function NoSQLUpdateList() {
    var TestCases = $('#dataAmount').val()
    $("#tblNoSQLUpdateList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/NoSQL/ListNoSQLUpdate',
            "data": { TestCases: TestCases },
        },
        "columns": [
            { data: 'id', visible: false },
            { data: 'dataProcessed' },
            { data: 'hours' },
            { data: 'minutes' },
            { data: 'seconds' },
            { data: 'miliSeconds' },
            { data: 'averageTime' },
        ],
        "order": [[0, "desc"]],
        "paging": true,
        "pagingType": "simple_numbers",
        "searching": false,
        "info": false
    });
}

function GetChart() {
    var formData = new FormData();
    var onek = 0;
    var fivek = 0;
    var tenk = 0;
    var fiftyk = 0;
    var hundredk = 0;
    var oneknosql = 0;
    var fiveknosql = 0;
    var tenknosql = 0;
    var fiftyknosql = 0;
    var hundredknosql = 0;
    $.ajax({
        method: "POST",
        url: '/Graph/GraphUpdate',
        contentType: false,
        processData: false,
        data: formData,
        dataType: "json",
        success: function (result) {
            if (result.success) {
                onek = result.data[0].oneK;
                fivek = result.data[0].fiveK;
                tenk = result.data[0].tenK;
                fiftyk = result.data[0].fiftyK;
                hundredk = result.data[0].hundredK;

                oneknosql = result.data[1].oneK;
                fiveknosql = result.data[1].fiveK;
                tenknosql = result.data[1].tenK;
                fiftyknosql = result.data[1].fiftyK;
                hundredknosql = result.data[1].hundredK;
                const myChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: ['1.000', '5.000', '10.000', '50.000', '100.000'],
                        datasets: [
                            {
                                label: 'MS SQL Server',
                                data: [onek, fivek, tenk, fiftyk, hundredk],
                                borderWidth: 2,
                                pointBackgroundColor: [
                                    'rgba(0, 0, 0, 0.79)'
                                ],
                                backgroundColor: [
                                    'rgba(12, 92, 233, 0.79)'
                                ],
                                borderColor: [
                                    'rgba(12, 92, 233, 0.79)'
                                ]
                            },
                            {
                                label: 'MongoDB',
                                data: [oneknosql, fiveknosql, tenknosql, fiftyknosql, hundredknosql],
                                borderWidth: 2,
                                pointBackgroundColor: [
                                    'rgba(0, 0, 0, 0.79)'
                                ],
                                backgroundColor: [
                                    'rgba(15, 223, 104, 0.79)'
                                ],
                                borderColor: [
                                    'rgba(0, 223, 104, 0.79)'
                                ]
                            }
                        ],
                    },
                    options: {
                        plugins:
                        {
                            title: {
                                display: true,
                                text: ' Update MSSQLServer vs MongoDb',
                                font:
                                {
                                    size: 30,
                                }
                            }
                        },
                        scales: {
                            y: {
                                beginAtZero: true
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
    });
}

$(document).ready(function () {
    $('#dataAmount').val(1000);
    NoSQLUpdateList();
    $('#dataAmount').val(null);

});


