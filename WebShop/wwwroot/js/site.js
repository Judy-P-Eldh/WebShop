﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function chooseAmount() {
    let amount = document.getElementById('plantAmount').innerHTML;
    let choose = document.getElementById('plantAmountRange').innerHTML;
}

function updateTextInput(val) {
    document.getElementById('textInput').value = val;
}
