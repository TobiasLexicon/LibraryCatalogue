// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $.get("/Book/GetPublishers", function (response) {
        console.log(response);
        $('#publishersList').empty();
        response.map(publisher =>
            $('#publishersList').append($('<option/>', {
                value: publisher,
                text: publisher

            })));
    });
});


function getBook(url) {
    $.get(url, function (response) {
        
        document.getElementById("BooksList").innerHTML = response;
    })
}

function getBookJSON(url) {
    $.get(url, function (response) {
        console.log(response);
        document.getElementById("BooksList").innerHTML = response[0].author;
    })
}

function findThroughPost(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
};
    $.post(url, data, function (response) {
        document.getElementById("BooksList").innerHTML = response;
    })

};