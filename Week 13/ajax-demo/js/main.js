var xhr = new XMLHttpRequest();
var button = document.querySelector('.button');
var output = document.querySelector('.output');

button.addEventListener('click', function (evt) {
	// use the href for the request URL
	xhr.open('GET', evt.target.href, true);
	xhr.send(null);
	// don't reload the page
	evt.preventDefault();
});

xhr.addEventListener('load', function (evt) {
	if (xhr.status === 200) { // success
		output.innerHTML = xhr.responseText;
	} else { // failure
		console.log('... request failed.');
		output.innerHTML = '<div>Request Failed.</div>';
	}
});