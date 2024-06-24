const signupWindow = document.querySelector(".window--signup");
const signupWindowLoginBtn = document.querySelector(".window__login-btn");
const closeSignupBtn = document.querySelector(".window__close-btn--signup");

const loginBtn = document.querySelector(".header__heading-user");
const loginWindow = document.querySelector(".window--login");
const loginWindowSignupBtn = document.querySelector(".window__signup-btn");
const closeLoginBtn = document.querySelector(".window__close-btn--login");

const butLinkWholesale = document.querySelector(".wholesale__but-link");
const wholesaleMore = document.querySelector(".wholesale__more");
const wholesaleIcon = document.querySelector(".wholesale__icon");

function toggleVisibility(element) {
    element.classList.toggle('active');
}

document.addEventListener('DOMContentLoaded', () => {
    const searchForm = document.getElementById('search-form');
    const searchButton = searchForm.querySelector('button');
    const searchResult = document.getElementById('search-result');

    searchButton.addEventListener('click', function (event) {
        // Предотвращаем отправку формы
        event.preventDefault();
        // Переключаем класс 'hidden' для элемента search-result
        searchResult.classList.toggle('hidden');
    });
});
/*
butLinkWholesale.addEventListener('click', () => {
    toggleVisibility(wholesaleMore);
    toggleVisibility(wholesaleIcon);
})*/

loginBtn.addEventListener('click', () => {
    if (isAuthenticated) {
        window.location.href = redirectUrl;
    } else {
        toggleVisibility(loginWindow);
    }
});

/*loginBtn.addEventListener('click', () => {
    toggleVisibility(loginWindow);
});*/

closeLoginBtn.addEventListener('click', () => {
    toggleVisibility(loginWindow);
});

loginWindowSignupBtn.addEventListener('click', () => {
    toggleVisibility(loginWindow);
    toggleVisibility(signupWindow);
})

closeSignupBtn.addEventListener('click', () => {
    toggleVisibility(signupWindow);
})

signupWindowLoginBtn.addEventListener('click', () => {
    toggleVisibility(signupWindow);
    toggleVisibility(loginWindow);
})







/*const cardLiked = document.querySelector('.card__liked');

cardLiked.addEventListener('click', ()=>{
    cardLiked.classList.toggle("card__liked--active");
})*/

/*const commentBtn = document.getElementById('comment-btn');
const commentOutputBlock = document.getElementById('comment-block');
const commentCloseBtn = document.getElementById('comment-closeBtn');

commentBtn.addEventListener('click' ,()=>{
    commentOutputBlock.classList.remove("hidden");
})

commentCloseBtn.addEventListener('click' ,()=>{
    commentOutputBlock.classList.add("hidden");
})
*/
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

$('#getUp').animate(function () {
    window.scrollTo({
        top: 0,
        behavior: "smooth",
    })
})
function sendSortSelectedValue() {
    var selectElement = document.getElementById("sortSelect");
    var selectedValue = selectElement.value;

    window.location.href = `/Catalog/GetSortSelectedValue?value=${encodeURIComponent(selectedValue)}`;
}

function sendOptionSelectedValue() {
    var selectElement = document.getElementById("optionSelect");
    var selectedValue = selectElement.value;

    window.location.href = `/Catalog/GetOptionSelectedValue?value=${encodeURIComponent(selectedValue)}`;
}


var swiper = new Swiper(".mySwiper", {
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    autoplay: {
      delay: 5000,
    },
    speed: 3000,
    loop: true,
  });
