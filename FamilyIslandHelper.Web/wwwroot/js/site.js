var BuildingName1 = document.getElementById("BuildingName1");
var BuildingName2 = document.getElementById("BuildingName2");
var BuildingName = document.getElementById("BuildingName");
var ItemCount = document.getElementById("ItemCount");
var ShowListOfComponents = document.getElementById("ShowListOfComponents");

if (BuildingName1 != null) {
	BuildingName1.addEventListener("change", function () {
		document.getElementById('mainForm').submit();
	});
}

if (BuildingName2 != null) {
	BuildingName2.addEventListener("change", function () {
		document.getElementById('mainForm').submit();
	});
}

if (BuildingName != null) {
	BuildingName.addEventListener("change", function () {
		document.getElementById('mainForm').submit();
	});
}

if (ItemCount != null) {
	ItemCount.addEventListener("change", function () {
		document.getElementById('mainForm').submit();
	});
}

if (ShowListOfComponents != null) {
	ShowListOfComponents.addEventListener("change", function () {
		document.getElementById('mainForm').submit();
	});
}

function setItemName(event) {
	document.getElementById('ItemName').value = event.currentTarget.id;

	document.getElementById('mainForm').submit();

	var itemNameImages = document.getElementsByClassName('itemNameImage');

	for (let i = 0; i < itemNameImages.length; i++) {
		itemNameImages[i].style.border = "none grey";
	}

	event.currentTarget.style.border = "solid grey";
}
