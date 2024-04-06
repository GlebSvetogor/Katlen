const catalogList = document.querySelector(".catalog__list");

catalogList.addEventListener('click', (event) => {
    const target = event.target;

    if (target.closest('.catalog__list-content')) {
        const catalogListItem = target.closest('.catalog__list-item');
        const dropdownList = catalogListItem.querySelector('.dropdown__list');
        const catalogFilterArrow = catalogListItem.querySelector('.catalog__filter-arrow');

        dropdownList.classList.toggle("dropdown__list--active");
        catalogFilterArrow.classList.toggle("catalog__filter-arrow--active");
    }
});
