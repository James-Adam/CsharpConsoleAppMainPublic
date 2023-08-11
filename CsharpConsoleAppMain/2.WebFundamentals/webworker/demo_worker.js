addEventListener("message",
    function(evt) {
        var date = new Date();
        var currentDate = null;
        do {
            currentDate = new Date();
            postMessage(currentDate);
            sleep(1000);
        } while (currentDate - date < evt.data);
    },
    false);

function sleep(ms) {
    var date = new Date();
    var currentDate = null;
    do {
        currentDate = new Date();
    } while (currentDate - date < ms);
}