let slider = document.querySelector('.slider');
let width;
let sliderCounter = 0;
let imgs;
let infoBox = document.querySelector('.info-box');
let linkBox = document.querySelector('.link-box');

function initLinkBox() {
    if (document.documentElement.clientWidth > 1050) {
        linkBox.style.width = '40%';
        document.querySelector('.link-container').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 1050 && document.documentElement.clientWidth > 500) {
        linkBox.style.width = '70%';
        document.querySelector('.link-container').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 500) {
        linkBox.style.width = '95%';
        document.querySelector('.link-container').style.paddingTop = '10px'
    }

}

initLinkBox();

window.addEventListener('resize', () => {
    initLinkBox();
});

document.querySelector('.link-closer').addEventListener('click', (e) => {
    document.querySelector('.link-container').style.display = 'none';
});

document.querySelector('.show-link').addEventListener('click', () => {
    document.querySelector('.link-container').style.display = 'flex';
});

function initInfoBox() {
    if (document.documentElement.clientWidth > 1050) {
        infoBox.style.width = '40%';
        document.querySelector('.info-container').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 1050 && document.documentElement.clientWidth > 500) {
        infoBox.style.width = '70%';
        document.querySelector('.info-container').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 500) {
        infoBox.style.width = '95%';
        document.querySelector('.info-container').style.paddingTop = '10px'
    }

}

initInfoBox();

window.addEventListener('resize', () => {
    initInfoBox();
});

document.querySelector('.info-closer').addEventListener('click', (e) => {
    document.querySelector('.info-container').style.display = 'none';
});

document.querySelector('.show-info').addEventListener('click', (e) => {
    document.querySelector('.info-container').style.display = 'flex';
});

function initNavBar(){

    let windowWidth2 = document.documentElement.clientWidth;
    let navBar = document.querySelector('.main-menu');
    if(windowWidth2 > 1187){
        navBar.style.gridTemplateColumns = '1fr 1fr 1fr 1fr 1fr 1fr ';
    }
    if (windowWidth2 < 1187 &&  windowWidth2 > 697) {
        navBar.style.gridTemplateColumns = '1fr 1fr 1fr';
    }
    if (windowWidth2 < 697) {
        navBar.style.gridTemplateColumns = '1fr 1fr';
    }
    if (windowWidth2 < 460) {
        navBar.style.gridTemplateColumns = '1fr';
    }
}

initNavBar();

function initGallery(){
    let windowWidth3 = document.documentElement.clientWidth;
    let photoBox = document.querySelector('.photos');

    if(windowWidth3 < 670 && windowWidth3 > 460){
        photoBox.style.gridTemplateColumns = '210px 210px';
    }else{
        photoBox.style.gridTemplateColumns = '210px 210px 210px';
    }
    if(windowWidth3 < 460){
        photoBox.style.gridTemplateColumns = ' 210px';
    }

    if(windowWidth3 < 700){
        document.querySelector('.large-img').style.width = '80%';
    }else{
        document.querySelector('.large-img').style.width = '45%';
    }
}

initGallery();

function init(){

    let windowWidth = document.documentElement.clientWidth;

    if(windowWidth > 600 && windowWidth < 1000){
        slider.style.width = '40%';
    }
    if(windowWidth > 1000){
        slider.style.width = '20%';
    }
    if(windowWidth < 600){

        slider.style.width = '80%';

    }

    width = slider.clientWidth;
    imgs = Array.from(document.querySelectorAll('.slider-elem'));
    document.querySelector('.sliderline').style.width = imgs.length*width+'px';

    document.querySelector('.img-form').style.width = width+'px';

    slider.style.height = width+'px';

    imgs.forEach(s => {
        s.style.width = width + 'px';
        s.style.height = width + 'px';
    });

    document.querySelectorAll('.options').forEach(i => {
        i.style.left = width / 2 - 25 + 'px';
    });

    document.querySelectorAll('.img-remove').forEach(i => {
        i.style.left = width / 2 - 25 + 'px';
    });
}

