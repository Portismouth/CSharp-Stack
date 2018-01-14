// function feed() {
//     $(document).ready(function () {
//         $.get("feedjs", function (data) {
//             // $(".fullnessCount").text(data);
//             console.log(data);
//         });
//         // var counter = parseInt($(".fullnessCount").text());
//         // console.log(counter);
//         // $(".fullnessCount").text(counter);
//     });
// }
// function play() {
//     $(document).ready(function () {
//         $.get("playjs", function (data) {
//             $(".fullnessCount").text(data);
//             console.log(data);
//         });
//         var counter = parseInt($(".fullnessCount").text());
//         console.log(counter);
//         $(".fullnessCount").text(counter);
//     });
// }
function feedtest(){
    $(document).ready(function() {
        $.get("feedjs", function(data) {
            console.log(data);
            $(".fullnessCount").text(data.fullness);
            $("img").attr("src", data.img);
            $("h4").text(data.message);
            $(".mealCount").text(data.meals);
        });
    });
}