
$("#buttonPerfDeleteSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfDeleteSQL();
    }

});
function buttonPerfDeleteSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/SQL/SQLDeletePerformance',
        data: { TestCases: TestCases },
        dataType: "json",
        async: false,
    })
        .done(function (data) {
            console.log(data);
            JSON.stringify(data);
            console.log(data.averageTime);
            console.log(data.dataProcessed);
            console.log(data.hours);
            console.log(data.miliSeconds);
            console.log(data.minutes);
            console.log(data.seconds);

            $('#perfresultsdata').html('Data Processed : ' + data.dataProcessed);
            $('#perfresultshour').html('Hours : ' + data.hours);
            $('#perfresultsminute').html('Minutes : ' + data.minutes);
            $('#perfresultssec').html('Seconds : ' + data.seconds);
            $('#perfresultsmilisec').html('MiliSeconds : ' + data.miliSeconds);
            $('#perfresults').html('Average Time : ' + data.averageTime);
        })
    SQLDeleteList();
}
function SQLDeleteList() {
    var TestCases = $('#dataAmount').val()
    $("#tblSQLDeleteList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/SQL/ListSQLDelete',
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

/*function SQLInsertList() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $("#tblSQLInsertList").DataTable({
        "destroy": true,
        "processing": true,
        "searching": false,
        "paging":false,
        "ajax": {
            "url": '/SQL/ListSQLInsert',
            "type": "GET",
            "data": { TestCases: TestCases },
            "datatype": "json",
            "datasrc":"",
        },
        "columns": [
            { data: 'id' },
            { data: 'hours' },
            { data: 'minutes' },
            { data: 'second' },
            { data: 'miliseconds' },
            { data: 'dataProcessed' },
            { data: 'averageTime' },
        ],
        "paging": false,
        "pageLength": 5,
    });
}
*/

$(document).ready(function () {
    $('#dataAmount').val(1000);
     SQLDeleteList();
    $('#dataAmount').val(null);
});





