const dropdownButton = document.querySelector(".catalog__list-content");
const catalogLine = document.querySelector(".catalog__line");

dropdownButton.addEventListener('click', ()=>{
    const dropdownMenu = document.querySelector(".dropdown__list");
    dropdownMenu.classList.toggle("dropdown__list--active");
    catalogLine.classList.toggle("catalog__line--active");
});

