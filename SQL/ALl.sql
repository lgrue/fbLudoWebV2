use fbLudoDB;

create table Kategorie(
	Kategorie_ID int primary key IDENTITY(1,1) not null,
	Bezeichnung nvarchar(50) not null
);

create table Spiel(
	Spiel_ID int primary key IDENTITY(1,1) not null,
	Name nvarchar(50) not null,
	Kategorie int foreign key references Kategorie(Kategorie_ID),
	Vereinstarif float not null,
	Normaltarif float not null,
	Ausgeliehen bit not null
);

create table Ausleihe(
	Ausleihe_ID int primary key IDENTITY(1,1) not null,
	PersonenID nvarchar(80) not null
);

create table Ausleihe_Spiel(
	Ausleihe_Spiel_ID int primary key IDENTITY(1,1) not null,
	Ausleihe_ID int foreign key references Ausleihe(Ausleihe_ID),
	Spiel_ID int foreign key references Spiel(Spiel_ID),
	Name nvarchar(50) not null,
	DatumVon date not null,
	DatumBis date not null,
	AnzVerlaengerungen int not null
);

create table Code(
	Code_ID int primary key IDENTITY(1,1) not null,
	Code nvarchar(20) not null,
	Aktiv bit not null,
);

insert into Kategorie(Bezeichnung) values('Kindergarten');
insert into Kategorie(Bezeichnung) values('Unterstufe');
insert into Kategorie(Bezeichnung) values('Oberstufe');

insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('Roll for it!', 1, '5.00', '7.50', 0);
insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('Splendor', 1, '5.00', '7.50', 0);
insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('Qwixx', 2, '7.50', '10.00', 0);
insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('King of Tokyo', 2, '7.50', '10.00', 0);
insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('Honshu', 2, '7.50', '10.00', 0);
insert into Spiel(Name, Kategorie, Vereinstarif, Normaltarif, Ausgeliehen) values('Ji-Yeong', 3, '10.00', '12.50', 0);

/*insert into Ausleihe(PersonenID) values('0edb29ba-f57c-4869-844e-2a1c6c7e3a3c');
insert into Ausleihe(PersonenID) values('5fdc3c86-6790-409a-aa8b-1983f174d3c4');
insert into Ausleihe(PersonenID) values('5fdc3c86-6790-409a-aa8b-1983f174d3c4');

insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(1, 1, 'Roll for it!', convert(datetime,'05.06.18',4), convert(datetime,'12.06.18',4), 0);
insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(2, 2, 'Splendor', convert(datetime,'06.06.18',4), convert(datetime,'13.06.18',4), 0);
insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(2, 3, 'Qwixx', convert(datetime,'06.06.18',4), convert(datetime,'13.06.18',4), 0);
insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(3, 4, 'King of Tokyo', convert(datetime,'08.06.18',4), convert(datetime,'15.06.18',4), 0);
insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(3, 5, 'Honshu', convert(datetime,'08.06.18',4), convert(datetime,'15.06.18',4), 0);
insert into Ausleihe_Spiel(Ausleihe_ID, Spiel_ID, Name, DatumVon, DatumBis, AnzVerlaengerungen) values(3, 6, 'Ji-Yeong', convert(datetime,'08.06.18',4), convert(datetime,'15.06.18',4), 0);*/