"use strict"

function btnStateChanger(checkbox) {
    const submitBtn = document.getElementById("submitBtn");

    if (checkbox.checked) submitBtn.disabled = false;
    else submitBtn.disabled = true;
}