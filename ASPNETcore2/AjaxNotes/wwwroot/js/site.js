// Write your Javascript code.
$(document).ready(function () {
    var text = $('.updateDesc').hide();
    $(".description").click(function () {
        $(this).hide();
        $(this, ".updateDesc").siblings().show();
    })

    $(".create").click(function () {
        var data ={
            name: $("#noteName").val(),
            desc: $("#noteDesc").val()
        }; 
        $.post("create", data, function(data) {
            console.log(data);
            if(data.success == false){
                $(".error").show().text(data.error);
            }
            else{
                var html = '<div class="indy-note" action="update" method="post">';
                html += "<h3>"+data[0].note+"</h3>";
                html += "<a href=delete/" + data[0].id + ">Delete</a><br>";
                html += '<input type="hidden" value="' + data[0].id + '" name="id">';
                html += '<p class="description">' + data[0].description + '</p>';
                html += '<textarea class="updateDesc" rows="5" cols="15" name="desc" placeholder="' + data[0].description + '"></textarea><br>';
                html += '<input type="submit" class="btn btn-primary" value="Update"></div>';
                $(this, ".updateDesc").hide();
                $(".notes .indy-note:last-child").append(html);
            }
        });
    })
});
