create database PasajesAviones
use PasajesAviones

-- Creación de tabla Avion
CREATE TABLE Avion (
    IdAvion INT IDENTITY(1,1) PRIMARY KEY,
    Matricula VARCHAR(20) NOT NULL UNIQUE,
    Modelo VARCHAR(50) NOT NULL,
    Capacidad INT NOT NULL
);

-- Creación de tabla Pasajero
CREATE TABLE Pasajero (
    IdPasajero INT IDENTITY(1,1) PRIMARY KEY,
    Pasaporte VARCHAR(20) NOT NULL UNIQUE,
    NombreApellido VARCHAR(100) NOT NULL,
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE
);

-- Creación de tabla Pasaje
CREATE TABLE Pasaje (
    IdPasaje INT IDENTITY(1,1) PRIMARY KEY,
    NumeroAsiento VARCHAR(10) NOT NULL,
    FechaVuelo DATE NOT NULL,
    IdAvion INT NOT NULL,
    IdPasajero INT NOT NULL,
    CONSTRAINT FK_Pasaje_Avion FOREIGN KEY (IdAvion) REFERENCES Avion(IdAvion),
    CONSTRAINT FK_Pasaje_Pasajero FOREIGN KEY (IdPasajero) REFERENCES Pasajero(IdPasajero)
);

-- Insertar datos en Avion
INSERT INTO Avion (Matricula, Modelo, Capacidad)
VALUES 
('LV-ABC', 'Boeing 737', 180),
('LV-DEF', 'Airbus A320', 170),
('LV-GHI', 'Embraer 190', 110),
('LV-JKL', 'Boeing 787 Dreamliner', 250),
('LV-MNO', 'Airbus A350', 300);

-- Insertar datos en Pasajero
INSERT INTO Pasajero (Pasaporte, NombreApellido, Nacionalidad, FechaNacimiento)
VALUES
('P123456', 'Juan Pérez', 'Argentina', '1990-05-12'),
('P234567', 'María López', 'Chile', '1985-08-23'),
('P345678', 'Carlos García', 'Uruguay', '1978-11-02'),
('P456789', 'Ana Torres', 'Brasil', '1995-03-17'),
('P567890', 'Lucía Fernández', 'España', '2000-07-30'),
('P678901', 'Pedro Gómez', 'México', '1982-12-11'),
('P789012', 'Sofía Romero', 'Colombia', '1993-09-25'),
('P890123', 'Diego Martínez', 'Perú', '1988-01-05');

-- Insertar datos en Pasaje
INSERT INTO Pasaje (NumeroAsiento, FechaVuelo, IdAvion, IdPasajero)
VALUES
('1A', '2025-10-10', 1, 1),
('2B', '2025-10-10', 1, 2),
('3C', '2025-10-11', 2, 3),
('4D', '2025-10-11', 2, 4),
('5E', '2025-10-12', 3, 5),
('6F', '2025-10-12', 3, 6),
('7G', '2025-10-13', 4, 7),
('8H', '2025-10-13', 5, 8);
