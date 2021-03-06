create database if not exists db_einfuehrungsbsp collate utf8_general_ci;
use db_einfuehrungsbsp;

create table users(
	id int not null auto_increment,
    firstname varchar(100) null,
    lastname varchar(100) not null,
    gender int not null,
    birthdate date null,
    username varchar(100) not null unique,
    password varchar(128) not null,
    typ int not null,
    
    constraint id_PK primary Key(id)


)engine=InnoDB;

insert into users VALUES(null, "T", "M", 0, "2000-10-02", "thm", sha2("thmairer",512), 2);

select * from users;
