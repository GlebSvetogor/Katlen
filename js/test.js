const butLinkWholesale = document.querySelector(".wholesale__but-link");
const wholesaleMore = document.querySelector(".wholesale__more");

butLinkWholesale.addEventListener('click', () => {
    const result = getClassNameFromElement(wholesaleMore);
    toggleActiveFunction(result);
});

function toggleActiveFunction(elementClassName){
    var el = document.querySelector(elementClassName);
    el.classList.toggle("--active");
}
