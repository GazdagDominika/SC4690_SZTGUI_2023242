let phones = [];
let connection = null;
let phoneIDtoUpdate = -1;

getData();
setUpSignalR();


function setUpSignalR() {
    connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:25418/hub").configureLogging(signalR.LogLevel.Information).build();

    connection.on("PhoneCreated", (user, message) => {
        getdata();
    });

    connection.on("PhoneDeleted", (user, message) => {
        getdata();
    });

    connection.on("PhoneUpdated", (user, message) => {
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
    await fetch("http://localhost:25418/smartphone")
        .then(x => x.json())
        .then(y => {
            phones = y;
            console.log(phones);
            display();
        });

}




function display() {
    document.getElementById('resultarea').innerHTML = "";

    phones.forEach(t => { document.getElementById('resultarea').innerHTML += "<tr><td> " + t.phoneName + "</td><td> " + t.phoneID + "</td><td> " + t.ownerID + "</td><td> " + t.price + "</td><td> " + t.size + "</td><td>" + t.colour + "</td><td>" + `<button type="button" onclick="remove(${t.phoneID})">Delete</button> ` + ` <button type="button" onclick="showupdate(${t.phoneID})">Update</button>` + "</td></tr>" });
}


function remove(id) {
    fetch("http://localhost:25418/smartphone/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response).then(data => { console.log("Success", data); getData(); }).catch((error) => { console.error("Error", error); });
}

function showupdate(id) {
    document.getElementById('phonenametoupdate').value = phones.find(t => t['phoneID'] == id)['phoneName'];
    document.getElementById('phoneidtoupdate').value = phones.find(t => t['phoneID'] == id)['phoneID'];
    document.getElementById('phoneowneridtoupdate').value = phones.find(t => t['phoneID'] == id)['ownerID'];
    document.getElementById('phonepricetoupdate').value = phones.find(t => t['phoneID'] == id)['price'];
    document.getElementById('phonesizetoupdate').value = phones.find(t => t['phoneID'] == id)['size'];
    document.getElementById('phonecolourtoupdate').value = phones.find(t => t['phoneID'] == id)['colour'];
    document.getElementById('updateformdiv').style.display = 'flex';
    phoneIDtoUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let phoneName = document.getElementById('phonenametoupdate').value;
    let phoneID = document.getElementById('phoneidtoupdate').value;
    let ownerID = document.getElementById('phoneowneridtoupdate').value;
    let price = document.getElementById('phonepricetoupdate').value;
    let size = document.getElementById('phonesizetoupdate').value;
    let colour = document.getElementById('phonecolourtoupdate').value;


    fetch("http://localhost:25418/smartphone", {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ phoneName: phoneName, phoneID: phoneID, ownerID: ownerID, price: price, size: size, colour: colour }),
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
    let phoneName = document.getElementById('phonename').value;
    let phoneID = document.getElementById('phoneid').value;
    let ownerID = document.getElementById('phoneownerid').value;
    let price = document.getElementById('phoneprice').value;
    let size = document.getElementById('phonesize').value;
    let colour = document.getElementById('phonecolour').value;


    fetch("http://localhost:25418/smartphone", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ phoneName: phoneName, phoneID: phoneID, ownerID: ownerID, price: price, size: size, colour: colour }),
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