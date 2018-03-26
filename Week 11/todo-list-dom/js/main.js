/*
  Add the required JavaScript to handle form submit and add a new todo item to 
  the page (in the div.todo-list element).  You will need to use a counter to 
  uniquely identify each todo item and use only DOM API functions to interact
  with the document (i.e. create each todo item), DO NOT use innerHTML for this
  exercise.
*/

// required vars
var todos = document.querySelector('.todo-list');
var todoCount = 0;

// todo form submit handler, adds a new todo item to the 'list'
document.querySelector('.todo-frm').addEventListener('submit', function (evt) {
	
	var div,
		checkbox,
		label,
		labelText,
		todoText;

	todoText = evt.target.elements['todo-item'].value;
	//        \ <form>  / \ <input name=".."  / \text/

	// adding a todo regardless, so might as well increment now...
	todoCount += 1;
	
	if (todoText === '') {
		todoText = 'Todo ' + (todoCount); // default text for our TODO item
	}

	// create required elements - they are "free-floating" at this point
	div = document.createElement('div'); // This creates a <div> node, with the ability to have attributes
	checkbox = document.createElement('input'); // create an <input> node
	label = document.createElement('label'); // a <label> node
	labelText = document.createTextNode(todoText); // a node that only has "raw" text - "Todo 1"

	// set appropriate attributes
	checkbox.setAttribute('type', 'checkbox'); // <input type="checkbox" />
	checkbox.setAttribute('id', 'todo-' + todoCount); // <input type="checkbox" id="todo-1" />
	label.setAttribute('for', 'todo-' + todoCount); // <label for="todo-1" />
	label.setAttribute('contenteditable', ''); // <label for="todo-1" contenteditable />

	/*	.setAttribute(attributeName, attributeValue) - adds/changes the attribute value
		.getAttribute(attributeName) - returns the attributeValue
		.hasAttribute(attributeName) - returns true if the attribute exists
		.removeAttribute(attributeName) - deletes the attribute from the element
	*/

	// build document fragment - "assemble" the various elements
	label.appendChild(labelText); // <label for="todo-1" contenteditable>Todo 1</label>
	div.appendChild(checkbox);    // <div>
	                              //    <input type="checkbox" id="todo-1" />
	                              // </div>
	div.appendChild(label);       // <div>
	                              // 	<input type="checkbox" id="todo-1" />
								  // 	<label for="todo-1" contenteditable>Todo 1</label>
								  // </div>

	// Add some up/down arrows to our <div>
	var dnArrow = document.createElement('span');
	var dn = '\u21e9'; // Unicode value of down arrow
	var dnText = document.createTextNode(dn);
	dnArrow.setAttribute('class', 'arrow dn');
	dnArrow.appendChild(dnText);
	div.appendChild(dnArrow);

	var upArrow = document.createElement('span');
	var up = '\u21e7'; // Unicode value of up arrow
	var upText = document.createTextNode(up);
	upArrow.setAttribute('class', 'arrow up');
	upArrow.appendChild(upText);
	div.appendChild(upArrow);

	// add the document fragment to the document for rendering
	todos.appendChild(div); // I place my "free-floating" <div> into the DOM of my page

	// clear the form
	evt.target.reset();

	evt.preventDefault(); // prevent the default behaviour of the "submit" event
});


document.querySelector('.todo-list').addEventListener('click', function (evt) {
	// check for click on an arrow
	if (evt.target.classList.contains('arrow')) {
		var targetTodo = evt.target.parentNode; // the <div> containing my <span class="arrow ..">
		var todoList = targetTodo.parentNode;   // the <div> containing my <div><input /><label /><span /></div>
		var siblingTodo;
		// identify the type of arrow (i.e. down or up)
		if (evt.target.classList.contains('dn')) {
			siblingTodo = targetTodo.nextElementSibling;
			// insert the sibling before the target
			todoList.insertBefore(siblingTodo, targetTodo); // footnote #1
		} else if (evt.target.classList.contains('up')) {
			siblingTodo = targetTodo.previousElementSibling;
			// insert the target before the sibling
			todoList.insertBefore(targetTodo, siblingTodo); // footnote #1
		}
	}
});

/** Footnotes
 * 1) There is no insertAfter method. It can be emulated by combining the insertBefore method with nextSibling.
 */
