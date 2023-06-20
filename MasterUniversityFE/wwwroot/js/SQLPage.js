
$("#buttonPerfSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {    
      buttonPerfSQL();      
}
   
});

/*function buttonLoading(elem) {
    $(elem).attr("data-original-text", $(elem).html());
    $(elem).prop("disabled", true);
    $(elem).html('<i class="spinner-border spinner-border-sm"></i> Loading...');
    
}
function buttonAfterLoading(elem) {
    $(elem).prop("disabled", false);
    $(elem).html($(elem).attr("data-original-text"));
}
*/
function buttonPerfSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
               $.ajax({
                    method: "POST",
                   url: '/SQL/SQLPerformance',
                   data: {TestCases: TestCases},
                   dataType: "json",
                   async : false,
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

    SQLInsertList();
}
function SQLInsertList() {
    var TestCases = $('#dataAmount').val()
    $("#tblSQLInsertList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/SQL/ListSQLInsert',
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




$("#buttonPerfUpdateSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfUpdateSQL();
    }

});
function buttonPerfUpdateSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/SQL/SQLUpdatePerformance',
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

    SQLUpdateList();
}
function SQLUpdateList() {
    var TestCases = $('#dataAmount').val()
    $("#tblSQLUpdateList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/SQL/ListSQLUpdate',
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



$("#buttonPerfGetSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfGetSQL();
    }

});
function buttonPerfGetSQL() {
    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/SQL/SQLGetPerformance',
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
function SQLGetList() {
    var TestCases = $('#dataAmount').val()
    $("#tblSQLGetList").DataTable({
        "destroy": true,
        "processing": true,
        "pageLength": 5,
        "ajax": {
            "url": '/SQL/ListSQLGet',
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
    SQLInsertList();
    $('#dataAmount').val(null);
});




