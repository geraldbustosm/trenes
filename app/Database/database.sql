CREATE TABLE Train (
	id_train INTEGER PRIMARY KEY
);
CREATE TABLE Journey (
	id_journey INTEGER PRIMARY KEY,
    total_time INTEGER
);
CREATE TABLE Station (
	id_station INTEGER PRIMARY KEY,
    max_capacity INTEGER
);
CREATE TABLE Locomotive (
	id_locomotive INTEGER,
    id_train INTEGER,
    id_station INTEGER,
    moment_date DATE,
    drag_capacity INTEGER,
    mileage INTEGER,
    PRIMARY KEY (id_locomotive),
    FOREIGN KEY (id_tren) 
        REFERENCES Train (id_tren) 
            ON DELETE CASCADE,
    FOREIGN KEY (id_station) 
        REFERENCES Station (id_station) 
            ON DELETE CASCADE
);
CREATE TABLE Wagon (
	id_wagon INTEGER,
    id_locomotive INTEGER,
    id_station INTEGER,
    moment_date DATE,
    wagon_type INTEGER,
    wagon_weight INTEGER,
    load_weignt INTEGER,
    PRIMARY KEY (id_wagon),
    FOREIGN KEY (id_locomotive) 
        REFERENCES Locomotive (id_locomotive) 
            ON DELETE CASCADE, 
    FOREIGN KEY (id_station) 
        REFERENCES Station (id_station) 
            ON DELETE CASCADE
);
CREATE TABLE Train_Journey(
    id_train_journey INTEGER,
    id_train INTEGER,
    id_journey INTEGER,
    PRIMARY KEY (id_train_journey),
    FOREIGN KEY (id_train) 
        REFERENCES Train (id_train) 
            ON DELETE CASCADE, 
    FOREIGN KEY (id_journey) 
        REFERENCES Journey (id_journey) 
            ON DELETE CASCADE 
);
CREATE TABLE Journey_Station(
    id_journey_station INTEGER,
    id_journey INTEGER,
    id_station INTEGER,
    order_journey INTEGER,
    PRIMARY KEY (id_journey_station),
        FOREIGN KEY (id_journey) 
            REFERENCES Journey (id_journey) 
                ON DELETE CASCADE,
        FOREIGN KEY (id_station) 
            REFERENCES Station (id_station) 
                ON DELETE CASCADE
);
CREATE TABLE Station_Border(
    id_unique_station INTEGER,
    id_station_Border INTEGER,
    id_station INTEGER,
    distance INTEGER,
    curr_time INTEGER,
    PRIMARY KEY (id_unique_station),
        FOREIGN KEY (id_station) 
            REFERENCES Station (id_station) 
                ON DELETE CASCADE,
        FOREIGN KEY (id_station_Border) 
            REFERENCES Station (id_station_Border) 
                ON DELETE CASCADE 
);
