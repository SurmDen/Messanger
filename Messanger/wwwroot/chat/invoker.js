let hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('/chat')
    .build();

let otherEmail = document.querySelector('.other').value;

document.querySelector('.send-btn').addEventListener('click', () => {

    let message = document.querySelector('.text-holder').value;

    hubConnection.invoke('Send', message, otherEmail);

});

hubConnection.on('Receive', function (mess, email) {

    let wind = document.querySelector('.window')

    let domMes = document.createElement('div');
    domMes.innerHTML = mess;

    if (otherEmail != email) {
        domMes.classList.add('current-message');
    } else {
        domMes.classList.add('user-message');
    }

    wind.appendChild(domMes);

});

hubConnection.start();

document.querySelector('.window').scrollTop = document.querySelector('.window').scrollHeight;