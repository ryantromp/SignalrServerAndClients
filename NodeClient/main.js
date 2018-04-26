const signalR = require('@aspnet/signalr')
const readline = require('readline')

XMLHttpRequest = require('xmlhttprequest').XMLHttpRequest;
WebSocket = require('websocket').w3cwebsocket;

const ask = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});


const url = `http://localhost:9000/eventHub`;

let hubConnection = new signalR.HubConnection(url, {               
        transport: signalR.TransportType.WebSockets,
        logger: signalR.LogLevel.Trace,                        
});

hubConnection.onreceive = data => console.log(data);

hubConnection.onclose = err => console.log(`connection closed: ${err}`);

hubConnection.start().then((err) => {
    if (err) {
        console.log(`Error starting connection: ${err}`)
        return;
    }

    process.stdin.once('data', () => {
        hubConnection.stop()
    });
})
