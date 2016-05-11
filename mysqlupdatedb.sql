CREATE DATABASE `GamigicationDB` CHARACTER SET utf8 COLLATE utf8_general_ci;

create table `GamigicationDB`.`Users`(
id_user int auto_increment NOT NULL,
`name` varchar(50) NOT NULL,
nickname varchar(50) NOT NULL,
passwords varchar(35) NOT NULL,
primary key (id_user)
);

create table `GamigicationDB`.`Ranks`(
id_rank int auto_increment NOT NULL ,
title varchar(50) NOT NULL,
Images longblob ,
points int,
note varchar(125),
primary key (id_rank)
);

create table `GamigicationDB`.`Badges`(
id_badge int auto_increment NOT NULL ,
title varchar(50) NOT NULL,
Images longblob NOT NULL,
points int ,
note varchar(125),
descriptions varchar(125),
primary key (id_badge)
);

create table `GamigicationDB`.`BadgesUser`(
id_badgesUser int auto_increment NOT NULL,
id_user int NOT NULL,
id_badge int NOT NULL,
primary key (id_badgesUser),
FOREIGN KEY (id_user) REFERENCES Users(id_user),
FOREIGN KEY (id_badge) REFERENCES Badges(id_badge)
);

create table `GamigicationDB`.`Levels`(
id_level int auto_increment NOT NULL ,
title varchar(50) NOT NULL,
Images longblob ,
points int,
note varchar(125),
primary key (id_level)
);

create table `GamigicationDB`.`Activity`(
id_activity int auto_increment NOT NULL ,
title varchar(50) NOT NULL,
content varchar(50) NOT NULL,
Images longblob NOT NULL,
id_user int NOT NULL,
primary key (id_activity),
FOREIGN KEY (id_user) REFERENCES Users(id_user)
);

create table `GamigicationDB`.`Helpers`(
id_helper int auto_increment NOT NULL ,
title varchar(50) NOT NULL,
`message` varchar(50),
primary key (id_helper)
);

create table `GamigicationDB`.`Prizes`(
id_prize int auto_increment NOT NULL ,
name_prize varchar(50) NOT NULL,
Images longblob NOT NULL,
points int,
primary key (id_prize)
);

create table `GamigicationDB`.`History`(
id_history int auto_increment NOT NULL ,
id_user int NOT NULL,
points int NOT NULL,
record_date Date NOT NULL,
primary key (id_history)
);

create table `GamigicationDB`.`Profiles`(
id int auto_increment NOT NULL ,
id_user int NOT NULL,
points int NOT NULL,
`level` int NOT NULL,
`rank` int NOT NULL,

primary key (id),
FOREIGN KEY (id_user) REFERENCES Users(id_user),
FOREIGN KEY (`level`) REFERENCES Levels(id_level),
FOREIGN KEY (`rank`) REFERENCES Ranks(id_rank)
);

alter table `GamigicationDB`.`Users` add email varchar(30);
alter table `GamigicationDB`.`Users` add `Image` longblob;
