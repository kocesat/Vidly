$(document).ready(function () {

    var vm = {
        movieIds: [] // empty list for movieIds
    };

    // Twitter typeahead plugin used here
    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        hint: true,
        minLength: 1,
        highlight: true
    }, {
        name: 'customers',
        display: 'name',
        source: customers,
        limit: 50
    }).on("typeahead:select", function (e, customer) {
        vm.customerId = customer.id;
    });

    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#movie').typeahead({
        hint: true,
        minLength: 1,
        highlight: true
    }, {
        name: 'movies',
        display: 'name',
        limit: 50,
        source: movies
    }).on("typeahead:select", function (e, movie) {
        $("#movies").append("<li class='list-group-item'>" + movie.name + "  <button type='button' data-movie-id=" + movie.id + " class='js-delete-movie btn btn-danger btn-sm' aria-label='Close'> <span>&times;</span></button></li>");

        $("#movie").typeahead("val", "");

        vm.movieIds.push(movie.id);
    });

    $("#movies").on("click", ".js-delete-movie", function () {
        var button = $(this);

        var movieId = button.attr("data-movie-id");
        vm.movieIds = vm.movieIds.filter(function (value) {
            return value != movieId;
        });

        button.parents("li").remove();
        console.log(button.parents("li").children().value());
    });

    //custom jquery validation method
    // Selection of valid customer
    $.validator.addMethod("validCustomer", function () {
        return vm.customerId && vm.customerId != 0;
    }, "Please select a valid customer");

    // custom jquery validator: at least one movie selected

    $.validator.addMethod("atLeastOneMovieSelected", function () {
        return vm.movieIds.length > 0;
    }, "Please select at least one movie");

    var validator = $("#newrental").validate({
        submitHandler: function () {

            $.ajax({
                url: "/api/newrentals",
                method: "post",
                data: vm
            })
            .done(function () {
                toastr.success("Rental added succesfully");

                //Clear the form
                $("#customer").typeahead("val", "");
                $("#movie").typeahead("val", "");
                $(".list-group").html("<ul id='movies' class='list-group'></ul>");
                vm = { movieIds: [] };
                validator.resetForm();
            })
            .fail(function () {
                toastr.error("Something unexpected happened");
            });

            return false;
        }
    });
});