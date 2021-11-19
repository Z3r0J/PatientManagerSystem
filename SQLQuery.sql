create database SistemaGestorPacientes

create table Usuarios(
Id int identity(1,1),
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null,
Correo nvarchar(50) not null,
UserName nvarchar(150) not null,
Password nvarchar(30) not null,
TipoDeUsuario int not null
)