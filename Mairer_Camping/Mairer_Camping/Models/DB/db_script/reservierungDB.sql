create database if not exists reservierungDB collate utf8_general_ci;
use reservierungDB;

create table users(
	id int not null auto_increment,
    firstname varchar(100) null,
    lastname varchar(100) not null,
    arrivalDate date null,
    departureDate date null,

    
    constraint id_PK primary Key(id)


)engine=InnoDB;
  