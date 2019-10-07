
$(document).ready(function () {    
    $.ajax({
        type: "GET",
        url: "http://localhost:53405/api/User/RetrieveAll",
        dataType: "json",
        success: function (data) { 
            console.log(data);
            $.each(data, function (k, v) {
                $('#userSelect').append(createOption(v.FIRST_NAME + " " + v.LAST_NAME, v.ID));
                console.log(v);
            });
           
        },
        error: function (xhr, status, error) {
            
            alert(error);
        },
        fail: function (jqXHR, tStatus, errorThrown) {
            console.log("no sirve");
            console.log(jqXHR, tStatus, errorThrown);
        }
    });

  
});

function createOption(data, id) {
    var opt = document.createElement('option');
    opt.value = data;
    opt.text = data;
    opt.id = id;
    return opt;
}

function populateTable() {
    var id = this.id;

    /*var userList = $.ajax({
        type: "GET",
        url: "http://localhost:53405/api/User/RetrieveAll"
    });*/
    var projectList = $.ajax({
        type: "GET",
        url: "http://localhost:53405/api/Project/RetrieveAll"
    });
    var userPList = $.ajax({
        type: "GET",
        url: "http://localhost:53405/api/User/RetrieveAll"
    });

    $.when(projectList, userPList).done(function (pl, upl) {
        var uProjects = [];
        allProjs = pl[0];
        allUserProjs = upl[0];
        for (var i = 0; i < allProjs.length; i++) {
            if (upl[0].USER_ID = id) {
                for (var j = 0; j < allUserProjs.length; j++) {
                    if (pl[0].ID == upl[0].PROJECT_ID) {
                        uProjects.append(pl);
                    }
                }
            }
        }
    });
}