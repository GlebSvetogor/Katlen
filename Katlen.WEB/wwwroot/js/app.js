const loginWindow = document.querySelector(".window--login");
const loginBtn = document.querySelector(".header__heading-user");
const loginWindowSignupBtn = document.querySelector(".window__signup-btn");
const closeLoginBtn = document.querySelector(".window__close-btn--login");

const signupWindow = document.querySelector(".window--signup");
const signupWindowLoginBtn = document.querySelector(".window__login-btn");
const closeSignupBtn = document.querySelector(".window__close-btn--signup");

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

closeLoginBtn.addEventListener('click',() => {
    const result = getClassNameFromElement(loginWindow);
    windowVisibility(result);
});

loginBtn.addEventListener('click', () => {
    const result = getClassNameFromElement(loginWindow);
    windowVisibility(result);
});

loginWindowSignupBtn.addEventListener('click',() => {
    const resultSignup = getClassNameFromElement(signupWindow);
    const resultLogin = getClassNameFromElement(loginWindow);
    windowVisibility(resultLogin);
    windowVisibility(resultSignup);
});

closeSignupBtn.addEventListener('click', () => {
    const result = getClassNameFromElement(signupWindow);
    windowVisibility(result);
});

signupWindowLoginBtn.addEventListener('click', () => {
    const resultSignup = getClassNameFromElement(signupWindow);
    const resultLogin = getClassNameFromElement(loginWindow);
    windowVisibility(resultLogin);
    windowVisibility(resultSignup);
})

function windowVisibility(elementClassName) {
    var el = document.querySelector(elementClassName);
    if(el){
        const computedStyle = window.getComputedStyle(el);
        const displayValue = computedStyle.getPropertyValue('display');
        switch (displayValue){
            case "none":
                el.style.display = "flex";
                break;
            case "flex":
                el.style.display = "none";
                break;
            default:
                console.log("element not found");
        }
    }
}

function getClassNameFromElement(el){
    const inputString = el.className;
    const startIndex = inputString.indexOf(" ") + 1;
    const result = "." + inputString.substring(startIndex);
    return result;
}
