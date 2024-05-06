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

