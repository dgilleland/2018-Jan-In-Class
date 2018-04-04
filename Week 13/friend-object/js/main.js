var friendDiv = document.querySelector('.friend');

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