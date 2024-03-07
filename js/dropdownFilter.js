const dropdownButton = document.querySelector(".catalog__list-content");

dropdownButton.addEventListener('click', ()=>{
    const dropdownMenu = document.querySelector(".dropdown__list");
    console.log(dropdownMenu);
    dropdownMenu.classList.toggle("dropdown__list--active");
});

