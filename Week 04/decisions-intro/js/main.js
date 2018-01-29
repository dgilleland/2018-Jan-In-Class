// An anonymous function is a function that does not have a name
// Anonymous functions are often used when you want to create a "one-of"
// function that is being passed into another method/function.
document.querySelector('img.feature')
		.addEventListener('click', function () {
			var desc = document.querySelector('p.feature.description');
		
			if (desc.classList.contains('hidden')) {
				desc.classList.remove('hidden');
			} else {
				desc.classList.add('hidden');
			}
		});

