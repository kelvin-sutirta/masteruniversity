
$("#buttonPerfNoSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfNoSQL();
    }
});
function buttonPerfNoSQL() {

    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/NoSQL/NoSQLPerformance',
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
}


$("#buttonPerfDeleteNoSQL").click(function () {
    if ($('#dataAmount').val() == null) {
        alert("Please choose valid data amount")
    }
    else {
        buttonPerfDeleteNoSQL();
    }
});
function buttonPerfDeleteNoSQL() {

    var TestCases = $('#dataAmount').val()
    console.log(TestCases);
    $.ajax({
        method: "POST",
        url: '/NoSQL/NoSQLDeletePerformance',
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
