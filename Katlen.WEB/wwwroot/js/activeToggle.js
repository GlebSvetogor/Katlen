const butLinkWholesale = document.querySelector(".wholesale__but-link");
const wholesaleMore = document.querySelector(".wholesale__more");
const wholesaleIcon = document.querySelector(".wholesale__icon");

butLinkWholesale.addEventListener('click', () => {
    const moreInfo = getClassNameFromElement(wholesaleMore);
    const moreIcon = getClassNameFromElement(wholesaleIcon);
    toggleActiveFunction(moreInfo);
    toggleActiveFunction(moreIcon);
});

function toggleActiveFunction(elementClassName){
    const regex = /--active/;
    var el = document.querySelector(elementClassName);
    var className = getClassNameFromElement(el);
    if(!regex.test(className)){
        className += "--active";
    }
    el.classList.toggle(className.slice(1));
}
