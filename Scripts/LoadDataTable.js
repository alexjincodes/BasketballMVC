var Popup, dataTable;

$(document).ready(function () {
    dataTable = $("#bballTable").DataTable({        //Calling dataTable plug-in
        "ajax": {
            "url": "/Basketball/GetData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "BallId" },
            { "data": "PlayerName" },
            { "data": "Exercise" },
            { "data": "ExerciseDuration" },
            {
                "data": "ExerciseDate",
                render: function(d) {
                    return moment(d).format("DD/MM/YYYY")
                }
            },
        ],
    }); 
});






