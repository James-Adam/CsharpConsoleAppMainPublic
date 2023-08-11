addEventListener("message",
    function(evt) {
        sleep(1000);

        postMessage(evt.data);
    });

function sleep(ms) {
    var date = new Date();
    var currentDate = null;
    do {
        currentDate = new Date();
    } while (currentDate - date < ms);
}