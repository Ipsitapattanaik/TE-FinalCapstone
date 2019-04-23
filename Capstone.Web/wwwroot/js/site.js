// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#toggle").click(function () {
    $(this).toggleClass("on");
    $("#menu").slideToggle();
});

function myFunction() {
    // Declare variables
    var input, filter, i, txtValue;
    input = document.getElementById('Input');
    filter = input.value.toUpperCase();
    allfrans = document.getElementsByClassName("SearchTiles");
    console.log(filter);
    
    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < allfrans.length; i++) {
        txtValue = allfrans[i].id;
        console.log(txtValue);
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            allfrans[i].setAttribute('style', '');;
        }else
        {
            allfrans[i].setAttribute('style', 'display:none');;
        }
    }
}

$('.arrow').click(function (e) {
    e.preventDefault();

    let arrow = $(this);

    if (!arrow.hasClass('animate')) {
        arrow.addClass('animate');
        setTimeout(() => {
            arrow.removeClass('animate');
        }, 1600);
    }
});

function Pop() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}