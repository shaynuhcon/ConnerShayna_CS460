// Wait for spacebar to be pressed on textbox 
var userInput = document.getElementById("userInput");
userInput.addEventListener("keypress",
    function(e) {
        if (e.key === " " || e.key === "Spacebar") {
            getData();
        }
    });

// Clear textbox 
var clear = document.getElementById("clear");
clear.addEventListener("click",
    function() {
        location.reload();
    });

// Get most recent word entered in textbox and send to controller
function getData() {
    var userInput = $("#userInput").val();
    var words = userInput.split(" ");
    var lastWord = words[words.length - 1];

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "../Translate/" + lastWord,
        success: displayData,
        error: errorOnAjax
    });
}

// If "boring" word, add to output as string otherwise show gif 
function displayData(data) {
    var div = document.getElementById("output");

    if (typeof data == "string") {
        div.innerHTML += data + " ";
    } else {
        show_image(data.data.embed_url);
    }
}

// Append gif to output 
function show_image(src) {
    var div = document.getElementById("output");
    var sticker = '<iframe src="' +
        src +
        '" width="150" height="150" frameBorder="0" class="giphy-embed" allowFullScreen></iframe>';
    div.innerHTML += sticker;
}

// Error
function errorOnAjax() {
    console.log("error");
}
