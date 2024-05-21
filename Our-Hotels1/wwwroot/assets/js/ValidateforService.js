$(document).ready(function () {
    // Validate the price input
    $('#price').on('input', function () {
        var value = $(this).val();
        var isValid = /^\d+(\.\d{1,2})?$/.test(value); // Regular expression for numbers with up to two decimal places
        if (value.trim() === '') {
            $('#VPrice').text('Price is required');
        } else if (!isValid) {
            $('#VPrice').text('Invalid price format');
        } else {
            $('#VPrice').text('');
        }
    });

    // Validate the name input
    $('#Name').on('input', function () {
        var value = $(this).val();
        if (value.trim() === '') {
            $('#VName').text('Name is required');
        } else if (!/^[a-zA-Z\s]+$/.test(value)) { // Regular expression for text (letters and spaces only)
            $('#VName').text('Invalid name format');
        } else {
            $('#VName').text('');
        }
    });
    // Validate the description input
    $('#Description').on('input', function () {
        var value = $(this).val();
        if (value.length > 200) {
            $('#VDescription').text('Description should not exceed 200 characters');
        } else {
            $('#VDescription').text('');
        }
    });

    // Submit form validation
    $('#servicesForm').submit(function () {
        var price = $('#price').val();
        var name = $('#Name').val();
        var description = $('#Description').val();
        var isValid = true;

        // Validate price
        if (!/^\d+(\.\d{1,2})?$/.test(price)) {
            $('#VPrice').text('Invalid price format');
            isValid = false;
        } else {
            $('#VPrice').text('');
        }

        // Validate name
        if (!/^[a-zA-Z\s]+$/.test(name)) {
            $('#VName').text('Invalid name format');
            isValid = false;
        } else {
            $('#VName').text('');
        }

        // Validate description length
        if (description.length > 200) {
            
            $('#VDescription').text('Description should not exceed 200 characters');
            isValid = false;
        } else {
            $('#VDescription').text('');
        }

        return isValid;
    });
});
