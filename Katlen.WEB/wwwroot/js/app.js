const signupWindow = document.querySelector(".window--signup");
const signupWindowLoginBtn = document.querySelector(".window__login-btn");
const closeSignupBtn = document.querySelector(".window__close-btn--signup");

const loginBtn = document.querySelector(".header__heading-user");
const loginWindow = document.querySelector(".window--login");
const loginWindowSignupBtn = document.querySelector(".window__signup-btn");
console.log('from login to signup = ' + loginWindowSignupBtn)
const closeLoginBtn = document.querySelector(".window__close-btn--login");

function toggleWindowVisibility(element) {
    element.classList.toggle('active');
}

loginBtn.addEventListener('click', () => {
    toggleWindowVisibility(loginWindow);
});

closeLoginBtn.addEventListener('click', () => {
    toggleWindowVisibility(loginWindow);
});

loginWindowSignupBtn.addEventListener('click', () => {
    toggleWindowVisibility(loginWindow);
    toggleWindowVisibility(signupWindow);
})

closeSignupBtn.addEventListener('click', () => {
    toggleWindowVisibility(signupWindow);
})

signupWindowLoginBtn.addEventListener('click', () => {
    toggleWindowVisibility(signupWindow);
    toggleWindowVisibility(loginWindow);
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

