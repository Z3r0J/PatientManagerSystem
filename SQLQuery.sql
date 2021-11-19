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

Create procedure SP_Login
@Usuario nvarchar(150),
@Contraseña nvarchar(30)
as
Select * from Usuarios where UserName = @Usuario and Password=@Contraseña

insert into Usuarios values('Jose', 'Cayetano', 'Cayetano@gmail.com','JCaye','123','0')



Create procedure SP_Agregar
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Correo nvarchar(50),
@UserName nvarchar(150),
@Password nvarchar(30),
@TipoDeUsuario int
as
insert into Usuarios values(@Nombre, @Correo, @Correo,@UserName,@Password,@TipoDeUsuario)