init();

window.addEventListener('resize', ()=>{
    init();
    initNavBar();
    initGallery();
});

slider.addEventListener('click', (e)=>{

    let left = slider.getBoundingClientRect().left;
    let mid = left + slider.clientWidth/2;
    let xCoord = e.clientX;
    console.log(`mid: +${mid}`);
    console.log(`x: +${xCoord}`);

    if(xCoord > mid + 50){
        
        sliderCounter--;

    } if (xCoord < mid - 50){
        
        sliderCounter++;

    }

    if (sliderCounter === -imgs.length) {
        sliderCounter = 0;
    }

    if(sliderCounter === 1){
        sliderCounter = -imgs.length + 1;
    }

    console.log(sliderCounter);

    document.querySelector('.sliderline').style.transform = `translate(${width*sliderCounter}px)`

});

document.querySelector('.img-form button').addEventListener('mousedown', (e)=>{

    e.target.classList.add('active-button');

});


document.querySelector('.img-form button').addEventListener('mouseup', (e)=>{

    e.target.classList.remove('active-button');

});

document.querySelector('.img-form input').addEventListener('input', (e) => {

    if (document.querySelector('.img-form input').value !== '') {

        document.querySelector('.img-form button').style.border = '3px solid #21932d';
    }

});

document.querySelector('.slider').addEventListener('mouseover', (e)=>{

    document.querySelector('.l-nav').style.opacity = '0.8';
    document.querySelector('.r-nav').style.opacity = '0.8';

});

document.querySelector('.slider').addEventListener('mouseout', (e)=>{
  
    document.querySelector('.l-nav').style.opacity = '0';
    document.querySelector('.r-nav').style.opacity = '0';

});

document.querySelector('.closer').addEventListener('click', ()=>{
    document.querySelector('.image-box').style.display = 'none';
});

document.querySelector('.photos').addEventListener('click', (e)=>{

    if(e.target.closest('img')){
        document.documentElement.scrollTo(0,0);
        document.querySelector('.full-image').setAttribute('src', e.target.getAttribute('src'));
        document.querySelector('.image-box').style.display = 'flex';
        console.log(e);
    }

});

document.querySelector('.note-open').addEventListener('click', () => {
    document.querySelector('.notify-box').style.display = 'flex';
});

document.querySelector('.note-closer').addEventListener('click', () => {
    document.querySelector('.notify-box').style.display = 'none';
});

let isOptionsClicked = false;

document.querySelectorAll('.options').forEach(i => {

    i.addEventListener('click', () => {
        if (isOptionsClicked) {
            document.querySelectorAll('.img-remove').forEach(j => {
                if (i.parentNode === j.parentNode) {
                    j.style.display = 'none';
                }
            });
            isOptionsClicked = false;
        } else {
            document.querySelectorAll('.img-remove').forEach(j => {
                if (i.parentNode === j.parentNode) {
                    j.style.display = 'flex';
                }
            });
            isOptionsClicked = true;
        }
    });
});

document.querySelectorAll('.img-remove').forEach(j => {
    j.addEventListener('click', () => {
        j.style.display = 'none';
    })
});

let notifyBox = document.querySelector('.notify-pannel');

function initNotifyBox() {
    if (document.documentElement.clientWidth > 1050) {
        notifyBox.style.width = '40%';
        document.querySelector('.notify-box').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 1050 && document.documentElement.clientWidth > 500) {
        notifyBox.style.width = '70%';
        document.querySelector('.notify-box').style.paddingTop = '100px';
    }

    if (document.documentElement.clientWidth < 500) {
        notifyBox.style.width = '95%';
        document.querySelector('.notify-box').style.paddingTop = '10px'
    }

}

initNotifyBox();

window.addEventListener('resize', () => {
    initNotifyBox();
});

Array.from(document.querySelectorAll('.scroller')).forEach(i => {
    i.addEventListener('click', () =>
    {
        window.scrollTo(0,0);
    })
});


