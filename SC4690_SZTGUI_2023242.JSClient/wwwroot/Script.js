let phonesumprice = [];
let laptopcount = [];
let rosegoldtablet = [];
let hugephone = [];
let appleuser = [];
let alldeviceprice = [];
let youngritchowners = [];
let goldsmartphones = [];
let tabletsizes = [];

async function getPhoneSumPrice() {
    let userId1 = document.getElementById('userId1').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/phonesumprice/${userId1}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            phonesumprice = y;
            showPhoneSumPrice();
        });
}

function showPhoneSumPrice() {
    document.getElementById('phonesumprice').style.display = "flex";
    document.getElementById('phonesumprice').innerHTML = `<label>Sum price of Phones: ${phonesumprice}</label>`; // Display the laptopcount value
}

async function getLaptopCount() {
    let userId2 = document.getElementById('userId2').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/laptopcount/${userId2}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            laptopcount = y;
            showLaptopCount();
        });
}

function showLaptopCount() {
    document.getElementById('laptopcount').style.display = "flex";
    document.getElementById('laptopcount').innerHTML = `<label>Count of Laptops: ${laptopcount}</label>`; // Display the laptopcount value
}

async function getRosegoldTablet() {
    let userId3 = document.getElementById('userId3').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/rosegoldtablet/${userId3}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            rosegoldtablet = y;
            showRosegoldTablet();
        });
}

function showRosegoldTablet() {
    document.getElementById('rosegoldtablet').style.display = "flex";
    document.getElementById('rosegoldtablet').innerHTML = `<label>Has Rosegold Tablet: ${rosegoldtablet}</label>`; // Display the laptopcount value
}

async function getHugePhone() {
    let userId4 = document.getElementById('userId4').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/hugephone/${userId4}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            hugephone = y;
            showHugePhone();
        });
}

function showHugePhone() {
    document.getElementById('hugephone').style.display = "flex";
    document.getElementById('hugephone').innerHTML = `<label>Has Huge Phone: ${hugephone}</label>`; // Display the laptopcount value
}

async function getAppleUser() {
    let userId5 = document.getElementById('userId5').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/appleuser/${userId5}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            appleuser = y;
            showAppleUser();
        });
}

function showAppleUser() {
    document.getElementById('appleuser').style.display = "flex";
    document.getElementById('appleuser').innerHTML = `<label>Has Apple device: ${appleuser}</label>`; // Display the laptopcount value
}

async function getAllDevicePrice() {
    let userId6 = document.getElementById('userId6').value; // Get the user ID from the input field

    await fetch(`http://localhost:25418/devicestat/alldeviceprice/${userId6}`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            alldeviceprice = y;
            showAllDevicePrice();
        });
}

function showAllDevicePrice() {
    document.getElementById('alldeviceprice').style.display = "flex";
    document.getElementById('alldeviceprice').innerHTML = `<label>All Device Price: ${alldeviceprice}</label>`; // Display the laptopcount value
}

async function getYoungRitchOwners() {

    await fetch(`http://localhost:25418/devicestat/youngritchowners`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            youngritchowners = y;
            showYoungRitchOwners();
        });
}

function showYoungRitchOwners() {
    document.getElementById('youngritchowners').style.display = "flex";
    let html = '';
    youngritchowners.forEach(t => {
        html += `<tr><td>${t.age}</td><td>${t.name}</td><td>${t.phoneNumber}</td><td>${t.ownerID}</td><td>${t.salary}</td></tr>`;
        t.laptops.forEach(laptop => {
            html += `<tr><td colspan="5">Laptop: ${laptop.laptopName}, ID: ${laptop.laptopID}, Price: ${laptop.price}, Display Size: ${laptop.displaySize}, Colour: ${laptop.colour}</td></tr>`;
        });
        t.tablets.forEach(tablet => {
            html += `<tr><td colspan="5">Tablet: ${tablet.tabletName}, ID: ${tablet.tabletID}, Price: ${tablet.price}, Size: ${tablet.size}, Colour: ${tablet.colour}</td></tr>`;
        });
        t.smartPhones.forEach(phone => {
            html += `<tr><td colspan="5">Phone: ${phone.phoneName}, ID: ${phone.phoneID}, Price: ${phone.price}, Size: ${phone.size}, Colour: ${phone.colour}</td></tr>`;
        });
    });
    document.getElementById('resultarea').innerHTML = html;
}



async function getGoldSmartPhones() {

    await fetch(`http://localhost:25418/devicestat/goldsmartphones`) // Use backticks here
        .then(x => x.json())
        .then(y => {
            goldsmartphones = y;
            showGoldSmartPhones();
        });
}

function showGoldSmartPhones() {
    document.getElementById('goldsmartphones').style.display = "flex";
    let html = '';
    goldsmartphones.forEach(t => {
        html += `<tr><td>${t.phoneName}</td><td>${t.price}</td><td>${t.colour}</td></tr>`;
    });
    document.getElementById('resultarea').innerHTML = html;
}

async function getTabletSizes() {
    await fetch(`http://localhost:25418/devicestat/tabletssize`)
        .then(x => x.json())
        .then(y => {
            tabletsizes = y;
            showTabletSizes();
        });
}


function showTabletSizes() {
    document.getElementById('sizes').style.display = "flex";
    let html = '';
    tabletsizes.forEach(t => {
        html += `<tr><td>${t.size}</td><td>${t.avGprice}</td><td>${t.count}</td></tr>`;
    });
    document.getElementById('resultarea').innerHTML = html;
}
