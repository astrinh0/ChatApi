------------------- USER DATA ---------------------------------------------------------------------------------------------------------
select * from "User" 

insert into "User" (us_name, us_email, us_active, us_role, us_changedat, us_username, us_password)
values
	('Candido Miquelino', 'candido@gmail.com', 'Y', 'Admin', null, 'candidoAdmin', '12345'),
	('Emanuel Carvalho', 'emanuel@gmail.com', 'Y', 'User', null, 'emanuelUser', '12345'),
	('Jo�o Veloso', 'joao@gmail.com', 'Y', 'Admin', null, 'joaoAdmin', '12345'),
	('Joel Martins', 'joel@gmail.com', 'Y', 'User', null, 'joelUser', '12345'),
	('David Ramos', 'david@gmail.com', 'Y', 'User', null, 'davidUser', '12345'),
	('Jo�o Gomes', 'jgomes@gmail.com', 'Y', 'User', null, 'joaoUser', '12345'),
	('Ricardo Carvalho', 'ricardo@gmail.com', 'Y', 'Admin', null, 'ricardoAdmin', '12345'),
	('Cristiano Ronaldo', 'cristiano@gmail.com', 'Y', 'Admin', null, 'cristianoAdmin', '12345'),
	('Wilson Manaf�', 'wilson@gmail.com', 'Y', 'User', null, 'wilsonUser', '12345'),
	('Mehdi Taremi', 'mehdi@gmail.com', 'Y', 'Admin', null, 'mehdiAdmin', '12345'),
	('Moussa Marega', 'moussa@gmail.com', 'N', 'Admin', null, 'moussaAdmin', '12345'),
	('R�ben Dias', 'ruben@gmail.com', 'N', 'User', null, 'rubenUser', '12345'),
	('Nico Otamendi', 'nico@gmail.com', 'N', 'Admin', null, 'nicoAdmin', '12345'),
	('Tomo Sokota', 'tomo@gmail.com', 'N', 'User', null, 'tomoUser', '12345'),
	('Carlos Secret�rio', 'carlos@gmail.com', 'N', 'User', null, 'carlosUser', '12345');




------------------- GROUP DATA ---------------------------------------------------------------------------------------------------------
select * from "Group" 

insert into "Group" (gr_type, gr_owner, gr_changedat, gr_active, gr_name)
values
	('C', 16, null, 'Y', 'Lord Manaf� Channel'),
	('G', 15, null, 'Y', 'CR7 Group'),
	('G', 10, null, 'N', 'Jo�o Veloso Group'),
	('C', 9, null, 'N', 'Emanuel Carvalho Channel'),
	('G', 11, null, 'Y', 'Joel Martins Group'),
	('C', 8, null, 'Y', 'Candido Miquelino Channel'),
	('G', 12, null, 'N', 'David Ramos Group'),
	('C', 13, null, 'N', 'Jo�o Gomes Channel'),
	('G', 17, null, 'Y', 'Mehdi Taremi Group'),
	('C', 14, null, 'Y', 'Ricardo Carvalho Channel');





------------------- MESSAGE DATA ---------------------------------------------------------------------------------------------------------
select * from "Message" 

insert into "Message" (ms_message, ms_sender_id, ms_changedat, ms_active, ms_readed)
values
	('Ol�, tudo bem?', 15, null, 'Y', 'N'),
	('Tenho reuni�o �s 18h', 10, null, 'Y', 'Y'),
	('N�o te esque�as da chave', 9, null, 'Y', 'N'),
	('Vou agora para Braga', 12, null, 'Y', 'Y'),
	('Sabes a que horas vens?', 16, null, 'N', 'N'),
	('J� viste as notas?', 14, null, 'N', 'Y'),
	('Fiz um bom jogo hoje', 17, null, 'N', 'N'),
	('Fui agora � faculdade', 8, null, 'N', 'Y'),
	('Vou para o trabalho, entretanto..', 15, null, 'Y', 'N'),
	('J� apresentaste o relat�rio?', 10, null, 'Y', 'Y'),
	('Hoje est� imenso calor para treinar', 16, null, 'Y', 'N'),
	('Saiu nos o Vilafranquense para a Ta�a', 17, null, 'Y', 'Y'),
	('Esta aplica��o at� me parece bastante interessante', 13, null, 'N', 'N'),
	('N�o te preocupes, devo chegar entretanto.', 12, null, 'N', 'Y'),
	('Vamos ver como corre', 16, null, 'Y', 'N'),
	('Reparaste na mudan�a de tempo?', 11, null, 'Y', 'Y'),
	('Vou agora ao supermercado', 9, null, 'Y', 'N'),
	('Ok.', 17, null, 'Y', 'Y');



------------------- FILE DATA ---------------------------------------------------------------------------------------------------------
select * from "File" 

insert into "File"(fl_owner_id, fl_endedat, fl_changedat, fl_active, fl_name)
values(18, '2020-04-25', null, 'Y', 'Selfie')

insert into "File"(fl_owner_id, fl_endedat, fl_changedat, fl_active, fl_name)
values
	(9, '2010-08-12', null, 'Y', 'Documento'),
	(15, '1999-05-20', null, 'N', 'Georgina'),
	(20, '2015-07-08', null, 'N', 'Ficheiro'),
	(22, '1998-01-02', null, 'Y', 'Foto'),
	(10, '2001-06-27', null, 'Y', 'Ficheiro de Texto'),
	(18, '2011-07-21', null, 'N', 'Ficheiro mp3'),
	(16, '2014-09-30', null, 'N', 'Contrato de Trabalho'),
	(17, '2018-01-14', null, 'Y', 'Foto'),
	(14, '2008-10-25', null, 'Y', 'Contrato de Trabalho');




------------------- USER_MESSAGE DATA ---------------------------------------------------------------------------------------------------------
select * from "User_Message" 

insert into "User_Message"(um_receiver_id, um_ms_id)
values
	(16, 28),
	(17, 34),
	(10, 17),
	(12, 19),
	(14, 20),
	(9, 21),
	(15, 22),
	(16, 26),
	(11, 30),
	(8, 32);

------------------- GROUP_MESSAGE DATA ---------------------------------------------------------------------------------------------------------
select * from "Group_Message" 

insert into "Group_Message"(gm_gr_id, gm_ms_id)
values 
	(8, 18),
	(9, 23),
	(12, 24),
	(13, 25),
	(16, 27),
	(17, 29),
	(9, 31),
	(13, 33);

------------------- GROUP_USER DATA ---------------------------------------------------------------------------------------------------------
select * from "Group_User" 
order by (gu_gr_id)


insert into "Group_User"(gu_us_id, gu_gr_id)
values
	(15, 8),
	(16, 9),
	(9, 12),
	(9, 13),
	(16, 16),
	(11, 17),
	(8, 8),
	(10, 9),
	(11, 8),
	(11, 9),
	(10, 16),
	(15, 17),
	(10, 12),
	(10, 13);




