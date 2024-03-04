var registratinoBtn = document.getElementById("signup-btn");
var registrationWindow = document.getElementById("signup-window");
var loginBtn = document.getElementById("login-btn");
var loginWindow = document.querySelector("#login-window");
var userBtn = document.querySelector("#user-btn");

user-btn.addEventListener('click', () => {
    loginWindow.style.display = loginWindow.style.display === 'none' ? 'block' : 'none';
});