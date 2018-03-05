// variable for the days of the week
var days = [
	'Sun',
	'Mon',
	'Tue',
	'Wed',
	'Thu',
	'Fri',
	'Sat'
];

// indexer counter for traversing the array
var idx;

// variable for the table, which includes a row for day names
var cal = '<table style="border:thin solid black;"><tr>';

	// add add day names
for (idx = 0; idx < days.length; idx += 1) {
	cal += '<th>' + days[idx] + '</th>';
}
// Adding rows for March, 2018
// TODO: for the current date, make the corresponding table cell
//       have a style of "border: solid 1px forestgreen;"
var dayOfMonth = -3; // March 1 starts on a Thursday
var lastDay = 31;
for (var week = 1; week <= 6; week++) {
	cal += '<tr>';
	// Add cells for the week
	for(var day = 0; day < 7; day++) {
		cal += '<td>';
		// display the day number
		if(dayOfMonth > 0 && dayOfMonth <= lastDay) {
			cal += dayOfMonth;
		}
		cal += '</td>';
		dayOfMonth++;
	}
	cal += '</tr>'
}

// close the table and display
cal += '</tr></table>';

document.querySelector('.display').innerHTML = cal;