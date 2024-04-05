let container = document.querySelector('.container');

function init(){
    container.style.height = document.documentElement.clientHeight - 20 + 'px';
    if(document.documentElement.clientWidth > 1200){
        container.style.width = '40%';
    }

    if(document.documentElement.clientWidth< 1200 &&  document.documentElement.clientWidth >700){
        container.style.width = '70%';
    }

    if(document.documentElement.clientWidth  <  700){
        container.style.width = '100%';
    }
}

init();

window.addEventListener('resize', ()=>{
    init();
});