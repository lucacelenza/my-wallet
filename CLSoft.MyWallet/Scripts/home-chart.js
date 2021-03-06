﻿var ctx = document.getElementById("balance-chart");

var chart = new Chart(ctx, {
    type: "line",
    data: {
        labels: timeBalance.labels,
        datasets: [{
            label: "# of Votes",
            data: timeBalance.data,
            backgroundColor: [
                "rgba(100, 99, 132, 0.2)"
            ],
            borderColor: [
                "rgba(100,99,132,1)"
            ],
            borderWidth: 1,
            lineTension: 0
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    callback: function (value, index, values) {
                        return value.toLocaleString(timeBalance.culture, { style: "currency", currency: timeBalance.currencyCode });
                    }
                }
            }]
        }
    }
});