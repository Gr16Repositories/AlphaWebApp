// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//editor-choice
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

//sports
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

//sports
$(document).ready(function () {
    $('#most-popular').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 5000,

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


//Local News
$(document).ready(function () {
    $('#local-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 10000,

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

//Sweden News
$(document).ready(function () {
    $('#sweden-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 10000,

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

//World News
$(document).ready(function () {
    $('#world-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 10000,

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

//Economy News
$(document).ready(function () {
    $('#economy-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 10000,

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

//Health News
$(document).ready(function () {
    $('#health-news').owlCarousel({

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

//Sport News
$(document).ready(function () {
    $('#sport-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 10000,

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

//Technology News
$(document).ready(function () {
    $('#technology-news').owlCarousel({

        margin: 20,
        dots: true,
        nav: false,
        loop: true,
        autoplay: true,
        autoplayTimeout: 2000,

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

// Render the PayPal button into #paypal-button-container
//paypal.Buttons({
//    var price = "90";
//    // Set up the transaction
//    createOrder: function (data, actions) {
//        return actions.order.create({
//            purchase_units: [{
//                amount: {
//                    value: price
//                }
//            }]
//        });
//    },

//    // Finalize the transaction
//    onApprove: function (data, actions) {
//        return actions.order.capture().then(function (orderData) {
//            // Successful capture! For demo purposes:
//            console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
//            var transaction = orderData.purchase_units[0].payments.captures[0];
//            alert('Transaction ' + transaction.status + ': ' + transaction.id + '\n\nSee console for all available details');

//            // Replace the above to show a success message within this page, e.g.
//            // const element = document.getElementById('paypal-button-container');
//            // element.innerHTML = '';
//            // element.innerHTML = '<h3>Thank you for your payment!</h3>';
//            // Or go to another URL:  actions.redirect('thank_you.html');
//        });
//    }


//}).render('#paypal-button-container');
