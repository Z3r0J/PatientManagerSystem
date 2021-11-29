create database SistemaGestorPacientes

use SistemaGestorPacientes

create table Usuarios(
Id int identity(1,1),
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null,
Correo nvarchar(50) not null,
UserName nvarchar(150) not null,
Password nvarchar(30) not null,
TipoDeUsuario int not null foreign key references TipoUsuario(Id)

primary key(Id)
)


create table TipoUsuario(
Id int identity(1,1),
Nombre nvarchar(50)

primary key(Id)
)

create table Pruebas_Laboratorios(
Id int identity(1,1),
Nombre nvarchar(70)

primary key(Id)
)

create table Pacientes(
Id int identity(1,1),
Nombre nvarchar(70) not null,
Apellido nvarchar(70) not null,
Telefono nvarchar(25) not null,
Direccion nvarchar(60) not null,
Cedula nvarchar(40) not null,
Fecha_Nacimiento datetime not null,
Fumador bit not null,
Alergias text not null,
Foto nvarchar(Max)

primary key(Id)
)

create table Medicos(
Id int identity (1,1),
Nombre nvarchar(80) not null,
Apellido nvarchar(80) not null,
Correo nvarchar(90) not null,
Telefono nvarchar(25) not null,
Cedula nvarchar(70) not null,
Foto nvarchar(MAX) not null

primary key(Id)
)

create Table Estados_Resultados(
Id int identity(1,1),
Nombre nvarchar(60) not null

primary key(Id)
)

create Table Estados_Citas(
Id int identity(1,1),
Nombre nvarchar(60) not null

primary key(Id)
)


create table Citas(
Id int identity(1,1),
IdPaciente int foreign key references Pacientes(Id) not null,
IdDoctor int foreign key references Medicos(Id) not null,
Fecha_Cita date not null,
Hora_Cita time not null,
Causa_Cita text not null,
Estado_Citas int foreign key references Estados_Citas(Id)

primary key(Id)
)

create table Resultados_Laboratorios(
Id int identity(1,1),
IdPaciente int foreign key references Pacientes(Id),
IdCita int foreign key references Citas(Id),
IdPruebaLaboratorio int foreign key references Pruebas_Laboratorios(Id),
IdDoctor int foreign key references Medicos(Id),
Resultados_Pruebas nvarchar(100) not null,
Estados_Resultados int foreign key references Estados_Resultados(Id)

primary key(Id)
)


create procedure SP_ListadoUsuarios
as
select us.Id as codigo, us.Nombre, us.Apellido,us.Correo,us.UserName as Usuario, us.Password as Contraseña, tu.Nombre as 'Tipo Usuario' from Usuarios us inner join
TipoUsuario tu on tu.Id=us.TipoDeUsuario

Create procedure SP_Login
@Usuario nvarchar(150),
@Contraseña nvarchar(30)
as
Select * from Usuarios where UserName = @Usuario and Password=@Contraseña


create procedure SP_Agregar
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Correo nvarchar(50),
@UserName nvarchar(150),
@Password nvarchar(30),
@TipoDeUsuario int
as
insert into Usuarios values(@Nombre, @Apellido, @Correo,@UserName,@Password,@TipoDeUsuario)

create procedure SP_SeleccionCorreo
@Id int
as
Select Id,Nombre,Apellido,UserName,Correo from Usuarios where Id=@Id


create procedure SP_Actualizar
@Id int,
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Correo nvarchar(50),
@UserName nvarchar(150),
@Password nvarchar(30),
@TipoDeUsuario int
as
Update Usuarios set Nombre=@Nombre, Apellido=@Apellido,Correo=@Correo,UserName=@UserName,Password=@Password,TipoDeUsuario=@TipoDeUsuario
where Id=@Id


create procedure SP_Eliminar
@Id int
as
Delete Usuarios where Id=@Id


insert into Usuarios values('Jose', 'Cayetano', 'Cayetano@gmail.com','JCaye','123','0')

alter procedure SistemaGestorPacientes.dbo.SP_AgregarPaciente 
@Nombre nvarchar(70),
@Apellido nvarchar(70),
@Telefono nvarchar(25),
@Direccion nvarchar(60),
@Cedula nvarchar(40),
@Fecha_Nacimiento datetime,
@Fumador bit,
@Alergias text
as
begin
	insert into 
		Pacientes 
		(Nombre,Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento,Fumador,Alergias) 
	values 
		(@Nombre,@Apellido,@Telefono,@Direccion,@Cedula,@Fecha_Nacimiento,@Fumador,@Alergias)
end

create procedure SP_ObtenerPacientes
as
begin
	select Id, Nombre,Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento 'Fecha Nacimiento',Fumador,Alergias,Foto from Pacientes
end

create procedure SP_EliminarPaciente 
@Id int
as
begin
	delete Pacientes where Id = @Id
end

create procedure SP_ActualizarPaciente
@Id int,
@Nombre nvarchar(70),
@Apellido nvarchar(70),
@Telefono nvarchar(25),
@Direccion nvarchar(60),
@Cedula nvarchar(40),
@Fecha_Nacimiento datetime,
@Fumador bit,
@Alergias text,
@Foto nvarchar (max)
as
begin
	update Pacientes
	set 
		Nombre = @Nombre, 
		Apellido = @Apellido,
		Telefono = @Telefono,
		Direccion = @Direccion,
		Cedula = @Cedula,
		Fecha_Nacimiento = @Fecha_Nacimiento,
		Fumador = @Fumador,
		Alergias = @Alergias,
		Foto = @Foto 
	where
		Id = @Id
end

select * from Pacientes
SELECT max(ID) from Pacientes


create procedure SP_ObtenerPruebas
as
begin
	select * from Pruebas_Laboratorios
end

create procedure SP_CrearPrueba
@nombre nvarchar(70)
as
begin
	insert into Pruebas_Laboratorios (Nombre) values (@nombre)
end

create procedure SP_EditarPrueba
@id int,
@nombre nvarchar(70)
as
begin
	update Pruebas_Laboratorios 
	set  Nombre = @nombre 
	where Id = @id
end

create procedure SP_EliminarPrueba
@id int
as
begin
	delete Pruebas_Laboratorios where Id=@id
end
	
	