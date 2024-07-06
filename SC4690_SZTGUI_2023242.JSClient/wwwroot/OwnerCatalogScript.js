let owners = [];
let connection = null;
let ownerIDtoUpdate = -1;

getData();
setUpSignalR();

// domeszter

function setUpSignalR() {
  connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:25418/hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

  connection.on("OwnerCreated", (user, message) => {
    getdata();
  });

  connection.on("OwnerDeleted", (user, message) => {
    getdata();
  });

  connection.on("OwnerUpdated", (user, message) => {
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
}

async function getData() {
  await fetch("http://localhost:25418/owner/")
    .then((x) => x.json())
    .then((y) => {
      owners = y;
      console.log(owners);
      display();
    });
}

function display() {
  document.getElementById("resultarea").innerHTML = "";

  owners.forEach((t) => {
    document.getElementById("resultarea").innerHTML +=
      "<tr><td> " +
      t.age +
      "</td><td> " +
      t.name +
      "</td><td> " +
      t.phoneNumber +
      "</td><td> " +
      t.ownerID +
      "</td><td> " +
      t.salary +
      "</td><td>" +
      `<button type="button" onclick="remove(${t.ownerID})">Delete</button> ` +
      ` <button type="button" onclick="showupdate(${t.ownerID})">Update</button>` +
      "</td></tr>";
  });
}

function remove(id) {
  fetch("http://localhost:25418/owner/" + id, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
    body: null,
  })
    .then((response) => response)
    .then((data) => {
      console.log("Success", data);
      getData();
    })
    .catch((error) => {
      console.error("Error", error);
    });
}

function showupdate(id) {
  document.getElementById("owneragetoupdate").value = owners.find(
    (t) => t["ownerID"] == id
  )["age"];
  document.getElementById("ownernametoupdate").value = owners.find(
    (t) => t["ownerID"] == id
  )["name"];
  document.getElementById("ownerphonenumbertoupdate").value = owners.find(
    (t) => t["ownerID"] == id
  )["phoneNumber"];
  document.getElementById("owneridtoupdate").value = owners.find(
    (t) => t["ownerID"] == id
  )["ownerID"];
  document.getElementById("ownersalarytoupdate").value = owners.find(
    (t) => t["ownerID"] == id
  )["salary"];
  document.getElementById("updateformdiv").style.display = "flex";
  ownerIDtoUpdate = id;
}

function update() {
  document.getElementById("updateformdiv").style.display = "none";
  let age = document.getElementById("owneragetoupdate").value;
  let name = document.getElementById("ownernametoupdate").value;
  let phoneNumber = document.getElementById("ownerphonenumbertoupdate").value;
  let ownerID = document.getElementById("owneridtoupdate").value;
  let salary = document.getElementById("ownersalarytoupdate").value;

  fetch("http://localhost:25418/owner", {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      age: age,
      name: name,
      phoneNumber: phoneNumber,
      ownerID: ownerID,
      salary: salary,
      ownerID: ownerIDtoUpdate,
    }),
  })
    .then((response) => {
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
  let age = document.getElementById("ownerage").value;
  let name = document.getElementById("ownername").value;
  let phoneNumber = document.getElementById("ownerphonenumber").value;
  let ownerID = document.getElementById("ownerid").value;
  let salary = document.getElementById("ownersalary").value;

  fetch("http://localhost:25418/owner", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      age: age,
      name: name,
      phoneNumber: phoneNumber,
      ownerID: ownerID,
      salary: salary,
    }),
  })
    .then((response) => {
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
