var output = document.querySelector('.output');
var list = '<ul>';
var count; // count the number of list items

// add list items
// for (count = 0; count < 10; count = count + 1) {
// 	list = list + '<li>' + (count + 1) + '</li>';
// }

// count = 10;
// while (count > 0) {
// 	list = list + '<li>' + count + '</li>';
// 	count = count - 1;
// }
count = 0;
do {
	list = list + '<li>' + (count + 1) + '</li>';
	count = count + 1;
} while (count < 10);
/*

*/
list = list + '</ul>';

// display the list
output.innerHTML = list;