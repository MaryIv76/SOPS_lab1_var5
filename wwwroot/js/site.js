document.addEventListener("DOMContentLoaded", function () {

    document.querySelectorAll('input').forEach(function (e) {

        if (e.value === '') e.value = window.sessionStorage.getItem(e.name, e.value);

        e.addEventListener('input', function () {
            window.sessionStorage.setItem(e.name, e.value);
        })
    })
});

function SaveSelectValue(el) {
    window.sessionStorage.setItem(el.name, el.value);
}
function LoadSelectValue(el) {
    return window.sessionStorage.getItem(el.name);
}

let selectCheck = document.querySelector("[name='position']");
selectCheck.value = LoadSelectValue(selectCheck);
if (selectCheck.value === "") {
    selectCheck.value = "no";
}