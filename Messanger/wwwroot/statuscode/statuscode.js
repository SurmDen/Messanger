let container = document.querySelector('.container');
let hrefs = document.querySelectorAll('.link a');

const urlParams = new URLSearchParams(window.location.search);
const myParam = urlParams.get('code');

document.querySelector('.code').innerHTML = myParam;

function init(){
    if(document.documentElement.clientWidth < 770){
        container.style.flexDirection = 'column';
    }else{
        container.style.flexDirection = 'row';
    }
}

init();

window.addEventListener('resize', ()=>{
    init();
});

Array.from(hrefs).forEach(i=>{
    i.addEventListener('mousedown', ()=>{
        i.style.boxShadow = '0 0 15px white';
    });

    i.addEventListener('mouseup', ()=>{
        i.style.boxShadow = 'none';
    });

    i.addEventListener('touchstart', ()=>{
        i.style.boxShadow = '0 0 15px white';
    });

    i.addEventListener('touchend', ()=>{
        i.style.boxShadow = 'none';
    });
});



