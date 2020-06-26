CREATE TABLE LicenciaUsuario(
	id_licencia INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_usuario NVARCHAR(128) NOT NULL,
	estado BIT NOT NULL,
	
	PRIMARY KEY (id_licencia),
	CONSTRAINT foreing_usuario FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id),
)


/*Licencia*/
create table Licencia(
	id_licencia INT UNIQUE IDENTITY(1,1) NOT NULL,
	cantidadRequerimientos INT NOT NULL,
	cantidadProyectos INT NOT NULL,
	tiempo TIME NOT NULL,
	
	
	CONSTRAINT foreing_licencia FOREIGN KEY (id_licencia)
	REFERENCES LicenciaUsuario(id_licencia)
)

/*Pagos*/
create table Pago(
	id_usuario NVARCHAR(128) NOT NULL,
	id_licencia INT NOT NULL,
	monto MONEY NOT NULL,
	fecha DATE NOT NULL,

	CONSTRAINT foreing_usuario FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id),
	CONSTRAINT foreing_licenciapago FOREIGN KEY (id_licencia)
	REFERENCES LicenciaUsuario(id_licencia)
)

/*Proyecto*/
Create table Proyecto(
	id_proyecto INT UNIQUE IDENTITY(101000001,1) NOT NULL,
	nombre VARCHAR(200) NOT NULL,
	id_usuario NVARCHAR(128) NOT NULL,
	estado BIT NOT NULL,
	interaciones INT,

	PRIMARY KEY (id_proyecto),
	CONSTRAINT foreing_usuarioProyecto FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id)
)

/*PartidaJuego*/
Create table PartidaJuego(
	id_partidaJuego INT UNIQUE IDENTITY(202000001,1) NOT NULL,
	id_proyecto INT NOT NULL,
	id_usuario NVARCHAR(128) NOT NULL,
	fecha DATE NOT NULL,
	hora TIME NOT NULL,

	PRIMARY KEY (id_PartidaJuego),
	CONSTRAINT foreing_usuarioJuego FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id),
	CONSTRAINT foreing_proyectoJuego FOREIGN KEY (id_proyecto)
	REFERENCES Proyecto(id_proyecto)
)

/*PartidaJuegador*/
Create table PartidaJugador(
	id_partidaJugador INT UNIQUE IDENTITY(303000001,1) NOT NULL,
	id_partidaJuego INT NOT NULL,
	id_usuario NVARCHAR(128) NOT NULL,
	puntos INT,

	PRIMARY KEY (id_partidaJugador),
	CONSTRAINT foreing_usuarioJuegador FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id),
	CONSTRAINT foreing_partidaJuego FOREIGN KEY (id_partidaJuego)
	REFERENCES PartidaJuego(id_partidaJuego)
)

/*Taxonomia*/
create table Taxonomia(
	nivel_tax INT UNIQUE IDENTITY(1,1) NOT NULL,
	categoria VARCHAR(100) NOT NULL,
	
	PRIMARY KEY (nivel_tax),
)

/*Verbo Taxonomia*/
create table Verbotax(
	id_verbo INT UNIQUE IDENTITY(1,1) NOT NULL,
	nivel_tax INT NOT NULL,
	categoria VARCHAR(100) NOT NULL,
	
	PRIMARY KEY (id_verbo),
	CONSTRAINT foreing_nivTaxVerb FOREIGN KEY (nivel_tax)
	REFERENCES Taxonomia(nivel_tax)
)

/*Requerimientos*/
create table Requerimiento(
	id_requerimiento INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_proyecto INT NOT NULL,
	categoria VARCHAR(100) NOT NULL,
	
	PRIMARY KEY (id_requerimiento),
	CONSTRAINT foreing_requepro FOREIGN KEY (id_proyecto)
	REFERENCES Proyecto(id_proyecto)
)
/*Tarjeta de Requerimientos*/
create table TarjetaRequerim(
	id_tarjetaRequerim INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_requerimiento INT NOT NULL,
	id_partidaJugador INT NOT NULL,
	nivel_tax INT NOT NULL,
	tiempo INT NOT NULL,
	dificultad INT NOT NULL,
	puntos INT NOT NULL,
	
	PRIMARY KEY (id_tarjetaRequerim),
	CONSTRAINT foreing_partidaJug FOREIGN KEY (id_partidaJugador)
	REFERENCES PartidaJugador(id_partidaJugador),
	CONSTRAINT foreing_reque FOREIGN KEY (id_requerimiento)
	REFERENCES Requerimiento(id_requerimiento),
	CONSTRAINT foreing_nivTax FOREIGN KEY (nivel_tax)
	REFERENCES Taxonomia(nivel_tax)
)

/*VerbosTarjeta*/
create table VerbosTarjeta(
	id_tarjetaRequerim INT NOT NULL,
	id_verbo INT NOT NULL,
	
	
	CONSTRAINT foreing_tR FOREIGN KEY (id_tarjetaRequerim)
	REFERENCES TarjetaRequerim(id_tarjetaRequerim),
	CONSTRAINT foreing_verB FOREIGN KEY (id_verbo)
	REFERENCES Verbotax(id_verbo)
)

/*Tarea*/
create table Tarea(
	id_tarjetaRequerim INT NOT NULL,
	descripcion VARCHAR(200) NOT NULL,
	
	CONSTRAINT foreing_tareaTarjeta FOREIGN KEY (id_tarjetaRequerim)
	REFERENCES TarjetaRequerim(id_tarjetaRequerim),
	
)