var friendDiv = document.querySelector('.friend');
var jsonDiv = document.querySelector('.json');

var friend = {
	firstName : 'Jane',
	lastName : 'Doe',
	fullName : function () {
		return this.firstName + ' ' + this.lastName;
	},
	email : 'jdoe@example.com'
};  // object literal

var friends = []; // array

// display the friend full name and email
friendDiv.innerHTML = friend.fullName() + ' [' + friend.email + ']';
// JSON object can be used to convert a JS object/array to a JSON string
jsonDiv.innerHTML = JSON.stringify(friend);