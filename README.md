# Trenes

## Acerca de
Trenes es un sistema que satisface la necesidad de organizar, sincronizar y administrar los transportes ferroviarios.

## Diagrama entidad-relación

## ![](https://i.imgur.com/lVd5jEi.png)

## Modelo relacional

Train (**id_train**)

Journey (**id_journey**, total_time)

Locomotive (**id_locomotive**, potencia, capacidad_arrastre, mantencion_km, hora, fecha, *id_tren*, *id_estacion*)

Wagon (**id_wagon**, wagon_type, wagon_weight, load_weignt, moment_date, *id_locomotive*, *id_station*)

Station (**id_station**, max_capacity)

Train_Journey (**id_train_journey**, *id_train*, *id_journey*)

Journey_Station (**id_journey_station**, *id_journey*, *id_station*, order_journey)

Station_Border (**id_unique_station**, *id_station_Border*, *id_station*, distance, curr_time)

---

Entity (<u>**primary_key**</u>, atributo, *foreign_key*)

---

## Requerimientos

- .NET Framework 4.7.3
- SQLite
