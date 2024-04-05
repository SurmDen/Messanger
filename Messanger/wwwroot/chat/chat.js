

function initWindowSize(){

    let windowMes =  document.querySelector('.chat-box');
    let width = document.documentElement.clientWidth;


    if(width > 1200){
        windowMes.style.width = 40+'%';
    }
    if(width < 1200 && width > 900){
        windowMes.style.width = 65+'%';
    }
    if( width < 900){
        windowMes.style.width = 90+'%';
    }

    let h = document.documentElement.clientHeight;
    console.log(h);

    windowMes.style.height = `${h-100}px`;
}

initWindowSize();

window.addEventListener('resize', () => {
    initWindowSize();
});

document.querySelector('.text-holder').addEventListener('focus', (e)=>{

    document.querySelector('.text-holder').style.color = 'white';
    document.querySelector('.text-holder').classList.add('active-inp');
    console.log("focused");

});

document.querySelector('.text-holder').addEventListener('blur', (e)=>{

    document.querySelector('.text-holder').style.color = 'rgb(161, 14, 14)';
    document.querySelector('.text-holder').classList.remove('active-inp');

});

document.querySelector('.send-btn').addEventListener('mousedown', ()=>{

    document.querySelector('.send-btn').classList.add('active-button');

});

document.querySelector('.send-btn').addEventListener('mouseup', ()=>{

    document.querySelector('.send-btn').classList.remove('active-button');
    
});