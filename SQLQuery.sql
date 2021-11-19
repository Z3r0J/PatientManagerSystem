create database SistemaGestorPacientes

use SistemaGestorPacientes

create table Usuarios(
Id int identity(1,1),
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null,
Correo nvarchar(50) not null,
UserName nvarchar(150) not null,
Password nvarchar(30) not null,
TipoDeUsuario int not null

primary key(Id)
)

Create procedure SP_Login
@Usuario nvarchar(150),
@Contraseña nvarchar(30)
as
Select * from Usuarios where UserName = @Usuario and Password=@Contraseña

insert into Usuarios values('Jose', 'Cayetano', 'Cayetano@gmail.com','JCaye','123','0')

