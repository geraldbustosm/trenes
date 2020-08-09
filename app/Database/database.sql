CREATE TABLE train (
	train_id INTEGER PRIMARY KEY AUTOINCREMENT
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
    model TEXT NOT NULL,
    tons_drag INTEGER NOT NULL,
    in_transit INTEGER DEFAULT 0 NOT NULL, -- en un viaje o no --
    train_id INTEGER DEFAULT NULL,
    station_id INTEGER DEFAULT 0,
    FOREIGN KEY (train_id) REFERENCES train (train_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY (station_id) REFERENCES statin (station_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE wagon (
	wagon_id INTEGER PRIMARY KEY AUTOINCREMENT,
    shipload_type TEXT, -- cargemento --
    shipload_weight INTEGER, -- peso del cargemento --
    wagon_weight INTEGER NOT NULL, -- peso del vagon --
    in_transit INTEGER DEFAULT 0 NOT NULL, -- en un viaje o no --
    train_id INTEGER DEFAULT NULL,
    station_id INTEGER DEFAULT 0,
    FOREIGN KEY(train_id) REFERENCES train (train_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY(station_id) REFERENCES station (station_id) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE travel (
	travel_id INTEGER PRIMARY KEY AUTOINCREMENT,
    state TEXT DEFAULT "Preparado"  -- "Preparado" - "En Transito" - "Completado" - "Cancelado" --
);

CREATE TABLE action (
    action_id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL, -- agregar carro , quitar carro, etc --
    minutes INTEGER NOT NULL
);

CREATE TABLE section_action (
    section_action_id INTEGER PRIMARY KEY AUTOINCREMENT,
    action_id INTEGER NOT NULL, -- 1: Agregar wagon, 2: Agregar locomotive ... -
    travel_section_id INTEGER NOT NULL,
    locomotive_id INTEGER DEFAULT NULL,
    wagon_id INTEGER DEFAULT NULL,
    FOREIGN KEY (action_id) REFERENCES action (action_id),
    FOREIGN KEY (travel_section_id) REFERENCES travel_section (travel_section_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (locomotive_id) REFERENCES locomotive (locomotive_id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (wagon_id) REFERENCES wagon (wagon_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE travel_section (
    travel_section_id INTEGER PRIMARY KEY AUTOINCREMENT,
    arrival_time TEXT NOT NULL,
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
    password TEXT NOT NULL
);

CREATE TABLE permission (
    permission_id INTEGER PRIMARY KEY AUTOINCREMENT,
    permission_name TEXT NOT NULL,
    user_id INTEGER NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user (user_id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO station (name, capacity) 
VALUES
    ('a', 9),
    ('b', 3),
    ('c', 4),
    ('d', 2),
    ('e', 5);

INSERT INTO border_station (station_one_id, station_two_id) 
VALUES 
    (1, 2),
    (2, 1),
    (2, 3),
    (3, 2),
    (3, 4),
    (3, 5),
    (4, 3),
    (5, 3);

INSERT INTO locomotive (model, tons_drag, in_transit, station_id) 
VALUES 
    ('Volvo', 5, 0, 1),
    ('NewJersi"', 6, 0, 1),
    ('Kokimbo', 5, 0, 1),
    ('ElSereni', 5, 0, 1),
    ('Ross', 6, 0, 2),
    ('UcnParo', 5, 0, 3),
    ('Cristobal', 5, 0, 3),
    ('Felipe', 6, 0, 3);

INSERT INTO wagon (wagon_weight, in_transit, station_id) 
VALUES 
    (1, 0, 1),
    (1, 0, 1),
    (1, 0, 1),
    (1, 0, 1),
    (1, 0, 2),
    (1, 0, 2),
    (1, 0, 3);

INSERT INTO action (description, minutes) 
VALUES
    ('add wagon', 20),
    ('add locomotive', 20),
    ('pop wagon', 30),
    ('pop locomotive', 30),
    ('download wagon', 20);

INSERT INTO user (name, email, password) VALUES ('admin', 'admin@admin.cl', '1234');