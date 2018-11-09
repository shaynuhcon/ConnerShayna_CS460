var box = document.getElementById("userInput");
box.addEventListener("keypress", function(e) {
        if (e.key === " " || e.key === "Spacebar") {
            getData();
        }
    });

function getData() {
    var userInput = $("#userInput").val();
    var words = userInput.split(" ");
    var lastWord = words[words.length - 1];

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "/Translate/Translate/",
        data: {"lastWord" : lastWord },
        success: displayData,
        error: errorOnAjax
    });
}

function displayData(data) {
    var div = document.getElementById("output");

    if (typeof data == "string") {
        div.innerHTML += data + " ";
    }
    else {
        show_image(data.data.url);
    }
}

function errorOnAjax() {
    console.log("error");
}

function show_image(src) {
    var img = new Image();

    img.src = src;
    $("#output").html(img);
}
