# Temalabor backend

## Leírás

Az alkalmazás egy ASP .NET Core alapú REST API-t valósít meg, amivel teendőket lehet lekérdezni, létrehozni, módosítani, törölni.

## Beüzemelés

A backend szerver elindítása Visul Studioban a Solutionben az `F5` gombbal lehetséges debug módban, de javasolt nem így, hanem a `Ctrl +F5` billentyűkombinációval indítani debug mód nélkül, mert így jobb teljesítményű.
Az alkalmazás az elindítása után a `http://localhost:5000`-en figyel. Ez a TemaLabBackend projektben a Properties mappában található launchSettings.json fájl átírásával módosítható.

## API leírása

A szerver egy REST API-t valósít meg, amivel teendőket lehet kezelni.

Támogatott műveletek:

Kérés : GET api/ToDoItems    Válasz: Visszaadja az összes teendőt

Kérés: GET api/ToDoItems/id     Válasz: Visszaadja az adott id-jú teendőt, vagy 404-es hibakódot, ha nem létezik adott ID-vel teendő

Kérés: PUT api/ToDoItems/id és a kérés body-jában a módosított értékek  Válasz: Módosítja az adott id-jú teendőt, a válasz üres, ha sikeres, 404-es hibakódú, ha nem létezik adott ID-vel teendő

Kérés: POST api/ToDoItems és a kérés body-jában az új teendő    Válasz: Létrehozza az adott id-jú teendőt, a válaszban a Location headerben megtalálható az új teendő

Kérés: DELETE api/ToDoItems/id     Válasz: Törli az adott id-jú teendőt, a válasz üres, ha sikeres, 404-es hibakódú, ha nem létezik adott ID-vel teendő