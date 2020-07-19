CREATE TABLE Tren (
	id_tren INTEGER PRIMARY KEY
);
CREATE TABLE Viaje (
	id_viaje INTEGER PRIMARY KEY,
    tiempo_total INTEGER
);
CREATE TABLE Estacion (
	id_estacion INTEGER PRIMARY KEY,
    espacio_disponible INTEGER,
    capacidad_max INTEGER
);
CREATE TABLE Locomotora (
	id_locomotora INTEGER,
    id_tren INTEGER,
    id_estacion INTEGER,
    hora INTEGER,
    fecha INTEGER,
    capacidad_arrastre INTEGER,
    mantencion_km INTEGER,
    PRIMARY KEY (id_locomotora),
    FOREIGN KEY (id_tren) 
        REFERENCES Tren (id_tren) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
    FOREIGN KEY (id_estacion) 
        REFERENCES Estacion (id_estacion) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION
);
CREATE TABLE Carro (
	id_carro INTEGER,
    id_locomotora INTEGER,
    id_estacion INTEGER,
    hora INTEGER,
    fecha INTEGER,
    tipo_carga INTEGER,
    peso_carro INTEGER,
    peso_carga INTEGER,
    PRIMARY KEY (id_carro),
    FOREIGN KEY (id_locomotora) 
        REFERENCES Locomotora (id_locomotora) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
    FOREIGN KEY (id_estacion) 
        REFERENCES Estacion (id_estacion) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION
);
CREATE TABLE Tren_Viaje(
   id_tren INTEGER,
   id_viaje INTEGER,
   PRIMARY KEY (id_tren, id_viaje),
   FOREIGN KEY (id_tren) 
        REFERENCES Tren (id_tren) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
    FOREIGN KEY (id_viaje) 
        REFERENCES Viaje (id_viaje) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION
);
CREATE TABLE Viaje_Estacion(
   id_viaje INTEGER,
   id_estacion INTEGER,
   orden INTEGER,
   PRIMARY KEY (id_viaje, id_estacion),
    FOREIGN KEY (id_viaje) 
        REFERENCES Viaje (id_viaje) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
    FOREIGN KEY (id_estacion) 
        REFERENCES Estacion (id_estacion) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
);
CREATE TABLE Estacion_Limita(
   id_estacion INTEGER,
   id_estacion_limita INTEGER,
   distancia INTEGER,
   tiempo INTEGER,
   PRIMARY KEY (id_estacion, id_estacion_limita),
    FOREIGN KEY (id_estacion) 
        REFERENCES Estacion (id_estacion) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
    FOREIGN KEY (id_estacion_limita) 
        REFERENCES Estacion (id_estacion_limita) 
            ON DELETE CASCADE 
            ON UPDATE NO ACTION,
);
