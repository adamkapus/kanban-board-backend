# Temalabor backend

## Leírás

Az alkalmazás egy ASP .NET Core alapú REST API-t valósít meg, amivel teendőket lehet lekérdezni, létrehozni, módosítani, törölni.

## Beüzemelés

A backend szerver elindítása Visul Studioban a Solutionben az `F5` gombbal lehetséges debug módban, de javasolt nem így, hanem a `Ctrl +F5` billentyűkombinációval indítani debug mód nélkül, mert így jobb teljesítményű.
Az alkalmazás az elindítása után a `http://localhost:5000`-en figyel. Ez a TemaLabBackend projektben a Properties mappában található launchSettings.json fájl átírásával módosítható.

## API leírása

A szerver egy REST API-t valósít meg, amivel teendőket lehet kezelni.

Támogatott műveletek:

GET api/ToDoItems : Visszaadja az összes teendőt

GET api/ToDoItems/id : Visszaadja az adott id-jú teendőt

PUT api/ToDoItems/id és a kérés body-jában a módosított értékek : Módosítja az adott id-jú teendőt

POST api/ToDoItems és a kérés body-jában az új teendő : Létrehozza az adott id-jú teendőt, a válaszban a Location headerben megtalálható az új teendő

DELETE api/ToDoItems/id : Törli az adott id-jú teendőt