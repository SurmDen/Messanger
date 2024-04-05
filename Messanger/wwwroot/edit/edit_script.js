let inputs = document.querySelectorAll('.form-group input');
let button = document.querySelector('.btn');
let currentPassInput = document.querySelector('.curr-pass');
let newPassInput = document.querySelector('.new-pass');

Array.from(inputs).forEach((i) => {
    i.addEventListener('focus', ()=>{
        i.style.boxShadow = '0 0 10px white';
        i.style.border = '2px solid white';
    });

    i.addEventListener('blur', ()=>{
        i.style.boxShadow = 'none';
    });
});

button.addEventListener('mousedown', (e)=>{
    e.target.style.boxShadow = '0 0 15px white';
});

button.addEventListener('mouseup', (e)=>{
    e.target.style.boxShadow = 'none';
});

button.addEventListener('touchstart', (e)=>{
    e.target.style.boxShadow = '0 0 15px white';
});

button.addEventListener('touchend', (e)=>{
    e.target.style.boxShadow = 'none';
});

currentPassInput.addEventListener('focus', ()=>{
    newPassInput.disabled = false;
})

newPassInput.addEventListener('mousedown', ()=>{
    if(currentPassInput.value === ''){

        currentPassInput.style.border = '2px solid rgb(246, 58, 58)';
        newPassInput.disabled = true;

    }else{

        newPassInput.disabled = false;

    }
});