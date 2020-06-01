/*Drop table dbo.Licencia;
Drop table dbo.VerbosTarjeta;*/

create table Licencia(
	id INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_licencia INT NOT NULL,
	cantidadRequerimientos INT NOT NULL,
	cantidadProyectos INT NOT NULL,
	tiempo INT NOT NULL,
		
	PRIMARY KEY (id),
	CONSTRAINT foreing_licencia FOREIGN KEY (id_licencia)
	REFERENCES LicenciaUsuario(id_licencia)
)

create table Participante(
	id_participante INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_proyecto INT NOT NULL,
	id_usuario NVARCHAR(128) NOT NULL,
	tipo INT NOT NULL,
	
	PRIMARY KEY (id_participante),
	CONSTRAINT foreign_proyecto FOREIGN KEY (id_proyecto)
	REFERENCES Proyecto(id_proyecto),
	CONSTRAINT foreign_usuario FOREIGN KEY (id_usuario)
	REFERENCES AspNetUsers(id)
)

create table EstadisticasPartida(
	id_estadistica INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_partidajuego INT NOT NULL,
	id_mejorjugador INT NOT NULL,
	id_peorjugador INT NOT NULL,
	mejor_puntaje INT NOT NULL,
	peor_puntaje INT NOT NULL,
	
	PRIMARY KEY (id_estadistica),
	CONSTRAINT foreign_juego FOREIGN KEY (id_partidajuego)
	REFERENCES PartidaJuego(id_partidaJuego),
	CONSTRAINT foreign_mejor FOREIGN KEY (id_mejorjugador)
	REFERENCES PartidaJugador(id_partidaJugador),
	CONSTRAINT foreign_peor FOREIGN KEY (id_peorjugador)
	REFERENCES PartidaJugador(id_partidaJugador)
)


create table VerbosTarjeta(
    id_verbostarjeta INT UNIQUE IDENTITY(1,1) NOT NULL,
	id_tarjetaRequerim INT NOT NULL,
	id_verbo INT NOT NULL,
	
	PRIMARY KEY (id_verbostarjeta),
	CONSTRAINT foreign_tR FOREIGN KEY (id_tarjetaRequerim)
	REFERENCES TarjetaRequerim(id_tarjetaRequerim),
	CONSTRAINT foreign_verB FOREIGN KEY (id_verbo)
	REFERENCES Verbotax(id_verbo)
)

