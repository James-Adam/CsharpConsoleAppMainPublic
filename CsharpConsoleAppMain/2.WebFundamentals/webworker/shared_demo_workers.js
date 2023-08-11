var ports = [];
addEventListener("connect",
    function(evt) {
        var port = evt.ports[0];
        ports.push(port);
        port.addEventListener("message",
            function(evt) {
                var date = new Date();
                var currentDate = null;
                do {
                    currentDate = new Date();
                    for (i = 0; i < ports.length; i++) {
                        ports[i].postMessage(currentDate);
                    }
                    sleep(1000);
                } while (currentDate - date < evt.data);
            },
            false);
        port.start();
    },
    false);

function sleep(ms) {
    var date = new Date();
    var currentDate = null;
    do {
        currentDate = new Date();
    } while (currentDate - date < ms);
}