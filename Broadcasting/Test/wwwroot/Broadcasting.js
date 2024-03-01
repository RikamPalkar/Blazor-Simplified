const channel = new BroadcastChannel("Rikam");
let globaldata = '';

function sendBroadcast(data) {
    console.log("Broadcast message sent -->", data);
    channel.postMessage(data);
};

channel.onmessage = function (event) {
    console.log("Broadcast message received <--", event.data);
    receiveBroadcast(event.data);
};

function receiveBroadcast(data){
    const element = document.getElementById("broadcastingReceiver");
    globaldata = data;
    let e = new CustomEvent("Broadcast", {
        bubbles: true,
        detail: { data: () => globaldata }
    });
    element.dispatchEvent(e);
}