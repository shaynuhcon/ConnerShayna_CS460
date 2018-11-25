var update = function getBidsByItem() {

    var id = $("#id").val();
    $.ajax({
            type: "GET",
            url: "../../Bid/BidsByItem/" + id
        })
        .done(function(partialViewResult) {
            $("#bids").html(partialViewResult);
        });
};

// Add bids when page loads
window.onload = update;

// Update bids every 5 seconds
var interval = 1000 * 5; 
window.setInterval(update, interval);