// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


(function () {

    document.getElementById("p100").style.backgroundColor = "red";
    document.getElementById("p2").style.backgroundColor = "blue";


}()); 



// Render the PayPal button into #paypal-button-container
paypal.Buttons({
    var price = "90";
    // Set up the transaction
    createOrder: function (data, actions) {
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: price
                }
            }]
        });
    },

    // Finalize the transaction
    onApprove: function (data, actions) {
        return actions.order.capture().then(function (orderData) {
            // Successful capture! For demo purposes:
            console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
            var transaction = orderData.purchase_units[0].payments.captures[0];
            alert('Transaction ' + transaction.status + ': ' + transaction.id + '\n\nSee console for all available details');

            // Replace the above to show a success message within this page, e.g.
            // const element = document.getElementById('paypal-button-container');
            // element.innerHTML = '';
            // element.innerHTML = '<h3>Thank you for your payment!</h3>';
            // Or go to another URL:  actions.redirect('thank_you.html');
        });
    }


}).render('#paypal-button-container');
