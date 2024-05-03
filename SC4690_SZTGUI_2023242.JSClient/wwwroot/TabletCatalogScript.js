let tablets = [];
let connection = null;
let tabletIDtoUpdate = -1;

getData();
setUpSignalR();


function setUpSignalR() {
    connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:25418/hub").configureLogging(signalR.LogLevel.Information).build();

    connection.on("TabletCreated", (user, message) => {
        getdata();
    });

    connection.on("TabletDeleted", (user, message) => {
        getdata();
    });

    connection.on("TabletUpdated", (user, message) => {
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
    await fetch("http://localhost:25418/tablet")
        .then(x => x.json())
        .then(y => {
            tablets = y;
            console.log(tablets);
            display();
        });

}




function display() {
    document.getElementById('resultarea').innerHTML = "";

    tablets.forEach(t => { document.getElementById('resultarea').innerHTML += "<tr><td> " + t.tabletName + "</td><td> " + t.tabletID + "</td><td> " + t.ownerID + "</td><td> " + t.price + "</td><td> " + t.size + "</td><td>" + t.colour + "</td><td>" + `<button type="button" onclick="remove(${t.tabletID})">Delete</button> ` + ` <button type="button" onclick="showupdate(${t.tabletID})">Update</button>` + "</td></tr>" });
}


function remove(id) {
    fetch("http://localhost:25418/tablet/" + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    }).then(response => response).then(data => { console.log("Success", data); getData(); }).catch((error) => { console.error("Error", error); });
}

function showupdate(id) {
    document.getElementById('tabletnametoupdate').value = tablets.find(t => t['tabletID'] == id)['tabletName'];
    document.getElementById('tabletidtoupdate').value = tablets.find(t => t['tabletID'] == id)['tabletID'];
    document.getElementById('tabletowneridtoupdate').value = tablets.find(t => t['tabletID'] == id)['ownerID'];
    document.getElementById('tabletpricetoupdate').value = tablets.find(t => t['tabletID'] == id)['price'];
    document.getElementById('tabletsizetoupdate').value = tablets.find(t => t['tabletID'] == id)['size'];
    document.getElementById('tabletcolourtoupdate').value = tablets.find(t => t['tabletID'] == id)['colour'];
    document.getElementById('updateformdiv').style.display = 'flex';
    tabletIDtoUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let tabletName = document.getElementById('tabletnametoupdate').value;
    let tabletID = document.getElementById('tabletidtoupdate').value;
    let ownerID = document.getElementById('tabletowneridtoupdate').value;
    let price = document.getElementById('tabletpricetoupdate').value;
    let size = document.getElementById('tabletsizetoupdate').value;
    let colour = document.getElementById('tabletcolourtoupdate').value;


    fetch("http://localhost:25418/tablet", {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ tabletName: tabletName, tabletID: tabletID, ownerID: ownerID, price: price, size: size, colour: colour }),
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
    let tabletName = document.getElementById('tabletname').value;
    let tabletID = document.getElementById('tabletid').value;
    let ownerID = document.getElementById('tabletownerid').value;
    let price = document.getElementById('tabletprice').value;
    let size = document.getElementById('tabletsize').value;
    let colour = document.getElementById('tabletcolour').value;


    fetch("http://localhost:25418/tablet", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ tabletName: tabletName, tabletID: tabletID, ownerID: ownerID, price: price, size: size, colour: colour }),
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