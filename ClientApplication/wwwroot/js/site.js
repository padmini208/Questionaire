$(document).ready(function () {

    getReasons();
    $("#NewReasonButton").on("click", function (e) {
        $('#error_reasons').html(' ');
        $(".Message").html(' ');
        if (!$("#updateForm").hide()) { $("#updateForm").hide() }
        $("#newReasonsForm").toggle()
        
    });
    function getReasons() {
        $('#ReasonsBody').html(' ');
        $("#updateForm").hide();
        $('#error_reasons').html(' ');
        $(".Message").html(' ');
        $.ajax({
            url: "http://localhost:5000/api/questionaire",
            method: "GET",
            dataType: "json",
            contentType: 'application/json',
            data: {
                test: 'test data'
            },
            success: function (data) {
                $(data).each(function (i, response) {
                    $('#ReasonsBody').append($("<tr>")
                        .append($("<td >").append(response.firstName))
                        .append($("<td >").append(response.lastName))
                        .append($("<td class=col-20>").append(response.firstReason))
                        .append($("<td class=col-20>").append(response.secondReason))
                        .append($("<td class=col-20>").append(response.thirdReason))
                        .append($("<td>").append(response.email))
                        .append($("<td>").append(`
                                   <i class="far fa-edit updateReason" data-id="`+ response.id + `"></i> 
                                   <i class="fas fa-trash deleteReason" data-id="`+ response.id + `"></i>
                                            `)));
                });
                loadButtons();
            },
            failure: function (response) {

            },
            error: function (xhr, ajaxOptions, thrownError) {

                $('#error_reasons').html("An error occured in processing your request : " + xhr.status );
                $(".Message").html(xhr.responseText);
            }
             
            
        });
    }

    function getReasonById(id) {

        $('#error_reasons').html(' ');
        $(".Message").html(' ');
        $.ajax({
            url: 'http://localhost:5000/api/questionaire/' + id,
            type: 'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            data: {
                test: 'test data'
            },
           success: function (data) {
                $($("#updateForm")[0].ReasonId).val(data.id);
                $($("#updateForm")[0].UpdateFirstName).val(data.firstName);
                $($("#updateForm")[0].UpdateLastName).val(data.lastName);
                $($("#updateForm")[0].UpdateEmail).val(data.email);
                $($("#updateForm")[0].UpdateReasonOne).val(data.firstReason);
                $($("#updateForm")[0].UpdateReasonTwo).val(data.secondReason);
                $($("#updateForm")[0].UpdateReasonThree).val(data.thirdReason);
                $("#updateForm").show();
                $("#newReasonsForm").hide();
            },
           
            failure: function (response) {

            },
            error: function (xhr, ajaxOptions, thrownError) {
                
                $('#error_reasons').html("An error occured in processing your request: "+ xhr.status  );
                $(".Message").html ( xhr.responseText);
                
            }
        });
    }


    function loadButtons() {
        $(".updateReason").click(function (e) {
            getReasonById($($(this)[0]).data("id"));
            e.preventDefault();
        });

        $(".deleteReason").click(function (e) {
            deleteReason($($(this)[0]).data("id"));
            e.preventDefault();
        })
    }
    $("#submitReasons").on("click", function (e) {

        let reason = {
            firstName: $($("#newReasonsForm")[0].FirstName).val(),
            lastName: $($("#newReasonsForm")[0].LastName).val(),
            email: $($("#newReasonsForm")[0].Email).val(),
            firstReason: $($("#newReasonsForm")[0].FirstReason).val(),
            secondReason: $($("#newReasonsForm")[0].SecondReason).val(),
            thirdReason: $($("#newReasonsForm")[0].ThirdReason).val()
        }
        postReason(reason);
        $("#newReasonsForm").trigger("reset");
        $("#newReasonsForm").toggle();
        $("#updateForm").hide();
        e.preventDefault();

    });
    function postReason(reason) {
        $.ajax({
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json'
            },
            url: 'http://localhost:5000/api/questionaire',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(reason),
            success: function (reason) {

                getReasons();
            },
            failure: function (response) {

            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#newReasonsForm").show();
                $('#error_reasons').html("An error occured in processing your request : " + xhr.status  );
                $(".Message").html(xhr.responseText);
            }
        });
    }
    function putReason(id, data) {
        $.ajax({
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json'
            },
            url: 'http://localhost:5000/api/questionaire/' + id,
            method: 'PUT',
            dataType: 'json',
            data: JSON.stringify(data),
            success: function (data) {
                console.log(data);
                getReasons();
            },
            failure: function (response) {

            },
            error: function (xhr, ajaxOptions, thrownError) {
                $('#error_reasons').html("An error occured in processing your request " + xhr.status);
               $(".Message").html(xhr.responseText);
                $("#updateForm").toggle();
            }
        });

    }
    function deleteReason(id) {
        $.ajax({
            url: 'http://localhost:5000/api/questionaire/' + id,
            method: 'DELETE',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                getReasons();
            },
            failure: function (response) {

            },
            error: function (xhr, ajaxOptions, thrownError) {
                $('#error_reasons').html("An error occured in processing your request" + xhr.status);
                $(".Message").html(xhr.responseText);
            }
            })
    }

    $("#UpdateReasonButton").on("click", function (e) {
        $('#error_reasons').html(' ');
        $(".Message").html(' ');
        let data = {
            firstName: $($("#updateForm")[0].UpdateFirstName).val(),
            lastName: $($("#updateForm")[0].UpdateLastName).val(),
            email: $($("#updateForm")[0].UpdateEmail).val(),
            firstReason: $($("#updateForm")[0].UpdateReasonOne).val(),
            secondReason: $($("#updateForm")[0].UpdateReasonTwo).val(),
            thirdReason: $($("#updateForm")[0].UpdateReasonThree).val()
        }

        putReason($($("#updateForm")[0].ReasonId).val(), data);
        $("#updateForm").trigger("reset");
        $("#updateForm").toggle();
        e.preventDefault();

    });
     
    

});