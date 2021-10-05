// active class of menu items onscroll

var url = window.location.pathname

if (url != "/") {


	$('.offcanvas-body a').each(function () {
		var attr = this.getAttribute('href')

		if (attr == url) {
			console.log(url)
			$(this).children().addClass('nav-item-active-mobile')
		}

	})

	// now grab every link from the navigation
	$('.nav-item a').each(function () {
		console.log(this.getAttribute('href'))
		var attr = this.getAttribute('href')

		if (attr == url) {

			$('.nav-item a').removeClass('nav-item-active')
			//$(this).addClass('active');
			$(this).parent().addClass('nav-item-active')


		}



		// and test its normalized href against the url pathname regexp
		//if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
		//    $(this).addClass('nav-item-active');
		//}
	});
}
else {
	//window.addEventListener('scroll', () => {
	//	let scrollDistance = window.scrollY;





	//	if (window.innerWidth > 768) {
	//		document.querySelectorAll('section').forEach((el, i) => {
	//			if (el.offsetTop - document.querySelector('.nav').clientHeight <= scrollDistance) {
	//				document.querySelectorAll('.nav a').forEach((el) => {
	//					if (el.classList.contains('active')) {
	//						el.classList.remove('active');
	//					}
	//				});

	//				document.querySelectorAll('.nav li')[i].querySelector('a').classList.add('active');
	//			}
	//		});
	//	}
	//});
}


