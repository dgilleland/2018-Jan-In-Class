// When the 'Add Tag' submit button is clicked, the p.feature.tags element should be 
// updated with the tag that was entered by the user.  Do not overwrite any existing tags,
// simply add each additional tag onto the already existing list.  A tag cannot be empty 
// (i.e. cannot be whitespace). If the user tries to add an empty tag, remove the hidden 
// class from the p.feature.error element.  If the form is submitted correctly, then ensure
// that the p.feature.error element is hidden.

document.querySelector('.feature.frm ')
.addEventListener('submit', function (evt) {
    var frm = evt.target;
    var tag = frm.elements.tags;
    var error = document.querySelector('p.feature.error');

    // Ensure that there is a value in the tag input field before adding the tag to the paragraph
    if (tag.value.trim() != '') {
        // insert a '# ' before the tag for aesthetics
        document.querySelector('p.feature.tags ').innerHTML += '#' + tag.value.trim() + ' ';
        tag.value = '';
        error.classList.add('hidden');
    } else {
        // No data was entered
        error.innerHTML = "Blank input will not be processed.";
        error.classList.remove('hidden');
    }
    evt.preventDefault(); 
});

