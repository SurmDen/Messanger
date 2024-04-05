function init(){
    let searchPannel = document.querySelector('.search-pannel');

    let usrBox = document.querySelector('.users');
    usrBox.style.height = document.documentElement.clientHeight-290 + 'px';

    if(document.documentElement.clientWidth < 1085){
        document.querySelector('.elems').style.flexDirection = 'column';
    }else{
        document.querySelector('.elems').style.flexDirection = 'row';
    }

    //searchPannel = document.querySelector('.search-pannel');
    //searchPannel.style.height = document.documentElement.clientHeight-100 + 'px';
}

init();

window.addEventListener('resize', ()=>{
    init();
})


let userList  = document.querySelector('.users');

Array.from(document.querySelectorAll('.search-elem input')).forEach(i=>{

    i.addEventListener('focus', ()=>{
        i.classList.add('active');
    });

    i.addEventListener('blur', ()=>{
        i.classList.remove('active');
    });

});


document.querySelector('.search-btn').addEventListener('mousedown', (e)=>{
    e.target.classList.add('active');
    
});

document.querySelector('.search-btn').addEventListener('mouseup', (e) => {

    e.target.classList.remove('active');

});


