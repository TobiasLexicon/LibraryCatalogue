// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getBook() {
    $.get("/Book/GetBooks", function (response) {
        
        document.getElementById("BooksList").innerHTML = response;
    })
}

function getBookJSON() {
    $.get("/Book/GetBooksJSON", function (response) {
        console.log(response);
        document.getElementById("BooksListJSON").innerHTML = response[0].Author;
    })
}