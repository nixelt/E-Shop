"use strict";

$('#reloadPage').click(function () {
    location.reload(true);
});

$('.product-img').click(function () {
    const photo = $('img', this)[0];
    $("#bigImage").attr('src', photo.src);
});

$(".checkout").click(function () {
    event.preventDefault();
    var result = "";
    var i = 0;
    ShoppingCart.getItems().forEach(function (item) {
        result += '<input name="cartItems[' +
            i +
            '].ProductId" value="' +
            item.id +
            '" hidden><input name="cartItems[' +
            i +
            '].QuantityInCart" value="' +
            item.quantity +
            '" hidden>';
        i++;
    });
    if (ShoppingCart.getItems().length === 0) {
        return;
    }

    $('#checkoutForm').append(result);
    $('#checkoutForm').submit();
});

$("#ajaxSelectSubmit").change(function () {
    $(this.form).submit();
});

$('#AjaxChangeSubmit').change(function () {
    $(this.form).submit();
});

function displayValidationErrors(errors) {
    var $ul = $('div.validation-summary-valid.text-danger > ul');

    $ul.empty();
    errors.forEach(function (errorMessage) {
        $ul.append('<li>' + errorMessage + '</li>');
    });
}

$("#createOrder").submit(function () {
    event.preventDefault();
    var form = $(this);
    if (!form.valid()) {
        return;
    }
    var url = form.attr('action');
    $.post(url, form.serialize()).done(function (result) {
        if (!result.success) {
            displayValidationErrors(result.errors);
            return;
        }
        ShoppingCart.clear();
        window.location.href = result.returnUrl;
    }).fail(function () {
        alert("fail");
    });
});

$('#createOrder').validate({
    ignore: []
});

$(document).ready(function ($) {
    var stars = $('.rate');
    var rate = 10;
    stars.on('mouseover',
        function () {
            var index = $(this).attr('data-index');
            markStarsAsActive(index);
        });
    stars.on('mouseout',
        function () {
            markStarsAsActive(rate);
        });


    function markStarsAsActive(index) {
        unmarkActive();
        for (var i = 0; i < index; i++) {
            $(stars.get(i)).addClass('gold');
        }
    }

    function unmarkActive() {
        stars.removeClass('gold');
    }

    stars.on('click',
        function () {
            rate = $(this).attr('data-index');
            markStarsAsActive(rate);
            $("#reviewRating").val(rate);
        });
});

$('#reviews-tab').click(function () {
    var productId = $('#ProductId').val();
    $.ajax({
        url: "/Review/GetReviews",
        type: "GET",
        data: { productId: productId },
        success: function (result) {
            $('#productReviews').html(result);
        }
    });
});

$('#productFormFilter').click(function () {
    event.preventDefault();
    console.log($(this).serialize());
    var z = $.get("Catalog/GetProducts/" + $(this).serialize());
    $('#products').innerHTML(z);
});