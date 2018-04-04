var friendDiv = document.querySelector('.friend');
var xhr = new XMLHttpRequest();

xhr.addEventListener('load', function (evt) {
	var friend;

	if (xhr.status === 200) {
		// parse the JSON and display
		friend = JSON.parse(xhr.responseText);
		// display the friend first name and email
		friendDiv.innerHTML = friend.firstName + ' [' + friend.email + ']';
	}
});

xhr.open('GET', 'friend.json', true);

xhr.send();