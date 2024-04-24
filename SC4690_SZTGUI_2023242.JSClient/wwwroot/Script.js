let owners = [];
getData();
async function getData() {
    await fetch("http://localhost:25418/owner")
        .then(x => x.json())
        .then(y => {
            owners = y;
            console.log(owners);
            display();
        });

}




function display() {
    document.getElementById('resultarea').innerHTML = "";

    owners.forEach(t => { document.getElementById('resultarea').innerHTML += "<tr><td> " + t.age + "</td><td> " + t.name + "</td><td> " + t.phoneNumber + "</td><td> " + t.ownerID + "</td><td> " + t.salary + "</td><td>" + `<button type="button" onclick="remove(${t.ownerID})">Delete</button>` + "</td></tr>" });
}


function remove(id) {
    fetch("http://localhost:25418/owner/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response).then(data => { console.log("Success", data); getData(); }).catch((error) => { console.error("Error", error); });
}
function create() {
    let age = document.getElementById('ownerage').value;
    let name = document.getElementById('ownername').value;
    let phoneNumber = document.getElementById('ownerphonenumber').value;
    let ownerID = document.getElementById('ownerid').value;
    let salary = document.getElementById('ownersalary').value;

    fetch("http://localhost:25418/owner", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ age: age, name: name, phoneNumber: phoneNumber, ownerID: ownerID, salary: salary }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            } else {
                console.log("Success");
                getData();
            }
        })
        .catch((error) => {
            console.error("Error", error);
        });

}

