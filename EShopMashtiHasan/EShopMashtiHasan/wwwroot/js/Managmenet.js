
$(document).on("click", "[data-showAddModel='showAddModel']", function () {
    
    const url = $(this).attr("data-action");
    const container = $(this).attr("data-container");
    const modal = $(this).attr("data-modal-id");
    $.get(url, null, function (rd) {
        $("#" + container).html(rd);
        $("#" + modal).modal("show");
    })

});
$(document).on("click", "#btnAddNew", function () {
    var action = $(this).attr("data-action");
    var method = $(this).attr("data-method");
    var formid = "#" + $(this).attr("data-form");

    var actionBind = $(this).attr("data-action-BindGrid");
    var actionRefresh = $(this).attr("data-action-RefreshGrid");
    if (method === "post") {
        var sendingData = $(formid).serialize();

        $.post(action, sendingData, function (op) {
            if (op.success.toString() == "true") {
                $("#myModal").modal("hide");
                ShowSuccessMessage(op.message);
                BindGrid(actionBind);
                RefreshsearchBox(actionRefresh);
            }
            else {
                $("#myModal").modal("hide");
                ShowFailMessage(op.message)

            }
        });
    }
});

function BindGrid(url) {
    
    var SendingData = $("#frmSearch").serialize();
    $.get(url, SendingData, function (grd) {
        $("#dvGrid").html(grd);
    });
}


function RefreshsearchBox(url) {
    var SendingData = $("#frmSearch").serialize();
    $.get(url, SendingData, function (frmSearch) {
        $("#dvSearch").html(frmSearch);
    });
}

function ShowSuccessMessage(msg) {
    Swal.fire({
        icon: 'success',
        title: 'وضعیت ثبت',
        text: msg,
    });
}

function ShowFailMessage(msg) {
    Swal.fire({
        icon: 'error',
        title: 'وضعیت ثبت',
        text: msg,
    });
}



$(document).on("click", "[data-Delete='Delete']", function () {
    var actionBind = $(this).attr("data-action-BindGrid");
    var actionRefresh = $(this).attr("data-action-RefreshGrid");
    if (confirm("آیا مطمنید")) {
        var id = $(this).attr("data-id");
        var sendingData = "id=" + id;
        var sendingUrl = $(this).attr("data-action");
        $.post(sendingUrl, sendingData, function (op) {
            if (op.success.toString() == "true") {
                var rowID = "#tr_" + id;
                $(rowID).slideUp(500);
                BindGrid(actionBind);
                RefreshsearchBox(actionRefresh);
            }
            else {
                ErrorMessage(op.message);
            }
        });
    }

});

//$(document).on("click", "[data-Delete='Delete']", function () {
//    var actionBind = $(this).attr("data-action-BindGrid");
//    var actionRefresh = $(this).attr("data-action-RefreshGrid");
//    var id = $(this).attr("data-id");
//    var sendingData = "id=" + id;
//    var sendingUrl = $(this).attr("data-action");
    
//    $("#MyModalDelete").modal("show");
//    var ok = false;


//    if ($("#btnCancelDelete").click(function () {
//        id = 0;
//        BindGrid(actionBind);
//        RefreshsearchBox(actionRefresh);
//        $("#MyModalDelete").modal('hide');
//    }));
//    if ($("#btn-Delete").click(function () {
       
//        $.post(sendingUrl, sendingData, function (op) {
//            if (op.success.toString() == "true") {
//                $("#MyModalDelete").modal("hide");
//                var rowID = "#tr_" + id;
//                $(rowID).slideUp(500);
//                BindGrid(actionBind);
//                RefreshsearchBox(actionRefresh);
//            }
//            else {
//                ErrorMessage(op.message);
//            }
//        });


//    }));



//});





$(document).on("click", "[data-showEditModel='showEditModel']", function () {
    var id = $(this).attr("data-id");
    var sendingData = "id=" + id;
    var sendingUrl = $(this).attr("data-action");
    $.get(sendingUrl, sendingData, function (rd) {
        $("#dvAddEditModel").html(rd);
        $("#myModal").modal("show");
    });
});


$(document).on("click", "#btnEdit", function () {
    var action = $(this).attr("data-action");
    var formid = "#" + $(this).attr("data-form");

    var actionBind = $(this).attr("data-action-BindGrid");
    var actionRefresh = $(this).attr("data-action-RefreshGrid");
    var sendingData = $(formid).serialize();
   
        $.post(action, sendingData, function (rd) {
            if (rd.success === true)  {
                $("#myModal").modal("hide");
                ShowSuccessMessage(rd.message);
                BindGrid(actionBind);
                RefreshsearchBox(actionRefresh);
            }
            else {
                ShowFailMessage(rd.message)

            }
        });
    
});


$(document).on("click", "#btnChangePassword", function () {
    var action = $(this).attr("data-action");
    var formid = "#" + $(this).attr("data-form");
    var sendingData = $(formid).serialize();
    $.post(action, sendingData, function (rd) {
        if (rd.success === true) {
            $("#myModal").modal("hide");
            ShowSuccessMessage(rd.message);
        }
        else {
            ShowFailMessage(rd.message)

        }
    });
});



$(document).on("keyup", "[data-search='search']", function () {
    var action = $(this).attr("data-action");

    BindGrid(action);
});
$(document).on("change", "[data-search='search']", function () {
    var action = $(this).attr("data-action");
    BindGrid(action);
});



$(document).on("click", "#btnCancelEdit", function () {
    $("#myModal").modal('hide');
});
