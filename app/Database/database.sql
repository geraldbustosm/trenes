CREATE TABLE train (
	train_id INTEGER PRIMARY KEY AUTOINCREMENT,
    travel_id INTEGER NOT NULL,
    drag_locomotive INTEGER NOT NULL,
    FOREIGN KEY(drag_locomotive) REFERENCES locomotive (locomotive_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY(travel_id) REFERENCES travel (travel_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE station (
	station_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    capacity INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE border_station (
    border_station_id INTEGER PRIMARY KEY AUTOINCREMENT,
    station_one_id INTEGER NOT NULL,
    station_two_id INTEGER NOT NULL,
    FOREIGN KEY (station_one_id) REFERENCES station (station_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (station_two_id) REFERENCES station (station_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE locomotive (
	locomotive_id INTEGER PRIMARY KEY AUTOINCREMENT,
    patent TEXT NOT NULL,
    tons_drag INTEGER NOT NULL DEFAULT 0,
    in_transit INTEGER DEFAULT 0 NOT NULL, -- en un viaje o no --
    train_id INTEGER DEFAULT 0,
    station_id INTEGER DEFAULT 0,
    FOREIGN KEY (train_id) REFERENCES train (train_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY (station_id) REFERENCES station (station_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE wagon (
	wagon_id INTEGER PRIMARY KEY AUTOINCREMENT,
    patent TEXT NOT NULL,
    shipload_type TEXT DEFAULT '', -- cargemento --
    shipload_weight INTEGER DEFAULT 0, -- peso del cargemento --
    wagon_weight INTEGER NOT NULL DEFAULT 0, -- peso del vagon --
    in_transit INTEGER DEFAULT 0 NOT NULL, -- en un viaje o no --
    train_id INTEGER DEFAULT 0,
    station_id INTEGER DEFAULT 0,
    FOREIGN KEY(train_id) REFERENCES train (train_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY(station_id) REFERENCES station (station_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE travel (
	travel_id INTEGER PRIMARY KEY AUTOINCREMENT,
    init_time DATE NOT NULL,
    arrival_time DATE NOT NULL,
    state TEXT DEFAULT "Programado" -- "Programado" - "En Transito" - "Completado" --
);

CREATE TABLE action (
    action_id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL,
    minutes INTEGER NOT NULL
);

CREATE TABLE section_action (
    section_action_id INTEGER PRIMARY KEY AUTOINCREMENT,
    action_id INTEGER NOT NULL,
    travel_section_id INTEGER NOT NULL,
    locomotive_id INTEGER DEFAULT 0,
    wagon_id INTEGER DEFAULT 0,
    FOREIGN KEY (action_id) REFERENCES action (action_id),
    FOREIGN KEY (travel_section_id) REFERENCES travel_section (travel_section_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (locomotive_id) REFERENCES locomotive (locomotive_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (wagon_id) REFERENCES wagon (wagon_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE travel_section (
    travel_section_id INTEGER PRIMARY KEY AUTOINCREMENT,
    init_time DATE NOT NULL,
    arrival_time DATE NOT NULL,
    priority INTEGER NOT NULL,
    travel_id INTEGER NOT NULL,
    origin_station_id INTEGER NOT NULL,
    destination_station_id INTEGER NOT NULL,
    FOREIGN KEY (travel_id) REFERENCES travel (travel_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (origin_station_id) REFERENCES station (station_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (destination_station_id) REFERENCES station (station_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE user (
    user_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    email TEXT NOT NULL,
    password TEXT NOT NULL,
    permission_id INTEGER NOT NULL,
    FOREIGN KEY (permission_id) REFERENCES permission (permission_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE permission (
    permission_id INTEGER PRIMARY KEY AUTOINCREMENT,
    permission_name TEXT NOT NULL
);

INSERT INTO station (name, capacity) 
VALUES
    ('La Serena', 10),
    ('Coquimbo', 10),
    ('Ovalle', 10),
    ('Valle Elqui', 10),
    ('Vicuña', 10);

INSERT INTO border_station (station_one_id, station_two_id) 
VALUES 
    (1, 2),
    (1, 3),
    (5, 1),
    (2, 4),
    (2, 5),
    (3, 4),
    (3, 5);

INSERT INTO locomotive (patent, tons_drag, in_transit, station_id) 
VALUES 
    ('Manzano', 50, 0, 1),
    ('Chait', 100, 0, 1),
    ('Ross', 150, 0, 2),
    ('Chiang', 120, 0, 2),
    ('Soza', 100, 0, 3),
    ('Boris', 100, 0, 3),
    ('Felipe', 100, 0, 3),
    ('Telgie', 300, 0, 4),
    ('Carrasco', 100, 0, 5),
    ('Alfaro', 100, 0, 5),
    ('Leger', 100, 0, 5),
    ('Castillo', 100, 0, 5),
    ('Luco', 1, 1, 5);

INSERT INTO wagon (patent, wagon_weight, in_transit, station_id) 
VALUES 
    ('Platano', 100, 0, 1),
    ('Manzana', 200, 0, 1),
    ('Frutilla', 300, 0, 2),
    ('Frambuesa', 400, 0, 5),
    ('Naranja', 500, 0, 2),
    ('Durazno', 600, 0, 4),
    ('Pera', 800, 0, 3),
    ('Kiwi', 900, 0, 1),
    ('Tomate', 300, 0, 1),
    ('Cereza', 400, 0, 2),
    ('Tuna', 200, 0, 5), 
    ('Melon', 100, 0, 4),
    ('Sandia', 300, 0, 3);

INSERT INTO action (description, minutes) 
VALUES
    ('Agregar carro', 20),
    ('Agregar locomotora', 20),
    ('Quitar carro', 30),
    ('Quitar locomotora', 30),
    ('Descargar carro', 20);

INSERT INTO permission (permission_name) 
VALUES
    ('Administrador'),
    ('Operador'),
    ('Invitado');

INSERT INTO user (name, email, password, permission_id) 
VALUES 
    ('admin', 'admin@admin.cl', '1234', 1);