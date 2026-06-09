document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("reviewForm");
    if (!form) return;

    const nameInput = document.getElementById("Name");
    const emailInput = document.getElementById("Email");
    const textInput = document.getElementById("Text");

    form.addEventListener("submit", function (e) {
        let isValid = true;

        if (nameInput.value.trim() === "") {
            showError(nameInput, "Имя обязательно для заполнения");
            isValid = false;
        } else {
            hideError(nameInput);
        }

        if (!validateEmail(emailInput.value)) {
            showError(emailInput, "Введите корректный Email-адрес");
            isValid = false;
        } else {
            hideError(emailInput);
        }

        if (textInput.value.trim() === "") {
            showError(textInput, "Поле отзыва не может быть пустым");
            isValid = false;
        } else {
            hideError(textInput);
        }

        if (!isValid) {
            e.preventDefault();
        }
    });

    function validateEmail(email) {
        const re = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        return re.test(String(email).toLowerCase());
    }

    function showError(input, message) {
        const group = input.parentElement;
        const errorDiv = group.querySelector(".error-msg");
        errorDiv.innerText = message;
        errorDiv.style.display = "block";
        input.style.borderColor = "var(--error-color)";
    }

    function hideError(input) {
        const group = input.parentElement;
        const errorDiv = group.querySelector(".error-msg");
        errorDiv.style.display = "none";
        input.style.borderColor = "var(--border-color)";
    }
});