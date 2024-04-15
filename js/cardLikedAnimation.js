const cardLiked = document.querySelector('.card__liked');

cardLiked.addEventListener('click', ()=>{
    cardLiked.classList.toggle("card__liked--active");
})
