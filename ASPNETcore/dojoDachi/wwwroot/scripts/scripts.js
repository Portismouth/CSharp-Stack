function feed() {
  $(document).ready(function() {
    $.get("feedJS", function(dojodachi) {
      console.log(dojodachi);
      $(".fullnessCount").text(dojodachi.fullness);
      $(".mealCount").text(dojodachi.meals);
      $(".console h4").text(dojodachi.message);
      $(".console img").attr("src", dojodachi.image);
    });
  });
}
function play() {
  $(document).ready(function() {
    $.get("playJS", function(dojodachi) {
      console.log(dojodachi);
      $(".happinessCount").text(dojodachi.happiness);
      $(".energyCount").text(dojodachi.energy);
      $(".console h4").text(dojodachi.message);
      $(".console img").attr("src", dojodachi.image);
    });
  });
}
function work() {
  $(document).ready(function() {
    $.get("workJS", function(dojodachi) {
      console.log(dojodachi);
      $(".energyCount").text(dojodachi.energy);
      $(".mealCount").text(dojodachi.meals);
      $(".console h4").text(dojodachi.message);
      $(".console img").attr("src", dojodachi.image);
    });
  });
}
function sleep() {
  $(document).ready(function() {
    $.get("sleepJS", function(dojodachi) {
      console.log(dojodachi);
      $(".energyCount").text(dojodachi.energy);
      $(".fullnessCount").text(dojodachi.fullness);
      $(".happinessCount").text(dojodachi.happiness);
      $(".console h4").text(dojodachi.message);
      $(".console img").attr("src", dojodachi.image);
    });
  });
}
