/*USE [aspnet-BloomSoft_V2-20200310111219];  
GO  
ALTER TABLE dbo.Tarea   
DROP CONSTRAINT foreing_tareaTarjeta;   
GO  */

/*Drop table dbo.Tarea; */

/*create table Tarea(
	id_tarea INT UNIQUE IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(300) NOT NULL,
	
	PRIMARY KEY (id_tarea),
)*/

/*USE [aspnet-BloomSoft_V2-20200310111219];  
GO  
ALTER TABLE dbo.TarjetaRequerim   
DROP CONSTRAINT foreing_reque;   
GO */ 

/*ALTER TABLE dbo.TarjetaRequerim 
DROP COLUMN id_requerimiento;*/

/*ALTER TABLE dbo.TarjetaRequerim  
ADD verbo VARCHAR(200) NOT NULL;*/

/*ALTER TABLE dbo.TarjetaRequerim  
ADD id_tarea INT NOT NULL;*/

/*ALTER TABLE dbo.TarjetaRequerim
ADD CONSTRAINT foreign_idtarea
FOREIGN KEY (id_tarea) REFERENCES Tarea(id_tarea);*/

/*ALTER TABLE dbo.Requerimiento 
DROP COLUMN categoria;*/

/*ALTER TABLE dbo.Requerimiento  
ADD id_tax INT NOT NULL;*/

/*ALTER TABLE dbo.Requerimiento 
ADD CONSTRAINT foreign_idtax
FOREIGN KEY (id_tax) REFERENCES Taxonomia(nivel_tax);*/

ALTER TABLE dbo.Requerimiento  
ADD id_tarjetaRequerim INT NOT NULL;

ALTER TABLE dbo.Requerimiento 
ADD CONSTRAINT foreign_idtarjetaRequerim
FOREIGN KEY (id_tarjetaRequerim) REFERENCES TarjetaRequerim(id_tarjetaRequerim);

