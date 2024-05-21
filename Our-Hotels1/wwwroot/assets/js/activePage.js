
    $(document).ready(function () {
        // Get the current URL
        var currentUrl = window.location.pathname;

        // Find the corresponding <a> element and add the "active" class
        $('#sidebar-menu a').each(function () {
            if ($(this).attr('href') === currentUrl) {
            $(this).addClass('active');
                // Add the "active" class to the parent <li> element
            $(this).closest('li').addClass('active');
            }
        });

            // Handle click event on the menu items
            $('#sidebar-menu a').click(function () {
                // Remove "active" class from all menu items
                $('#sidebar-menu a').removeClass('active');
            $('#sidebar-menu li').removeClass('active');

            // Add "active" class to the clicked menu item and its parent <li> element
                $(this).addClass('active');
                $(this).closest('li').addClass('active');
        });
    });

