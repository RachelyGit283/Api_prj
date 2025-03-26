

    //login = async () => {
    //    const username = document.querySelector("#name").value;
    //    const password = document.querySelector("#password").value;
    //    if (!username || !password) {
    //        alert("username and password are required");
    //    }
    //    const loginrequest = {
    //        username: username,
    //        password: password
    //    }
    //    try {
    //        const response = await fetch("api/users/login", {
    //            method: "POST",
    //            headers: {
    //                "content-type": "application/json",
    //                "body": JSON.stringify(loginrequest)
    //            }
    //        })
    //        if (!response.ok)
    //            throw new Error("Error recieving data to server")
    //        alert("user add")
    //    }
    //    catch (error) {
    //        alert(error)
    //    }
    //}
    //addUserToServer = async () => {
    //    const nameUser = document.querySelector("#nameUser").value
    //    const password = document.querySelector("#password").value
    //        const firstname = document.querySelector("#firstName").value;
    //    const lastname = document.querySelector("#lastName").value;

    //    const User = { nameUser, password, lastName, firstName }
    //    try {
    //        console.log(User)
    //        const response = await fetch("https://localhost:7280/api/Users", {
    //            method: 'POST',
    //            body: JSON.stringify(User),
    //            headers:
    //            {
    //                'Content-Type': "application/json"
    //            }
    //        }
    //        )
    //        if (!response.ok)
    //            throw new Error("Error recieving data to server")
    //        alert("user add")
    //    }

    //    catch (error) {
    //        alert(error)
    //    }
    //}
newUser = () => {
    const div = document.querySelector("#newUser")
    div.setAttribute("style", "visibility:visible")
}
logIn = async () => {
    const login_username = document.querySelector("#login_username").value;
    const login_password = document.querySelector("#login_password").value;
    const newUser = { username: login_username, password: login_password, firstname: "", lastname: "" }
    let flag = false;
    try {
        const response = await fetch("https://localhost:7280/api/Users/login", {
            method: "POST",
            body: JSON.stringify(newUser),
            headers: { "Content-Type": "application/json" }
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.status} - ${response.statusText}`);
        }
        const user = await response.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        return window.location.href = "https://localhost:7280/site.html"
    } catch (error) {
        alert(error.message);
    }
}
//register = async () => {
//    const username = document.querySelector("#rname").value;
//    const password = document.querySelector("#rpassword").value;
//    const firstname = document.querySelector("#firstname").value;
//    const lastname = document.querySelector("#lastname").value;

//    if (!username || !password) {
//        alert("username and password are required");
//    }

//    const registerrequest =
//    {
//        username: username,
//        password: password,
//        firstname: firstname,
//        lastname: lastname
//    }
//    try {
//        const response = await fetch("api/users/register", {
//            method: "POST",
//            headers: {
//                "content-type": "application/json",
//                "body": JSON.stringify(registerrequest)
//            }
//        })
//        if (!response.ok)
//            throw new Error("Error recieving data to server")
//        alert("user add")
//    }
//    catch (error) {
//        alert("Error: " + error.message);
//    }
//}
//showRegister = () => {
//const div = document.querySelector("#register");
//div.setAttribute("style", "visibility:visible");
//}
const signUp = async () => {
    const username = document.querySelector("#username").value;
    const lastname = document.querySelector("#lastname").value;
    const firstname = document.querySelector("#firstname").value;
    const password = document.querySelector("#password").value;

    const user = { username, lastname, firstname, password };

    try {
        const response = await fetch("https://localhost:7280/api/Users", {
            method: "POST",
            body: JSON.stringify(user),
            headers: { "Content-Type": "application/json" }
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.status} - ${response.statusText}`);
        }

        alert("User added");
    } catch (error) {
        alert(error.message);
    }
};
const update = async () => {
    const update_username = document.querySelector("#update_username").value;
    const update_lastname = document.querySelector("#update_lastname").value;
    const update_firstname = document.querySelector("#update_firstname").value;
    const update_password = document.querySelector("#update_password").value;

    const userId = JSON.parse(sessionStorage.getItem("user"));

    const user = {
        userId: userId.userId,
        username: update_username,
        lastname: update_lastname,
        firstname: update_firstname,
        password: update_password
    };
    try {
        console.log(user)
        const response = await fetch(`https://localhost:7280/api/Users/${user.userId}`, {
            method: "PUT",
            body: JSON.stringify(user),
            headers: { "Content-Type": "application/json" }
        });
        if (!response.ok) {
            throw new Error(`Error: ${response.status} -- ${response.statusText}`);
        }

        alert("User updated");
    } catch (error) {
        alert(error.message);
    }
};

