create database if not exists db_einfuehrungsbsp collate utf8_general_ci;
use db_einfuehrungsbsp;

create table anfragen(
	id int not null auto_increment,
    firstname varchar(100) null,
    lastname varchar(100) not null,
    arrivalDate date null,
    departureDate date null,
    istBearbeitet boolean null,

    
    constraint id_PK primary Key(id)


)engine=InnoDB;
insert into anfragen VALUES(null, "t", "tt", "2020-10-02","2020-10-03",false);

select * from anfragen;
  