# Trenes

## Acerca de
Trenes es un sistema que satisface la necesidad de organizar, sincronizar y administrar los transportes ferroviarios.

## Diagrama entidad-relación

## ![](https://i.imgur.com/lVd5jEi.png)

## Modelo relacional

Tren (**id_tren**)

Viaje (**id_viaje**, tiempo_total)

Locomotora (**id_locomotora**, potencia, capacidad_arrastre, mantencion_km, hora, fecha, *id_tren*, *id_estacion*)

Carro (**id_carro**, tipo_carga, peso_carro, peso_carga, hora, fecha, *id_locomotora*, *id_estacion*)

Estacion (**id_estacion**, espacio_disponible, capacidad_max)

TrenViaje (**id_tren, id_viaje**)

ViajeEstacion (**id_viaje, id_estacion**, orden)

EstacionesLimitantes (**id_estacion_1, id_estacion_2**, distancia, tiempo)

---

Entidad (<u>**primary_key**</u>, atributo, *foreign_key*)

---

## Requerimientos

- .NET Framework 4.7.3
- SQLite
