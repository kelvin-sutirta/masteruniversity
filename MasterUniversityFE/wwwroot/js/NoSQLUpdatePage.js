﻿
$("#buttonPerfUpdateNoSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfUpdateNoSQL();
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

$(document).ready(function () {
    $('#dataAmount').val(1000);
    NoSQLUpdateList();
    $('#dataAmount').val(null);
});


