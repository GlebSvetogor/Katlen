const commentBtn = document.getElementById('comment-btn');
const commentOutputBlock = document.getElementById('comment-block');
const commentCloseBtn = document.getElementById('comment-closeBtn');

commentBtn.addEventListener('click' ,()=>{
    commentOutputBlock.classList.remove("hidden");
})

commentCloseBtn.addEventListener('click' ,()=>{
    commentOutputBlock.classList.add("hidden");
})
