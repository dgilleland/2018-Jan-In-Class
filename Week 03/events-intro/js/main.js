// 1. select the target element
var featureImage = document.querySelector('img.feature');
var featureLink = document.querySelector('a.feature.link');

// 2. create the event listener function
function handleFeatureClick() {
    console.log('img.feature was clicked...');
    // Grab the HTMLElement with a .feature and a .description class
    var desc = document.querySelector('.feature.description');
    // All HTMLElement objects have .classList property that is a collection of class names
    desc.classList.remove('hidden');
}

function handleFeatureLinkClick(evt) {
    console.log('a.feature.link was clicked...');
    // set the image src to the anchor's href value
    // featureImage.src = featureLink.href;

	// set img.feature src preferred
    featureImage.src = evt.target.href;	
    
    // make the image visible
    featureImage.classList.remove('hidden');

    // do not load the image in the page
    evt.preventDefault();
}

// 3. add event listener
featureImage.addEventListener('click', handleFeatureClick);
featureLink.addEventListener('click', handleFeatureLinkClick);
