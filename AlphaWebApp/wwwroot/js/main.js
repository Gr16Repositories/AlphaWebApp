jQuery(function ($) {

    'use strict';
	
    /*==============================================================
    # sticky-nav
    # Date Time
	# Search Slide
    ==============================================================*/


	/*==============================================================*/
	// # sticky-nav
	/*==============================================================*/
	(function () {
		var windowWidth = $(window).width();
		if (windowWidth > 1000) {
			$(window).scroll(function () {
				var sT = $(this).scrollTop();
				if (sT >= 120) {
					$('.homepage .navbar, .homepage-two.fixed-nav .navbar').addClass('sticky-nav')
				} else {
					$('.homepage .navbar, .homepage-two.fixed-nav .navbar').removeClass('sticky-nav')
				};
			});
		} else {
			$('.homepage .navbar, .homepage-two.fixed-nav .navbar').removeClass('sticky-nav')
		};
		if (windowWidth > 1000) {
			$(window).scroll(function () {
				var sT = $(this).scrollTop();
				if (sT >= 120) {
					$('.homepage #menubar, .homepage-two.fixed-nav #navigation').removeClass('container')
					$('.homepage #menubar, .homepage-two.fixed-nav #navigation').addClass('container-fluid')
				} else {
					$('.homepage #menubar, .homepage-two.fixed-nav #navigation').removeClass('container-fluid')
					$('.homepage #menubar').addClass('container')
				}
			});
		} else {
			$('.homepage #menubar, .homepage-two.fixed-nav #navigation').removeClass('container-fluid')
		};

	}());


		
	/*==============================================================*/
    // # Date Time
    /*==============================================================*/

    (function() {

		var datetime = null,
        date = null;
		var update = function() {
			date = moment(new Date())
			datetime.html(date.format('dddd, MMMM D,  YYYY'));
		};
		datetime = $('#date-time')
		update();
		setInterval(update, 1000);

	}());

	/*==============================================================*/
	// sticky
	/*==============================================================*/
	(function () {
		$("#sticky").stick_in_parent();
	}());

	/*==============================================================*/
	// Search Slide
	/*==============================================================*/
	
	$('.search-icon').on('click', function() {
		$('.searchNlogin').toggleClass("expanded");
	});
	
	

	

	
});