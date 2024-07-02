let laptops = [];
let connection = null;
let laptopIDtoUpdate = -1;

getData();
setUpSignalR();


function setUpSignalR() {
    connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:25418/hub").configureLogging(signalR.LogLevel.Information).build();

    connection.on("LaptopCreated", (user, message) => {
        getdata();
    });

    connection.on("LaptopDeleted", (user, message) => {
        getdata();
    });

    connection.on("LaptopUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData() {
    await fetch("http://localhost:25418/laptop/hub")
        .then(x => x.json())
        .then(y => {
            laptops = y;
            console.log(laptops);
            display();
        });

}




function display() {
    document.getElementById('resultarea').innerHTML = "";

    laptops.forEach(t => { document.getElementById('resultarea').innerHTML += "<tr><td> " + t.laptopName + "</td><td> " + t.laptopID + "</td><td> " + t.ownerID + "</td><td> " + t.price + "</td><td> " + t.displaySize + "</td><td>" + t.colour + "</td><td>" + `<button type="button" onclick="remove(${t.laptopID})">Delete</button> ` + ` <button type="button" onclick="showupdate(${t.laptopID})">Update</button>` + "</td></tr>" });
}


function remove(id) {
    fetch("http://localhost:25418/laptop/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response).then(data => { console.log("Success", data); getData(); }).catch((error) => { console.error("Error", error); });
}

function showupdate(id) {
    document.getElementById('laptopnametoupdate').value = laptops.find(t => t['laptopID'] == id)['laptopName'];
    document.getElementById('laptopidtoupdate').value = laptops.find(t => t['laptopID'] == id)['laptopID'];
    document.getElementById('laptopowneridtoupdate').value = laptops.find(t => t['laptopID'] == id)['ownerID'];
    document.getElementById('laptoppricetoupdate').value = laptops.find(t => t['laptopID'] == id)['price'];
    document.getElementById('laptopdisplaysizetoupdate').value = laptops.find(t => t['laptopID'] == id)['displaySize'];
    document.getElementById('laptopcolourtoupdate').value = laptops.find(t => t['laptopID'] == id)['colour'];
    document.getElementById('updateformdiv').style.display = 'flex';
    laptopIDtoUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let laptopName = document.getElementById('laptopnametoupdate').value;
    let laptopID = document.getElementById('laptopidtoupdate').value;
    let ownerID = document.getElementById('laptopowneridtoupdate').value;
    let price = document.getElementById('laptoppricetoupdate').value;
    let displaySize = document.getElementById('laptopdisplaysizetoupdate').value;
    let colour = document.getElementById('laptopcolourtoupdate').value;


    fetch("http://localhost:25418/laptop", {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ laptopName: laptopName, laptopID: laptopID, ownerID: ownerID, price: price, displaySize: displaySize, colour: colour }),
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
function create() {
    let laptopName = document.getElementById('laptopname').value;
    let laptopID = document.getElementById('laptopid').value;
    let ownerID = document.getElementById('laptopownerid').value;
    let price = document.getElementById('laptopprice').value;
    let displaySize = document.getElementById('laptopdisplaysize').value;
    let colour = document.getElementById('laptopcolour').value;


    fetch("http://localhost:25418/laptop", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ laptopName: laptopName, laptopID: laptopID, ownerID: ownerID, price: price, displaySize: displaySize, colour: colour }),
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