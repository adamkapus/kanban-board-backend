# Temalabor backend

## Leírás

Az alkalmazás egy ASP .NET Core alapú WEB API-t valósít meg, amivel teendőket lehet lekérdezni, létrehozni, módosítani, törölni.

## Beüzemelés

A backend szerver elindítása Visul Studioban a Solutionben az `F5` gombbal lehetséges debug módban, de javasolt nem így, hanem a `Ctrl +F5` billentyűkombinációval indítani debug mód nélkül, mert így jobb teljesítményű.
Az alkalmazás az elindítása után a `http://localhost:5000`-en figyel. Ez a TemaLabBackend projektben a Properties mappában található launchSettings.json fájl átírásával módosítható.

## API leírása

A szerver egy WEB API-t valósít meg, amivel teendőket lehet kezelni.

Támogatott műveletek:

Kérés : GET api/ToDoItems  <br />
Válasz: Visszaadja az összes teendőt

Kérés: GET api/ToDoItems/id <br />
Válasz: Visszaadja az adott id-jú teendőt, vagy 404-es hibakódot, ha nem létezik adott ID-vel teendő

Kérés: PUT api/ToDoItems/id és a kérés body-jában a módosított értékek <br />
Válasz: Módosítja az adott id-jú teendőt, a válasz üres, ha sikeres, 404-es hibakódú, ha nem létezik adott ID-vel teendő

Kérés: POST api/ToDoItems és a kérés body-jában az új teendő <br />
Válasz: Létrehozza az adott id-jú teendőt, a válaszban a Location headerben megtalálható az új teendő

Kérés: DELETE api/ToDoItems/id <br />
Válasz: Törli az adott id-jú teendőt, a válasz üres, ha sikeres, 404-es hibakódú, ha nem létezik adott ID-vel teendő

Kérés: PUT api/ToDoItems/?firstId=`ID1`&secondId=`ID2` <br />
Válasz: Megcseréli az ID1 és ID2 kategórián belüli pozícióját, a válasz üres, ha sikeres, 404-es hibakódú, ha nem létezik adott ID-vel valamelyik teendő, 409-es hibakódú, ha nem egy kategóriában van a két teendő


## Felépítés

A ToDoItemsController osztály felelős a HTTP kérések kiszolgálásáért. Tartalmaz egy ToDoManager-t akinek a műveleteit használja a válasz előállításához.

A ToDoManager osztály felelős az üzleti logika megvalósításáért. Tartalmaz egy ToDoItemRepository-t akinek a műveleteit használja.

A ToDoItemRepository osztály a repository mintát megvalósítva tesz lehetővé műveleteket az adatbázisban lévő teendőkön. Tartalmaz egy ToDoDbContext-et, amin keresztül eléri az adatbázist.

## Tesztek

A ToDoItemsController osztályhoz Unit testeket valósít meg a Tests projektben található ControllerTest osztály. A mock-ok létrehozására a `Moq` csomag van használva.