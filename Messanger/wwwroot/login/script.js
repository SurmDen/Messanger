document.body.style.width = document.documentElement.clientWidth + 'px';

let container = document.querySelector(".container");

document.querySelector('.btn button').addEventListener("mousedown", ()=>{
    document.querySelector('.btn button').style.boxShadow = '0 0 12px white';
});

document.querySelector('.btn button').addEventListener("mouseup", ()=>{
    document.querySelector('.btn button').style.boxShadow = 'none';
});

document.querySelector('.redirect').addEventListener("mousedown", () => {
    document.querySelector('.redirect').style.boxShadow = '0 0 12px white';
});

document.querySelector('.redirect').addEventListener("mouseup", () => {
    document.querySelector('.redirect').style.boxShadow = 'none';
});

document.querySelectorAll('.form-group input').forEach(i => {
    i.addEventListener('focus', () => {

        document.querySelector('.btn button').disabled = false;
        i.style.boxShadow = '0 0 10px white';
        i.style.border = '2px solid white';

    });

    i.addEventListener('blur', () => {

        i.style.boxShadow = 'none';

    });


});

document.querySelector('.btn button').addEventListener('mousedown', () => {
    console.log('action')

    if (document.querySelector('.name-input').value === '' || document.querySelector('.pass-input').value === '') {
        document.querySelector('.btn button').disabled = true;
    } else {
        document.querySelector('.btn button').disabled = false;
    }

    Array.from(document.querySelectorAll('.form-group input')).forEach(i => {
        if (i.value === '') {
            i.style.border = '2px solid #f63f3f';
        } else {
            i.style.border = '2px solid #23af32';
        }
    });

});



