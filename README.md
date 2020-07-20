# Trains Project

Tains is a desktop application for windows, wich it'll generate a better process control management of the rails that are entered into the system.

  - Insertion of station, locomotives and wagons
  - See the time and in which stations are the bags and locomotives

And of course Train Project itself is open source with a [public repository] on GitHub.

### Technologies used / required

You must have the following technologies as requirements for the correct start of the application:

* [.NET Framework 4.7.3] -.
* [SQLite] -.

### Installation

... open the terminal and insert

    $man help

### Entity Relationship Diagram

![Alt text](https://i.imgur.com/lVd5jEi.png "Entity Relationship Diagram")

### Modelo relacional

-   Train (**id_train**)
-   Journey (**id_journey**, total_time)
-   Locomotive (**id_locomotive**, potencia, capacidad_arrastre, mantencion_km, hora, fecha, *id_tren*, *id_estacion*)
-   Wagon (**id_wagon**, wagon_type, wagon_weight, load_weignt, moment_date, *id_locomotive*, *id_station*)
-   Station (**id_station**, max_capacity)
-   Train_Journey (**id_train_journey**, *id_train*, *id_journey*)
-   Journey_Station (**id_journey_station**, *id_journey*, *id_station*, order_journey)
-   Station_Border (**id_unique_station**, *id_station_Border*, *id_station*, distance, curr_time)

---

            Entidad (<u>**primary_key**</u>, atributo, *foreign_key*)

---


License
----
**Free Software, Hell Yeah!**