// Array of all the month names
var monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December" ];

// Setting up the calendar
var today = new Date();
var currentMonth = today.getMonth();
var currentYear = today.getFullYear();
var firstDay = 1;

// Displaying the current
var calendarTitle = monthNames[currentMonth] + ' ' + currentYear;
document.querySelector('.calendar header h1').innerHTML = calendarTitle;

// Set up a calendar for the Sunday of the first week of the month.
// 	a) first day of month
var calendar = new Date(currentYear, currentMonth, firstDay);
//  b) new date offsetting by the day of the week
var dayOfWeek = calendar.getDay();
calendar = new Date(currentYear, currentMonth, firstDay - dayOfWeek)

var days = document.querySelectorAll('.day-grid li');

var index;

for (index = 0; index < days.length; index++)
{
	days[index].innerHTML = calendar.getDate();
	if(calendar.getMonth() < currentMonth) {
		days[index].classList.add('month-prev');
	} else if(calendar.getMonth() > currentMonth) {
		days[index].classList.add('month-next');
	}

	calendar = getTomorrow(calendar);
}

function getTomorrow(currentDate) {
	return new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
}

