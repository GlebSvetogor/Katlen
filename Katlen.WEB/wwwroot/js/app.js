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

butLinkWholesale.addEventListener('click', () => {
    toggleVisibility(wholesaleMore);
    toggleVisibility(wholesaleIcon);
})

loginBtn.addEventListener('click', () => {
    toggleVisibility(loginWindow);
});

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

const inputField = document.getElementById('search-input');
const outputBlock = document.getElementById('search-result');

const basketBtn = document.getElementById('basket-btn');
const basketOutputBlock = document.getElementById('basket-result');
const body = document.getElementsByClassName('body');

document.addEventListener('click', function(event) {
    if (event.target != basketBtn && !basketOutputBlock.contains(event.target) && !basketBtn.contains(event.target)) {
        basketOutputBlock.classList.add('hidden');
    }
});

basketBtn.addEventListener('click', function() {
    basketOutputBlock.classList.toggle('hidden');
});

inputField.addEventListener('focus', function() {
    outputBlock.classList.remove('hidden');
});

  inputField.addEventListener('blur', function() {
    outputBlock.classList.add('hidden');
  });

