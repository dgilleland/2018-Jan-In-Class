// 1) Declare my event handlers
function showImage(evt) {
    // a) Get a reference to the <img class="feature"> element
    var imgElement = document.querySelector('img.feature');
    // b) Remove the 'hidden' class from the element
    imgElement.classList.remove('hidden');
    // c) Get the href from the <a class="feature link" href="..."> element
    //    (storing in a local, temporary variable)
    var imgSrc = linkElement.href;
    // d) Set the .src attribute's value for the <img>
    imgElement.src = imgSrc;
    // e) Set the .alt attribute's value for the <img>
    imgElement.alt = linkElement.title;
    // f) Get a reference to the <p class="feature title"></p> element
    var captionParagraph = document.querySelector('p.feature.title');
    // g) Put some text in that paragraph
    captionParagraph.innerHTML = linkElement.title;

    // h) Stop the default actions of this event (the 'click' on an <a> tag)
    evt.preventDefault();
}

// 2) Find the elements that respond to events
var linkElement = document.querySelector('a.feature.link');

// 3) "Wire up" the elements to the event handlers
linkElement.addEventListener('click', showImage);
