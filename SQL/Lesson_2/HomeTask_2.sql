create database Football on 
	(
	name = 'FootballDB',			
	filename = 'E:\FootballDB.mdf',
	size = 5mb,
	maxsize = 20mb,
	filegrowth = 10mb
	)
log on						  
	( 
	name = 'LogFootballDB',				
	filename = 'E:\FootballDB.ldf',
	size = 5mb,
	maxsize = 20mb,
	filegrowth = 10mb
	)
collate Cyrillic_General_CI_AS;
go

--use Football;
--use master;

--drop database Football;

create table Team
(
TeamNO int identity not null
primary key,
TeamName varchar(25) not null
)
go

create table Players
(
PlayerID int identity not null
primary key,
TeamNO int not null
foreign key references Team(TeamNO),
PlayerName varchar(25) not null,
NumberGoals int not null,
Salary Money not null
)
go

insert into Team
(TeamName)
values
('Dinamo'),
('Manchester'),
('Spartac');
go

insert into Players
(TeamNO, PlayerName, NumberGoals, Salary)
values
(1, 'Alexeenkov', 8, 500000),
(3, 'Obukhovich', 17, 700000),
(1, 'Chernovetskiy', 25, 1100000),
(3, 'Pushkin', 13, 1000000),
(1, 'Mayakovskiy', 33, 1600000),
(3, 'Dostoevskiy', 5, 600000),
(3, 'Obragimovich', 6, 1200000),
(3, 'Gorchenkov', 1, 1400000),
(2, 'Ivanov', 28, 2100000),
(3, 'Ibragimovich', 3, 1500000),
(2, 'Kappa', 9, 900000),
(2, 'Torvald', 8, 900000),
(1, 'Khorevich', 4, 800000);
go

select p.PlayerName, t.TeamName, p.Salary
from Players as p 
join Team as t on p.TeamNO = t.TeamNO
where p.Salary > 1000000 and t.TeamName like 'D%'
go

select p.PlayerName, t.TeamName, p.Salary, p.NumberGoals
from Players as p 
join Team as t on p.TeamNO = t.TeamNO
where (p.Salary > 1000000 or p.NumberGoals > 10) and 