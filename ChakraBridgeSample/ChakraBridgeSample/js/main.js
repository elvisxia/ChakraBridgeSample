(function () {
    //var data = {
    //    name: "winffee",
    //    age:18
    //};
    var data = math.atan2(3, -3) / math.pi;
    sendToHost(JSON.stringify(data), "Double");
})()