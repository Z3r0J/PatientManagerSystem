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