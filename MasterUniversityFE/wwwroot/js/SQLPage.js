
$("#buttonPerfSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfSQL();
}
   
});
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
}