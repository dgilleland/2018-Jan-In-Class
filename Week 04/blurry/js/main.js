// Set focus to the first form input
document.querySelector('input').focus();

document.getElementById('personalInfo').addEventListener('change', updateOutput);
document.getElementById('bioInfo').addEventListener('change', updateOutput);

function updateOutput(evt) {
    var out = document.getElementById('output');
    var message;
    message = evt.target.id;
    out.innerHTML += message + '<hr />';
}