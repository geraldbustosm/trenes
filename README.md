# Trains Project

Trains is a desktop application for windows, wich it'll generate a better process control management of the rails that are entered into the system.

  - Insertion of station, locomotives and wagons
  - See the time and in which stations are the bags and locomotives

And of course Train Project itself is open source with a [public repository] on GitHub.

### Technologies used / required 📦

You must have the following technologies as requirements for the correct start of the application:

* .NET Framework 4.7.3
* SQLite

### Installation 🔧

... open the terminal and insert

    $man help

### Entity Relationship Diagram

![Alt text](https://i.imgur.com/U1QASUs.png "Entity Relationship Diagram")

### Relational model 🖇️

-   train (**train_id**)
-   station (**station_id**, name, capacity)
-   border_station (**border_station_id**, *station_one_id*, *station_two_id*)
-   locomotive (**locomotive_id**, model, tons_drag, in_transit, *train_id*, *station_id*)
-   wagon (**wagon_id**, shipload_type, shipload_weight, wagon_weight, in_transit, *train_id*, *station_id*)
-   travel (**travel_id**, total_time)
-   action (**action_id**, description, minutes)
-   section_action (**section_action_id**, *action_id*,*travel_section_id*,*locomotive_id*, *wagon_id*, order_journey)
-   travel_section (**travel_section_id**, arrival_time, order, action, *travel_id*, *origin_station_id*, *destination_station_id*)
-   user (**user_id**, name, email, password)
-   permission (**permission_id**, permission_name, *user_id*)
---

Entidad (<u>**primary_key**</u>, atributo, *foreign_key*)

---


License
----
**Free Software, Hell Yeah!**
