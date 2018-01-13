function feed() {
    $(document).ready(function () {
        $.get("feedjs", function (data) {
            $(".fullnessCount").text(data);
            console.log(data);
        });
        var counter = parseInt($(".fullnessCount").text());
        console.log(counter);
        $(".fullnessCount").text(counter);
    });
}