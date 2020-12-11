$(document).ready(function () {
    //刷新页面时，初始化页面到点击后的状态，而不是页面初始状态
    var hid = $("#HidOrderBy").val();
    var allObj = $(".listTh span");
    var css, field, obj;
    if (hid != '' && hid !== undefined) {
        var last = hid.slice(hid.length - 5);
        if (last == " DESC") {
            css = "down";
            field = hid.slice(0, hid.length - 5);
        }
        else {
            css = "up";
            field = hid;
        }
        for (var i = 0; i < allObj.length; i++) {
            if (allObj.eq(i).attr("orderby") == field) {
                obj = allObj.eq(i);
                obj.addClass(css);
                break;
            }
        }
    }

    $(".listTh").bind({
        mouseover: function () {
        },
        mouseout: function () {
        },
        click: function () {
            var obj = $(this).find("span");
            var name = obj.attr("orderBy");
            $(this).siblings().find("span").removeClass("up down");
            if (obj.hasClass("down")) {
                obj.removeClass("down");
                obj.addClass("up");
                $("#HidOrderBy").val(name);
                $("#BtnRpt").click();
            }
            else {
                obj.removeClass("up");
                obj.addClass("down");
                $("#HidOrderBy").val(name + " DESC");
                $("#BtnRpt").click();
            }
        }
    });
});
