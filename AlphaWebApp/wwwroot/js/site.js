// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//ALI

$(document).ready(function () {
    $('#editor-choice').owlCarousel({
        
        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 3000,

        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 3
            }
        }
    })
});

$(document).ready(function () {
    $('#sports').owlCarousel({
        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 8000,

        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 3
            }
        }
    })
});

$(document).ready(function () {
    $('#most-popular').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 3000,

        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 3
            }
        }
    })
});

//$("#home-slider").owlCarousel({
//    pagination: true,
//    autoPlay: true,
//    singleItem: true,
//    stopOnHover: true,
//});

//$("#latest-news").owlCarousel({
//    items: 4,
//    pagination: true,
//    autoPlay: true,
//    stopOnHover: true,
//});

//$("#main-slider").owlCarousel({
//    items: 3,
//    pagination: false,
//    navigation: false,
//    autoPlay: true,
//    stopOnHover: true
//});

