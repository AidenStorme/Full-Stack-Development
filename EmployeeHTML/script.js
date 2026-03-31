const setup = () => {

    $('#btnSender').on('click', () => {
        let email = $('#email').val();
        let password = $('#password').val();
        let account = {
            "email": email,
            "password": password
        };
        login(JSON.stringify(account));
    });
}

const login = (jsonData) => {
    const url = "https://localhost:7217/api/login";
    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: jsonData
    })
    .then(response => {
        if (response.ok) {
            console.log("Login successful");
            console.log(response);
            return response.text();
        } else {
            console.error("Login failed");
            throw new Error("Login failed");
        }
    })
}

window.addEventListener("load", setup);