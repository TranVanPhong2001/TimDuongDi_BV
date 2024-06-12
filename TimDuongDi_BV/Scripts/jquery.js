let items = document.querySelectorAll('.slider .list .item');
let next = document.getElementById('next');
let prev = document.getElementById('prev');
let thumbnails = document.querySelectorAll('.thumbnail .item');
let countItem = items.length;
let itemActive = 0;

next.onclick = function(){
    itemActive = itemActive + 1;
    if(itemActive >= countItem){
        itemActive = 0;
    }
    showSlider();
}
prev.onclick = function(){
    itemActive = itemActive - 1;
    if(itemActive < 0){
        itemActive = countItem - 1;
    }
    showSlider();
}

let refreshInterval = setInterval(() => {
    next.click();
}, 5000)

//Slider
function showSlider(){
    let itemActiveOld = document.querySelector('.slider .list .item.active');
    let thumbnailActiveOld = document.querySelector('.thumbnail .item.active');
    itemActiveOld.classList.remove('active');
    thumbnailActiveOld.classList.remove('active');
    items[itemActive].classList.add('active');
    thumbnails[itemActive].classList.add('active');
    clearInterval(refreshInterval);
    refreshInterval = setInterval(() => {
        next.click();
    }, 5000)
}
thumbnails.forEach((thumbnail, index) => {
    thumbnail.addEventListener('click', () => {
        itemActive = index;
        showSlider();
    })
})

//MAP
const panels = document.querySelectorAll(".panel");
panels.forEach((panel)=> {
    panel.addEventListener("click", () => {
        removeActiveClasses();
        panel.classList.add("active");
    });
});

function removeActiveClasses() {
    panels.forEach((panel) =>{
        panel.classList.remove("active");
    })
}

//scroll_to_top
let span = document.querySelector(".scroll_to_top");

window.onscroll = function () {
    this.scrollY >= 500 ? span.classList.add("show") : span.classList.remove("show");
};

span.onclick = function () {
    window.scrollTo({
        top: 0,
        behavior: "smooth",
    });
};
