
$("#buttonPerfGetNoSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfGetNoSQL();
    }

});
function buttonPerfGetNoSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/NoSQL/NoSQLGetPerformance',
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
    SQLGetList();
}
function NoSQLGetList() {
    var TestCases = $('#dataAmount').val()
    $("#tblNoSQLGetList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/NoSQL/ListNoSQLGet',
            "data": { TestCases: TestCases },
        },
        "columns": [
            { data: 'dataProcessed' },
            { data: 'hours' },
            { data: 'minutes' },
            { data: 'seconds' },
            { data: 'miliSeconds' },
            { data: 'averageTime' },
        ],
        "paging": true,
        "pagingType": "simple_numbers",
        "searching": false,
        "info": false
    });
}

$(document).ready(function () {
    $('#dataAmount').val(1000);
    NoSQLGetList();
    $('#dataAmount').val(null);
});




