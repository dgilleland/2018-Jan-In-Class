var loginForm = document.querySelector('.frm-login');

loginForm.addEventListener('submit', function (evt) {
	var form = evt.target;
	// short access to the field elements
	var user = form.elements.username;
	var pass = form.elements.userpass;
	// flag for invalid form
	var valid = true;
	// error display variables
	var errorList = document.querySelector('ul.error');
	var errors = '';

	// 1. user cannot be empty
	if (user.value.trim() == '') {
		errors += '<li>username cannot be empty</li>';
		// the previous line is equivalent to the following:
		// errors = errors + '<li>username cannot be empty</li>';
		valid = false;
	}

	// 2. password cannot be empty
	if (pass.value.trim() == '') {
		errors += '<li>password cannot be empty</li>';
		valid = false;
	}

	// if NOT validForm, then...
	if (!valid) {
		// do not submit the form
		evt.preventDefault();
		// display the errors
		errorList.innerHTML = errors;
	}
});