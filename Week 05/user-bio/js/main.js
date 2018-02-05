// My page has only one form, so I will select with
// document.querySelector()
var myForm = document.querySelector('form');

// A handler for the reset event
myForm.addEventListener('reset', function (evt) {
    if(confirm('Are you sure you want to reset the form data?')) {
        // let the default action through, which is to reset
    } else {
        evt.preventDefault();
    }
});

// A handler for the submit event
myForm.addEventListener('submit', function (evt) {
    // Validation for the form elements
    var controls = evt.target.elements;
    var errors = '';
    // 1. First and Last name cannot be empty
    if(controls.firstName.value.trim() == "") {
        errors += '<li>First name cannot be empty</li>';
    }
    if(controls.lastName.value.trim() == "") {
        errors += '<li>Last name cannot be empty</li>';
    }

    // 2. Email should have an @ symbol
    if(! controls.emailAddress.value.includes('@')) {
        errors += '<li>Email address is invalid</li>';
    }

    // 3. Web address should start with http
    if(! controls.personalWebsite.value.startsWith('http')) {
        errors += '<li>Website url should start with <code>http</code> and be a full url</li>';
    }

    // Decide whether or not to display the form
    if(errors) {
        evt.preventDefault();
        document.getElementById('errorList').innerHTML = errors;
    } else {
        document.getElementById('errorList').innerHTML = "";
    }
});