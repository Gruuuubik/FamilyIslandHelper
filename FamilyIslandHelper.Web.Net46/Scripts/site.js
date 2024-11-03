$(document).ready(function () {
	var BuildingName1 = document.getElementById("BuildingName1");
	var BuildingName2 = document.getElementById("BuildingName2");
	var BuildingName = document.getElementById("BuildingName");

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

	var ShowListOfComponents = document.getElementById("ShowListOfComponents");
	if (ShowListOfComponents != null) {
		ShowListOfComponents.addEventListener("change", function () {
			document.getElementById('mainForm').submit();
		});
	}
});

var allBuildings = {
	"CarpentryWorkshop": ["Needle", "Stairs", "Crest", "Stool", "Paints", "Pipe", "Tambourine", "Barrel", "WoodenBeam", "LeatherBall", "Incense"],
	"JewelryWorkshop": ["SapphireBracelet", "GemNecklace", "AmethystPendant", "EmeraldRing", "PearlEarrings", "CrystalLotus"],
	"Knocker": ["StoneBlock", "LimestoneBlock", "Beams", "PalmBeams", "Millstone"],
	"Loom": ["Lace", "Wattle", "Rope", "Gloves", "Sackcloth", "Cloth", "Necklace", "PicnicBasket", "WickerBasket", "DreamCatcher", "DyedFabric"],
	"MeteoriteForge": ["IronIngot", "IronPipe", "IronPlate", "Hammer"],
	"Mill": ["GoatFood", "ChickenFood", "Ocher", "Flour", "SunflowerOil", "Syrup", "CowFood"],
	"Mixer": ["Soap", "Butter", "Cheese", "BluePaint", "LemonOil", "WhippedCream"],
	"Pottery": ["Bowl", "Potp", "Jugp", "Amphorap", "Flashlight"],
	"Sawmill": ["Stakes", "UnedgedBoard", "EdgedBoard", "Trough"],
	"ShamanWorkshop": ["RuneStone", "FlowerWreath", "FragrantBouquet"],
	"Smelter": ["Resin", "Coal", "Gold", "Shingles", "BurntBrick", "Nails"],
	"Tannery": ["Leather", "Papyrus", "WhitePaint"],
	"Workshop": ["Scraper", "Axe", "Knife", "Brick"]
};

function setItemName(event) {
	document.getElementById('ItemName').value = event.currentTarget.id;

	document.getElementById('mainForm').submit();

	var itemNameImages = document.getElementsByClassName('itemNameImage');

	for (let i = 0; i < itemNameImages.length; i++) {
		itemNameImages[i].style.border = "none grey";
	}

	event.currentTarget.style.border = "solid grey";
}
