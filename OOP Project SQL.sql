create database project_library
use project_library

create table Logintable(

username varchar(40),
pass varchar(40)
);



insert into Logintable (username,pass) values ('Fasiha',456);

select * from Logintable

create table NewBook(
book_id int primary key,
bname varchar(100) not null,
bAuthor varchar(100) not null,
bPublish varchar(100) not null,
bDate varchar(100) not null,
bPrice varchar(1000) not null,
bQuantity varchar(1000)
);



alter table NewBook add bCatagory varchar(max);
select * from NewBook 

insert into NewBook values(2,'Objects','Fasiha ','KIET','4/5/2024','10','2','OOP')
select max(book_id) from NewBook







create table NewStudents(
stdid int Identity primary key,
sname varchar(250) not null,
enroll varchar (250) not null,
dep varchar(250) not null,
sem varchar(250) not null,
contact varchar (250) not null,
email varchar(250) not null

);
select * from NewStudents;



Create table IRBOOK(
id int Identity Primary key ,
std_enroll varchar(250) Not NUll,
std_name varchar(250) Not NUll,
std_dep varchar(250) Not NUll,
std_sem varchar(250) Not NUll,
std_contact varchar(250) Not NUll,
std_email varchar(250) Not NUll,
book_name varchar(1250) Not NUll,
book_issue_date varchar(250) Not NUll,
book_return_date varchar(250),
);

select * from IRBOOK;

