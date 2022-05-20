DROP DATABASE GymDatabase;

GO
CREATE DATABASE GymDatabase;

GO
USE GymDatabase;

GO
CREATE TABLE jornadas(
	id_jornada INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre_jornada VARCHAR(30) NOT NULL,
	dias_jornada INT NOT NULL,
	nombre_dias VARCHAR(14) NOT NULL
)

GO
CREATE TABLE empleados(
	id_empleado INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombres_empleado VARCHAR(30) NOT NULL ,
	apellidos_empleado VARCHAR(45) NOT NULL,
	telefono_empleado NCHAR(10) NOT NULL,
	nombre_sesion_empleado VARCHAR(20) UNIQUE NOT NULL,
	password_empleado VARCHAR(60) NOT NULL,
	id_jornada_empleado INT NOT NULL FOREIGN KEY REFERENCES jornadas(id_jornada)
)

GO
CREATE TABLE bitacoras(
	id_bitacora INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	asistencia DATETIME NOT NULL,
	id_empleado_bitacora INT NOT NULL FOREIGN KEY REFERENCES empleados(id_empleado)
)











GO
CREATE TABLE promociones(
	id_promocion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	precio_descuento_promocion DECIMAL NOT NULL,
	descripcion_descuento TEXT NOT NULL
)

GO
CREATE TABLE planes(
	id_plan INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre_plan VARCHAR(45) NOT NULL,
	descripcion_plan TEXT NULL,
	precio_plan DECIMAL NOT NULL,
	id_promocion_plan INT NULL FOREIGN KEY REFERENCES promociones(id_promocion)
)

GO
CREATE TABLE clientes(
	id_cliente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombres_cliente VARCHAR(40) NOT NULL,
	apellidos_cliente VARCHAR(40) NOT NULL,
	telefomo_cliente VARCHAR(45) NOT NULL,
	foto_perfil_cliente TEXT NULL,
	recomendaciones_generadas INT NOT NULL
)

GO
CREATE TABLE suscripciones(
	id_suscripcion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	id_cliente_suscripcion INT NOT NULL,
	id_plan_suscripcion INT NOT NULL,
	fecha_suscripcion DATETIME NOT NULL,
	fecha_termino_suscripcion DATETIME NOT NULL
)