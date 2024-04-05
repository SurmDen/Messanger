let inputs= document.querySelectorAll(".form-group input");
let codeInput = document.querySelector('.code');
let sender = document.getElementById('sender');
let emailInput = document.querySelector('.email');

if (sender.textContent.includes('create')) {
    document.querySelector('.code-hider').style.display = 'flex';
    document.querySelector('.code').style.border = '3px solid #23af32';
} else {
    document.querySelector('.code-hider').style.display = 'none';
}

Array.from(inputs).forEach((i)=>{
    i.addEventListener("focus", ()=>{
        i.style.color = 'white';
        i.style.boxShadow = '0 0 15px white';
        i.style.border = '2px solid white';
        i.style.fontStyle = 'normal';

        if (i.value === 'example: user@gmail.com') {
            i.value = '';
        }

        sender.disabled = false;
    });

    i.addEventListener("blur", ()=>{
        i.style.boxShadow = 'none';
    });
});

sender.parentNode.addEventListener('mousedown', () => {
    let hasError = false;
    Array.from(inputs).forEach((i) => {
        if (i.value === '') {
            i.style.border = '2px solid #f63f3f';
            hasError = true;
        }
    });

    if (hasError) {
        sender.disabled = true;
    }

    if (!emailInput.value.includes('@gmail.com')) {
        sender.disabled = true;
        emailInput.style.border = '2px solid #f63f3f';
        emailInput.style.fontStyle = 'italic';
        emailInput.color = '#f63f3f';
        emailInput.value = 'example: user@gmail.com';
    }
});

codeInput.addEventListener('focus', () =>
{
    if (codeInput.value > 0) {
        return;
    }

    codeInput.value = '';

});

codeInput.addEventListener('blur', () => {
    if (codeInput.value > 0) {
        return;
    }

    codeInput.value = 0;

});





