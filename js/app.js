document.querySelector('#user-btn').addEventListener('click', function (e) {
    var div = document.querySelector('#login-window')
    div.style.display = div.style.display === 'none' ? 'block' : 'none'
})