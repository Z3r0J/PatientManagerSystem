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
Foto nvarchar(MAX) null

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
Select * from Usuarios where UserName = 'Good' and Password='123'

create procedure SP_Existe
@Usuario nvarchar(150)
as
Select * from Usuarios where UserName = @Usuario

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

create procedure SP_AgregarPaciente 
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
	insert into 
		Pacientes 
		(Nombre,Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento,Fumador,Alergias,Foto) 
	values 
		(@Nombre,@Apellido,@Telefono,@Direccion,@Cedula,@Fecha_Nacimiento,@Fumador,@Alergias,@Foto)
end

create procedure SP_ObtenerPacientes
as
begin
	select Id,Nombre,Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento 'Fecha Nacimiento',Fumador,Alergias,Foto from Pacientes
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

create procedure SP_Listar_Resultados
as
select rl.Id,pa.Nombre + ' ' + pa.Apellido as 'Nombre y Apellido', pa.Cedula, pl.Nombre as Prueba from Resultados_Laboratorios rl
inner join Pacientes pa on
rl.IdPaciente = pa.Id
inner join Pruebas_Laboratorios pl
on rl.IdPruebaLaboratorio = pl.Id
where Estados_Resultados=1

create procedure SP_Buscar_Resultados
@Buscar nvarchar(40)
as
select rl.Id,pa.Nombre + ' ' + pa.Apellido as 'Nombre y Apellido', pa.Cedula, pl.Nombre as Prueba from Resultados_Laboratorios rl
inner join Pacientes pa on
rl.IdPaciente = pa.Id
inner join Pruebas_Laboratorios pl
on rl.IdPruebaLaboratorio = pl.Id
where Estados_Resultados=1 and pa.Cedula LIKE @Buscar+'%'

create procedure SP_ReportarResultados
@Id int,
@Resultados nvarchar(100),
@Estados_Resultados int
as
Update Resultados_Laboratorios set Resultados_Pruebas = @Resultados, Estados_Resultados=@Estados_Resultados where
Id=@Id


create procedure SP_AgregarDoctor
@Nombre nvarchar(80),
@Apellido nvarchar(80),
@Correo nvarchar(90),
@Telefono nvarchar(25),
@Cedula nvarchar(70),
@Foto nvarchar(MAX)
as
Insert into Medicos values(@Nombre,@Apellido,@Correo,@Telefono,@Cedula,@Foto)

create procedure SP_ActualizarDoctor
@Id int,
@Nombre nvarchar(80),
@Apellido nvarchar(80),
@Correo nvarchar(90),
@Telefono nvarchar(25),
@Cedula nvarchar(70),
@Foto nvarchar(MAX)
as
Update Medicos set Nombre=@Nombre,Apellido=@Apellido,Correo=@Correo,Telefono=@Telefono,Cedula=@Cedula, Foto=@Foto where Id=@Id

create procedure SP_EliminarDoctor
@Id int
as
Delete Medicos where Id =@Id

create procedure SP_ListarDoctor
as
Select * from Medicos

create procedure SP_BuscarDoctor
@Buscar  nvarchar(70)
as
Select * from Medicos where Cedula LIKE @Buscar+'%'

create procedure SP_ListarCitas
as
Select Citas.Id,Pacientes.Nombre+' '+Pacientes.Apellido as 'Nombre Paciente',Medicos.Nombre+' '+Medicos.Apellido as 'Nombre Doctor', 
Citas.Fecha_Cita,
Citas.Hora_Cita,Causa_Cita,Estados_Citas.Nombre as 'Estados de la cita', IdPaciente,IdDoctor,Estado_Citas from Citas
inner join Pacientes
on Pacientes.Id = Citas.IdPaciente
inner join Medicos
on Medicos.Id = Citas.IdDoctor
inner join Estados_Citas
on Estados_Citas.Id = Citas.Estado_Citas

create procedure SP_AgregarCitas
@IdPacientes int, 
@IdDoctor int,
@Fecha_Cita date,
@Hora_Cita time, 
@Causa_Cita text,
@Estado_Citas int
as
Insert into Citas values(@IdPacientes,@IdDoctor,@Fecha_Cita,@Hora_Cita,@Causa_Cita,@Estado_Citas)

create procedure SP_ActualizarEstadoCitas
@Id int,
@Estado_Cita int
as
Update Citas set Estado_Citas=@Estado_Cita where Id=@Id

create procedure SP_CrearPrueba
@nombre nvarchar(70)
as
insert into Pruebas_Laboratorios values(@nombre)

create procedure SP_ObtenerPruebas
as
Select * from Pruebas_Laboratorios

create procedure SP_EditarPrueba
@id int,
@nombre nvarchar(70)
as
Update Pruebas_Laboratorios set Nombre=@nombre where Id=@id

create procedure SP_EliminarPrueba
@id int
as
Delete Pruebas_Laboratorios where Id=@id

create procedure SP_AgregarResultados
@IdPacientes int,
@IdCitas int,
@IdPruebas int,
@IdDoctor int,
@Resultados nvarchar(100),
@Estados_Resultados int
as
insert into Resultados_Laboratorios values(@IdPacientes,@IdCitas,@IdPruebas,@IdDoctor,@Resultados,@Estados_Resultados)

create procedure SP_EstadosPruebas
@IdPacientes int,
@IdCitas int
as
select Pruebas_Laboratorios.Nombre as 'Nombre de la prueba',Estados_Resultados.Nombre as 'Estado' from Resultados_Laboratorios
inner join
Estados_Resultados
on Estados_Resultados.Id=Resultados_Laboratorios.Estados_Resultados
inner join
Pruebas_Laboratorios
on Pruebas_Laboratorios.Id=Resultados_Laboratorios.IdPruebaLaboratorio
where IdPaciente=@IdPacientes and IdCita=@IdCitas


create procedure SP_ListadoPruebasCompletadas
@IdPacientes int,
@IdCitas int
as
select Pruebas_Laboratorios.Nombre as 'Nombre de la prueba',Resultados_Pruebas as 'Resultado total' from Resultados_Laboratorios
inner join
Pruebas_Laboratorios
on Pruebas_Laboratorios.Id=Resultados_Laboratorios.IdPruebaLaboratorio
where IdPaciente=@IdPacientes and IdCita=@IdCitas and Estados_Resultados=2

create procedure SP_ObtenerPacientesPorId
@Id int
as
select Nombre + ' ' + Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento 'Fecha Nacimiento' from Pacientes
Where Id=@Id

create procedure SP_BuscarPacientes
@Buscar nvarchar(70)
as
select Id,Nombre,Apellido,Telefono,Direccion,Cedula,Fecha_Nacimiento 'Fecha Nacimiento',Fumador,Alergias,Foto from Pacientes
where
Cedula LIKE @Buscar + '%'
