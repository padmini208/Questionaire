$(document).ready(function () {

    GetReasons();

    $("#newReasonsBtn").on("click", function (e) {
        $("#NewReasonsEntryForm").toggle();
    });

    function GetReasons() {
        $('#AllReasonsBody').html('');
        $.ajax({
            url: 'http://localhost:5000/api/Questionaire',
            method: 'get',
            dataType: 'json',
            data: {
                test: 'test data'
            },
            success: function (data) {
                $(data).each(function (i, ReasonToBeHired) {
                    $('#tutorialsBody').append($("<tr>")
                        .append($("<td>").append(ReasonToBeHired.FirstName))
                        .append($("<td>").append(ReasonToBeHired.LastName))
                        .append($("<td>").append(ReasonToBeHired.Email))
                        .append($("<td>").append(ReasonToBeHired.FirstReason))
                        .append($("<td>").append(ReasonToBeHired.SecondReason))
                        .append($("<td>").append(ReasonToBeHired.ThirdReason))
                        .append($("<td>").append(`
                                                <i class="far fa-edit editTut" data-tutid="`+ tutorial._id + `"></i> 
                                                <i class="fas fa-trash deleteTut" data-tutid="`+ tutorial._id + `"></i>
                                            `)));
                });
                loadButtons();
            }

        });
    }

    function ShoeEditDeleteButtons() {
        $(".editTut").click(function (e) {
            getOneTutorial($($(this)[0]).data("tutid"));
            e.preventDefault();
        });

        $(".deleteTut").click(function (e) {
            deleteTutorial($($(this)[0]).data("tutid"));
            e.preventDefault();
        })
    }
}