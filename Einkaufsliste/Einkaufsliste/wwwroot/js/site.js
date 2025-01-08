// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    var buttons = document.querySelectorAll('button');
    var currentIndex = 0;

    
    buttons[currentIndex].focus();

    document.addEventListener('keydown', function (event) {
        if (event.key === 'ArrowRight') {
            currentIndex = (currentIndex + 1) % buttons.length;
            buttons[currentIndex].focus();
        } else if (event.key === 'ArrowLeft') {
            currentIndex = (currentIndex - 1 + buttons.length) % buttons.length;
            buttons[currentIndex].focus();
        }
    });
});
