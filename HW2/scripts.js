
  // Load nav bar on each HTML page
$("#nav-placeholder").load("nav.html");

// Set original quantity values for recipe on mochikochicken.html
$("#chicken").text(Calculate(6, "chicken"));
$("#flour").text(Calculate(6, "flour"));
$("#cornstarch").text(Calculate(6, "cornstarch"));
$("#sugar").text(Calculate(6, "sugar"));
$("#shoyu").text(Calculate(6, "shoyu"));
$("#seeds").text(Calculate(6, "seeds"));
$("#ginger").text(Calculate(6, "ginger"));
$("#gronions").text(Calculate(6, "gronions"));
$("#salt").text(Calculate(6, "salt"));
$("#garlic").text(Calculate(6, "garlic"));
$("#eggs").text(Calculate(6, "eggs"));


// Function called when Update button clicked on mochikochicken.html 
  $("#update").click(function () {
    var sizeVal = $("#size").val();

    $("#chicken").text(Calculate(sizeVal, "chicken"));
    $("#flour").text(Calculate(sizeVal, "flour"));
    $("#cornstarch").text(Calculate(sizeVal, "cornstarch"));
    $("#sugar").text(Calculate(sizeVal, "sugar"));
    $("#shoyu").text(Calculate(sizeVal, "shoyu"));
    $("#seeds").text(Calculate(sizeVal, "seeds"));
    $("#ginger").text(Calculate(sizeVal, "ginger"));
    $("#gronions").text(Calculate(sizeVal, "gronions"));
    $("#salt").text(Calculate(sizeVal, "salt"));
    $("#garlic").text(Calculate(sizeVal, "garlic"));
    $("#eggs").text(Calculate(sizeVal, "eggs"));
});

// Calculates serving size portions
function Calculate(sizeVal, food) {
    switch (food) {
        case "chicken":
        case "garlic":
        case "eggs":
            return (Math.round((0.33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333 * sizeVal) * 2) / 2).toFixed(1);
        case "flour":
        case "cornstarch":
        case "sugar":
        case "shoyu":
            return (Math.round((0.66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666667 * sizeVal) * 2) / 2).toFixed(1);
        case "seeds":
            return (Math.round((0.16666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666667 * sizeVal) * 2) / 2).toFixed(1);
        case "ginger":
        case "gronions":
        case "salt":
            return (Math.round((0.083333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333 * sizeVal) * 2) / 2).toFixed(1);
    }
};

// Contacts page
$("#submit").click(function () {
    var name = document.getElementById("nameInput").value;
    var email = document.getElementById("emailInput").value;
    var type = document.getElementById("selectInput").value;
    
    if(type == "Have a question or comment")
    {
        $("#greeting").text("Thanks for sending a message, " + name + "! I'll get back to you soon! "
        + "But not really because this site is fake.");
    }
    else
    {
        $("#greeting").text("Thanks for signing up to receive my recipes, " 
        + name + "! They'll be sent to you at " + email + " as they become available. "
        + " But not really because this site is fake.");
    }
});