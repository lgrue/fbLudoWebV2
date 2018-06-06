create table Spiel(
	Spiel_ID int primary key IDENTITY(1,1) not null,
	Name nvarchar(50) not null,
	Ausgeliehen bit not null
);

create table Ausleihe(
	Ausleihe_ID int primary key IDENTITY(1,1) not null,
	PersonenID nvarchar(80) not null,
	Spiel_ID int foreign key references Spiel(Spiel_ID),
	Name nvarchar(50) not null,
	DatumVon date not null,
	DatumBis date not null,
	AnzVerlaengerungen int not null
);