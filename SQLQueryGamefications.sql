create table Users(
id_user int IDENTITY(1,1) NOT NULL,
name varchar(50) NOT NULL,
nickname varchar(50) NOT NULL,
passwords varchar(35) NOT NULL,
primary key (id_user)
)

create table Ranks(
id_rank int IDENTITY(1,1) NOT NULL ,
title varchar(50) NOT NULL,
Images varchar(50) NOT NULL,
points int,
note varchar(125),
primary key (id_rank)
)

create table Badges(
id_badge int IDENTITY(1,1) NOT NULL ,
title varchar(50) NOT NULL,
Images varchar(50) NOT NULL,
points int NOT NULL,
note varchar(125),
descriptions varchar(125),
primary key (id_badge)
)

create table Levels(
id_level int IDENTITY(1,1) NOT NULL ,
title varchar(50) NOT NULL,
"rank" int NOT NULL,
points int NOT NULL,
primary key (id_level),
FOREIGN KEY ("rank") REFERENCES Ranks(id_rank)
)

create table Activity(
id_activity int IDENTITY(1,1) NOT NULL ,
title varchar(50) NOT NULL,
content varchar(50) NOT NULL,
Images varchar(50) NOT NULL,
id_user int NOT NULL,
primary key (id_activity),
FOREIGN KEY (id_user) REFERENCES Users(id_user)
)

create table Helpers(
id_helper int IDENTITY(1,1) NOT NULL ,
title varchar(50) NOT NULL,
"message" varchar(50),
primary key (id_helper)
)

create table Prizes(
id_prize int IDENTITY(1,1) NOT NULL ,
name_prize varchar(50) NOT NULL,
Images varchar(50) NOT NULL,
points int,
primary key (id_prize)
)

create table History(
id_history int IDENTITY(1,1) NOT NULL ,
id_user int NOT NULL,
points int NOT NULL,
record_date Date NOT NULL,
id_level int NOT NULL,
primary key (id_history),
FOREIGN KEY (id_level) REFERENCES Levels(id_level)
)

create table Profiles(
id int IDENTITY(1,1) NOT NULL ,
id_user int NOT NULL,
points int NOT NULL,
"level" int NOT NULL,
"rank" int NOT NULL,

primary key (id),
FOREIGN KEY (id_user) REFERENCES Users(id_user),
FOREIGN KEY ("level") REFERENCES Levels(id_level),
FOREIGN KEY ("rank") REFERENCES Ranks(id_rank)
)

alter table dbo.Users add email varchar(30)
alter table dbo.Users add "Image" varchar(50)
