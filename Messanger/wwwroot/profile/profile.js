let slider = document.querySelector('.slider');
let width;
let sliderCounter = 0;
let imgs;


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

    document.querySelector('.sub-form').style.width = width+'px';

    slider.style.height = width+'px';

    imgs.forEach(s=>{
        s.style.width = width+'px';
        s.style.height = width+'px';
    });

    document.querySelector('.active-buttons').style.width = width+'px';
}

init();

window.addEventListener('resize', ()=>{
    init();
    initGallery();
});

slider.addEventListener('click', (e)=>{

    let left = slider.getBoundingClientRect().left;
    let mid = left + slider.clientWidth/2;
    let xCoord = e.clientX;
    console.log(`mid: +${mid}`);
    console.log(`x: +${xCoord}`);

    if(xCoord > mid){
        
        sliderCounter--;

    }else{
        
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


document.querySelector('.sub-btn').addEventListener('mousedown', (e)=>{

    e.target.classList.add('active-button');

});


document.querySelector('.sub-btn').addEventListener('mouseup', (e)=>{

    e.target.classList.remove('active-button');

});

document.querySelector('.m-btn').addEventListener('mousedown', (e)=>{

    e.target.classList.add('active-button');

});


document.querySelector('.m-btn').addEventListener('mouseup', (e)=>{

    e.target.classList.remove('active-button');

});

//document.querySelector('.sub-btn').addEventListener('click', (e)=>{

//    if(e.target.getAttribute('sub') === 'no'){

//        e.target.style.backgroundColor = 'rgb(221, 99, 99)';
//        e.target.innerHTML = 'UNSCRIBE';
//        e.target.setAttribute('sub', 'ok');

//    }else{

//        e.target.style.background = 'none';
//        e.target.innerHTML = 'SUBSCRIBE';
//        e.target.setAttribute('sub', 'no');
//    }

//});


document.querySelector('.slider').addEventListener('mouseover', (e)=>{

    document.querySelector('.l-nav').style.opacity = '0.8';
    document.querySelector('.r-nav').style.opacity = '0.8';

});


document.querySelector('.slider').addEventListener('mouseout', (e)=>{
  
    document.querySelector('.l-nav').style.opacity = '0';
    document.querySelector('.r-nav').style.opacity = '0';

});

document.querySelector('.error-btn').addEventListener('click', (e)=>{

    e.preventDefault(false);
    document.querySelector('.error-box').style.display = 'none';
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


//document.querySelector('.like-button').addEventListener('mousedown', (e)=>{

//    document.querySelector('.like-button').classList.add('active-button');

//});

//document.querySelector('.like-button').addEventListener('mouseup', (e)=>{

//    document.querySelector('.like-button').classList.remove('active-button');

//});


