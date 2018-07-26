//********  Search function using Jquery  ***********
$('#Search').on('keyup', function () {
    dataTable
    .column(2)
    .search(this.value)
    .draw();
});
