//****** Popup form function, exits when submit is pressed *******

function PopupForm(url) {
    var formDiv = $('<div/>');
    $.get(url)
    .done(function (response) {
        formDiv.html(response);

        Popup = formDiv.dialog({
            autoOpen: true,
            resizeble: false,
            title: 'Fill Player Details',
            height: 500,
            width: 300,
            close: function () {
                Popup.dialog('destroy').remove();
            }
        });
    });
}

function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                console.log(data);
                if (data.success) {
                    Popup.dialog('close')
                    dataTable.ajax.reload();
                } else {
                    $("#error").text("Duplicate Entry! Please enter different exercise or date");  nb
                }
            }
        });
    }
    return false;
}