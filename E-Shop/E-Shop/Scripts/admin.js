'use strict';

$('.upload__image').change(function () {
    const oInput = this;
    const validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png", ".jfif"];
    for (let i = 0; i < oInput.files.length; i++) {
        if (oInput.type === "file") {
            const sFileName = oInput.files[i].name;
            if (sFileName.length > 0) {
                let blnValid = false;
                for (let j = 0; j < validFileExtensions.length; j++) {
                    const sCurExtension = validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() ==
                        sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert(sFileName +
                        " имеет недоступный формат. Доступные форматы: " +
                        validFileExtensions.join(", "));
                    oInput.value = "";
                    return false;
                }
            }
        }
    }
    return true;
});

$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $(this).toggleClass('active');
    });
});

$('#supplyProductAdd').click(function () {
    var res = "";
    var count = $('.supply__product').length;
    var first = $('.supply__product')[0].innerHTML;
    first = first.replace(/\[0\]/g, '[' + count + ']');
    res += '<div class="form-group row mx-0 supply__product">' +
        first +
        '</div>';
    $('#supplyProducts').append(res);
});

$('.value__input').click(function () {
    $("[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("data-autocomplete-source") });
    });
});