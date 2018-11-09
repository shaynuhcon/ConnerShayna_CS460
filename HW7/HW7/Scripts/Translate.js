var box = document.getElementById("words");
box.addEventListener("keypress",
    function(e) {
        if (e.key === " " || e.key === "Spacebar") {
            var words = $(this).text().split(" ");
            var lastWord = words[words.length - 1];
            console.log(lastWord);
            getData();
        }
    });

function getData() {
    var word = $("#words").val();
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
    var obj = JSON.parse(data);
    var url = obj.data.embed_url;
    $("#output").text(url);
    show_image(url);
}

function errorOnAjax() {
    console.log("error");
}

function show_image(src) {
    var x = document.createElement("IMG");
    var div = document.getElementById("output");

    x.setAttribute("src", src);
    x.setAttribute("width", "304");
    x.setAttribute("height", "228");
    x.setAttribute("alt", "Photo");
    div.innerHTML += x;
}
