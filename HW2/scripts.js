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