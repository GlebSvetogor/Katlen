const loginWindow = document.querySelector(".window--login");
const loginBtn = document.querySelector(".header__heading-user");
const closeLoginBtn = document.querySelector(".window__close-btn--login");



loginBtn.addEventListener('click',openLoginWindow);

function openLoginWindow(){
    loginWindow.style.display = "flex";
}

function closeLoginWindow(){
    loginWindow.style.display = "none";
}
