--Create Database SkolaJezika2

use SkolaJezika2

Drop Table Korisnik
Drop Table Tip_Korisnika
Drop Table Pohadja
Drop Table Uplata
Drop Table Kurs
Drop Table Nastavnik
Drop Table Ucenik
Drop Table Jezik
Drop Table TipKursa
Drop Table Skola

Create Table Tip_Korisnika (
	Id bigint identity primary key,
	Naziv Varchar(15) Not Null,
	Opis Varchar(45),
	Obrisan Bit
)

create table Korisnik(
	Id bigint identity primary key,
	Ime varchar(30),
	Prezime varchar(30),
	JMBG varchar(13) unique Not Null,
	Datum_Rodjenja Date,
	K_Ime varchar(25) Not Null,
	Lozinka varchar(30) Not Null,
	Obrisan Bit,
	Tip_Id bigint foreign key references Tip_Korisnika(Id)
)

Create Table Ucenik(
	Id BigInt Identity Primary Key,
	Ime varchar(30),
	Prezime varchar(30),
	JMBG varchar(13) unique Not Null,
	Obrisan Bit
)

Create Table Nastavnik(
	Id BigInt Identity Primary Key,
	Ime varchar(30),
	Prezime varchar(30),
	JMBG varchar(13) unique Not Null,
	Obrisan Bit
)

Create Table Jezik(
	Id BigInt Identity Primary Key,
	Naziv VarChar(40),
	Oznaka VarChar(3),
	Obrisan Bit
)

Create Table TipKursa(
	Id BigInt Identity Primary Key,
	Nivo VarChar(30),
	Obrisan Bit
)

Create Table Kurs(
	Id BigInt Identity Primary Key,
	JezikId BigInt Foreign Key References Jezik(Id),
	TipId BigInt Foreign Key References TipKursa(Id),
	NastavnikId BigInt Foreign Key References Nastavnik(Id),
	Cena Float,
	Obrisan Bit
)

Create Table Uplata(
	Id BigInt Identity Primary Key,
	UcenikId BigInt Foreign Key References Ucenik(Id),
	KursId BigInt Foreign Key References Kurs(Id),
	DatumUplate Date,
	Cena Float,
	Obrisan Bit
)

Create Table Pohadja(
	UcenikId BigInt Foreign Key References Ucenik(Id),
	KursId BigInt Foreign Key References Kurs(Id),
	Primary Key(UcenikId, KursId)
)

Create Table Skola(
	Id	BigInt Primary Key,
	Naziv VarChar(40),
	Adresa VarChar(50),
	Telefon VarChar(12),
	Email VarChar(40),
	InternetAdresa VarChar(40),
	PIB VarChar(9),
	MaticniBroj VarChar(8),
	ZiroRacun VarChar(18)
)

Insert Into Tip_Korisnika Values('Administrator', 'Upravlja nastavnicima i korisnicima', 0)
Insert Into Tip_Korisnika Values('Radnik', 'Upravlja ucenicima, uplatama i kursevima', 0)

Insert into Korisnik Values('Marko', 'Jankovic', '1287364738192', '1996-01-01', 'm', 'j', 0, 1)
Insert into Korisnik Values('Janko', 'Markovic', '1237354737192', '1996-01-02', 'j', 'm', 0, 2)
Insert into Korisnik Values('Petar', 'Petrovic', '2237364438152', '1996-04-01', 'p', 'p', 0, 2)

Insert Into Ucenik Values('Stefan', 'Djuric', '1282364538192', 0)
Insert Into Ucenik Values('Marko', 'Radovic', '7342364538192', 0)
Insert Into Ucenik Values('Ana', 'Tot', '3286394538190', 0)
Insert Into Ucenik Values('Obrisan', 'Obrisan', '0', 1)

Insert Into Nastavnik Values('Nikola', 'Radovic', '4286364538195', 0)
Insert Into Nastavnik Values('Marko', 'Djuric', '1282392518192', 0)
Insert Into Nastavnik Values('Ivan', 'Ivanovic', '1282364229892', 0)
Insert Into Nastavnik Values('Obrisan', 'Obrisan', '0', 1)

Insert Into Jezik Values('Engleski', 'ENG', 0)
Insert Into Jezik Values('Nemacki', 'GER', 0)
Insert Into Jezik Values('Spanski', 'ESP', 0)
Insert Into Jezik Values('Obrisan', 'Obr', 1)

Insert Into TipKursa Values('Osnovni', 0)
Insert Into TipKursa Values('Srednji', 0)
Insert Into TipKursa Values('Napredni', 0)

Insert Into Kurs Values(
	(Select J.Id From Jezik J Where Naziv = 'Engleski'),
	(Select T.Id From TipKursa T Where Nivo = 'Osnovni'),
	(Select N.Id From Nastavnik N Where JMBG = '4286364538195'),
	2500, 0)

Insert Into Kurs Values(
	(Select J.Id From Jezik J Where Naziv = 'Spanski'),
	(Select T.Id From TipKursa T Where Nivo = 'Napredni'),
	(Select N.Id From Nastavnik N Where JMBG = '1282392518192'),
	3500, 0)

Insert Into Uplata Values(3, 1, '2016-03-15', 2500, 0)

Insert Into Pohadja Values(1, 1)
Insert Into Pohadja Values(2, 1)
Insert Into Pohadja Values(3, 2)

Insert Into Skola Values(0,
 'Probna Skola',
 'Neka Ulica 1234',
 '021/555-555', 
 'kontakt@probnaskola.rs', 
 'www.probnaskola.rs',
 '123456789',
 '12345678',
 '012345678912345678') 