----------------CREATION TABLES---------------------------

CREATE TABLE "User" (
   us_id int generated always as identity,
   us_name varchar(50) not null,
   us_email varchar(50) not null,
   us_active varchar(1) not null,
   us_role varchar(15),
   us_createdat date not null,
   us_username varchar(25) not null,
   us_password varchar(25) not null,
   us_changedat date,
   constraint PK_us_id primary key (us_id)
  );
   
  CREATE TABLE "Message" (
   ms_id int generated always as identity,
   ms_message text not null,
   ms_sender_id int NOT NULL,
   ms_createdat date not null,
   ms_changedat date,
   ms_active varchar(1) not null,
  constraint PK_ms_id primary key (ms_id),
  constraint FK_ms_sender_id foreign key (ms_sender_id)
   REFERENCES "User"(us_id));
   
  CREATE TABLE "Group" (
   gr_id int generated always as identity,
   gr_type varchar(1) not null,
   gr_owner int not null,
   gr_createdat date not null,
   gr_changedat date,
   gr_active varchar(1) not null,
  	constraint PK_gr_id primary key(gr_id),
  	constraint FK_gr_owner foreign key (gr_owner)
   references "User"(us_id));

   
  
  create table "User_Message"(
  um_receiver_id int NOT NULL,
  um_ms_id int not null,
  um_createdAt date not null,
  constraint PK_um_id primary key(um_receiver_id, um_ms_id),
  constraint FK_um_receiver_id foreign key(um_receiver_id) references "User"(us_id),
  constraint FK_um_ms_id foreign key(um_ms_id) references "Message" (ms_id));
 
 create table "Group_Message"(
 gm_ms_id int not null,
 gm_gr_id int not null,
 gm_createdat date not null,
 constraint PK_gm_id primary key (gm_ms_id, gm_gr_id),
 constraint FK_gm_ms_id foreign key (gm_ms_id) references "Message" (ms_id),
 constraint FK_gm_gr_id foreign key (gm_gr_id) references "Group" (gr_id));





  
  
  
  