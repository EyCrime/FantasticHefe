# Spielidee
Ein Hefepilz hat sich im Brotteig verlaufen und möchte nach Hause zu seiner lilanen Couch. Leider hat er den genauen Weg vergessen und begegnet dadurch auf seinem Weg vielen unerwünschten Hindernissen. Dazu zählen die bösen kälte und wärme Wesen, dessen Ziel es ist das Zuhause der Hefepilze, dem Brotteig, zu vernichten. Um ihr Ziel zu erreichen versuchen sie nicht nur erbittert jeden Hefepilz loszuwerden, sondern Opfern sich auch bewusst im Falle ihres Todes ihrem Ziel. Zum Glück weiß der Hefepilz das und geht taktisch gegen seine Gegner vor: für jedes kälte Wesen vernichtet er ein weiteres wärme Wesen, schließlich möchte er die Temperatur im Brotteig eben halten. Dafür benutzt er die übrig gebliebenen Zuckermoleküle im Teig, welche es ihm ermöglichen Co2, heißes und kaltes Wasser zu produzieren. Er muss aber aufpassen! Kälte Wesen können ausschließlich durch heißes Wasser vernichtet werden und wärme Wesen nur mit kaltem. Seinen PupsJetpack und Kohlenstoffdioxid Bomben setzt er weise auf seinem Weg ein. 

Seine Geschichte wird mitteils eines Jump 'n Run 'n Gun's erzählt mit einer seitlichen Ansicht auf das Spiel. 


# Steuerung

Bewegung
* laufen mit A(links) und D(rechts)
* spingen mit W oder Leertaste 
* Jetpack doppel W oder Leertaste

Munition
* linke Maustaste zum Schießen
* shift für den Munitionswechsel
* rechte Maustaste für den Bombenwurf


## Hauptmechanik
* 1 Level
* W, A, D (Pfeiltasten & Leertaste) zum Bewegen  
* Kamera läuft mit dem Charakter immer mit (hoch + runter und rechts + links)
* Zucker sammeln (für Score und Co2 Balken)
* Co2 Ladebalken für Sprünge und Attacken → wenn leer dann nicht möglich
* Doppel W oder Leertaste für Doppelsprünge und fliegen
* Linke Maustaste: Normaler Wasserschuss
  * Fliegt straight, aber hat keine unendliche Reichweite
  * 3 Hits, um einen Gegner zu besiegen
* Highscore → Score wird durch sammeln von Zucker, Kills und Restzeit erhöht
* Gegner → Lava Spirits
  * Können sich auf einem Pfad bewegen (links & rechts/ oben & unten). Schießen in die Richtung des Gegners, aber keine Verfolgungsschüsse.
  * haben Lebensbalken
* Zwei Zuckerarten für sowohl Wasser (Icon mit Anzahl der Munition) und Co2  (Ladebalken mit Manaanzeige)
* Gameover: Gegner 4 mal getroffen (3 Leben), runterfallen oder Zeitlimit abgelaufen


### Should have
* Rechte Maustaste: Furzbombe
  * Macht einen Bogen und kann nur verwendet werden, wenn man 100% Co2 hat
  * Gedrückt Halten erhöht den Wurfwinkel
* Sound Effects
* Hintergrundmusik
* Score lokal speicherbar-json
* Temperatur steigt beim killen von Ice Spirits und sinkt beim killen von Fire Spirits →  Ziel ist die Temperatur mittig zu halten
* Ice Spirits
* Zuckerart für heißes Wasser
* Gameover: Temperatur zu hoch/tief


### Nice to have
* Mehr Level
* Endless Level
* Ansteigende Schwierigkeit
* PowerUps
* Scoreboard
* Final Boss
* Shop
* Vierte Art von Zucker als Währung für den Shop
* Secrets/ Rätsel
* Gegner die einen verfolgen


## Design
![Player](https://github.com/EyCrime/FantasticHefe/blob/main/images/jumping.png)
![PlayerBullets]()
![HotGegner](https://github.com/EyCrime/FantasticHefe/blob/main/images/Fire_Spirit_Spritesheat.png)
![HotGegnerBullets](https://github.com/EyCrime/FantasticHefe/blob/main/images/hotWaterbullet_Spritesheat.png)
![ColdGegner](https://github.com/EyCrime/FantasticHefe/blob/main/images/Ice_Spirit_Spritesheat.png)
![ColdGegnerBullets](https://github.com/EyCrime/FantasticHefe/blob/main/images/coldWaterbullet_Spritesheat.png)
![Co2](https://github.com/EyCrime/FantasticHefe/blob/main/images/CZucker.png)
![heißesWasser](https://github.com/EyCrime/FantasticHefe/blob/main/images/HZucker.png)
![kaltesWasser](https://github.com/EyCrime/FantasticHefe/blob/main/images/KZucker.png)
![Map](https://github.com/EyCrime/FantasticHefe/blob/main/images/TilesetMap-export.png)
![ending couch](https://github.com/EyCrime/FantasticHefe/blob/main/images/Finish-export.png)
![UI Canvas]()
![Hauptmenü]()
![Settingsmenü]()


## Teammitglieder
* Emircan Yüksel
* Esther Ruth Gülpen Garay
* Fatlind Krasniqi
* Habib Farhan
