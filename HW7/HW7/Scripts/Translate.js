// Our Javascript goes here

console.log("In numbers.js");

var body = document.querySelector("body");
body.addEventListener("keydown", function (e) {
    var isInput = ~["TEXTAREA", "INPUT"].indexOf(e.target.tagName);
    if (e.key === " " && !isInput) {
        getData();
        console.log("u clicked spacebar, and it wasn't in an input");
    }
});

function getData() {
    var word = $("#word").val();
    console.log(word);
    var source = "/Translate/Translate/" + word;
    console.log(source);

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
}

function displayData(data) {
    console.log(data);
    var parsed = JSON.parse(data);
}

function errorOnAjax() {
    console.log("error");
}
