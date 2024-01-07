var BuildingName1 = document.getElementById("BuildingName1");
var BuildingName2 = document.getElementById("BuildingName2");
var BuildingName = document.getElementById("BuildingName");

if (BuildingName1 != null) {
	BuildingName1.addEventListener("change", function () {
		updateItems("BuildingName1", "ItemName1");
	});
}

if (BuildingName2 != null) {
	BuildingName2.addEventListener("change", function () {
		updateItems("BuildingName2", "ItemName2");
	});
}

if (BuildingName != null) {
	BuildingName.addEventListener("change", function () {
		updateItems("BuildingName", "ItemName");
	});
}

var allBuildings = {
	"CarpentryWorkshop": ["Needle", "Stairs", "Crest", "Stool", "Paints", "Pipe", "Tambourine", "Barrel", "WoodenBeam", "LeatherBall", "Incense"],
	"JewelryWorkshop": ["SapphireBracelet", "GemNecklace", "AmethystPendant", "EmeraldRing", "PearlEarrings", "CrystalLotus"],
	"Knocker": ["StoneBlock", "LimestoneBlock", "Beams", "PalmBeams", "Millstone"],
	"Loom": ["Lace", "Wattle", "Rope", "Gloves", "Sackcloth", "Cloth", "Necklace", "PicnicBasket", "WickerBasket", "DreamСatcher", "DyedFabric"],
	"MeteoriteForge": ["IronIngot", "IronPipe", "IronPlate", "Hammer"],
	"Mill": ["GoatFood", "ChickenFood", "Ocher", "Flour", "SunflowerOil", "Syrup", "CowFood"],
	"Mixer": ["Soap", "Butter", "Cheese", "BluePaint", "LemonOil"],
	"Pottery": ["Bowl", "Potp", "Jugp", "Amphorap", "Flashlight"],
	"Sawmill": ["Stakes", "UnedgedBoard", "EdgedBoard", "Trough"],
	"ShamanWorkshop": ["SapphireBracelet", "RuneStone"],
	"Smelter": ["Resin", "Coal", "Gold", "Shingles", "BurntBrick", "Nails"],
	"Tannery": ["Leather", "Papyrus", "WhitePaint"],
	"Workshop": ["Scraper", "Axe", "Knife", "Brick"]
};

function updateItems(buildingNameId, itemNameId) {
	var itemName = document.getElementById(itemNameId);
	let selectedBuildingName = document.getElementById(buildingNameId);

	while (itemName.options.length > 0) {
		itemName.remove(itemName.options.length - 1);
	}

	var building = allBuildings[selectedBuildingName.value];

	for (i = 0; i < building.length; i++) {
		var opt = document.createElement('option');

		opt.text = building[i];
		opt.value = building[i];

		itemName.add(opt, null);
	}
}
