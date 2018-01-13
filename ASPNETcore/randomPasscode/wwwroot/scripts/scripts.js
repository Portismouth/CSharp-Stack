function generate(){
    $(document).ready(function () {
        $.get("generate", function(data){
            console.log(data);
            $(".passcode").text(data);
            console.log(data);
        });
        var counter = parseInt($(".count").text());
        $(".count").text(counter+1);
    });
}