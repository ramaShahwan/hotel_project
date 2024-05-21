$(document).ready(function () {
    // ...

    $("#submitButton").click(function (event) {
        event.preventDefault(); // Prevent the form from submitting by default

        // Validate required fields
        var valid = true;

        if ($("#Floor").val().trim() === "") {
            $("#FloorV").text("Floor is required");
            valid = false;
        } else {
            $("#FloorV").text("");
        }

        if ($("#RoomNum").val().trim() === "") {
            $("#RoomNumV").text("Room number is required");
            valid = false;
        } else {
            $("#RoomNumV").text("");
        }

        if ($("#roomPhone").val().trim() === "") {
            $("#roomPhoneV").text("Room phone is required");
            valid = false;
        } else {
            $("#roomPhoneV").text("");
        }

        // Add similar validation for other fields

        // If all fields are valid, submit the form
        if (valid) {
            $("#uploadForm").submit();
        }
    });

    // ...
});
