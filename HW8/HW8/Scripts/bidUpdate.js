var update = function getBidsByItem() {

    var id = $("#id").val();
    //$.ajax({
    //        type: "GET",
    //        url: "../../Bid/BidsByItem/" + id
    //    })
    //    .done(function(partialViewResult) {
    //        $("#bids").html(partialViewResult);
    //    });

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "../../Bid/BidsByItemJson/" + id,
        success: listBids,
        error: showError
    });
};

function listBids(bids) {
    if (bids.length !== 0) { 
        $("noBids").empty();
        $("tbody").empty();

        for (var i = 0; i < bids.length; i++) {
            var price = bids[i].Price.toFixed(2);

            $("tbody").append("<tr><td>" + bids[i].Timestamp
                + "</td><td>" + bids[i].BuyerName
                + "</td><td>$" + price + "</tr>");
        }
    }
    else {
        $("noBids").append("No existing bids for this item!");
    }
}

// Add bids when page loads
window.onload = update;

// Update bids every 5 seconds
var interval = 1000 * 5; 
window.setInterval(update, interval);

function showError() {
    alert("Error loading bids.");
}