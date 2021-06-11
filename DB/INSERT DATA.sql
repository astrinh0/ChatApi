------------------- USER DATA ---------------------------------------------------------------------------------------------------------
insert into "User" (us_name, us_email, us_active, us_role, us_changedat, us_username, us_password)
values
	('Candido Miquelino', 'candido@gmail.com', 'Y', 'Admin', null, 'candidoAdmin', '12345'),
	('Emanuel Carvalho', 'emanuel@gmail.com', 'Y', 'User', null, 'emanuelUser', '12345'),
	('João Veloso', 'joao@gmail.com', 'Y', 'Admin', null, 'joaoAdmin', '12345'),
	('Joel Martins', 'joel@gmail.com', 'Y', 'User', null, 'joelUser', '12345'),
	('David Ramos', 'david@gmail.com', 'Y', 'User', null, 'davidUser', '12345'),
	('João Gomes', 'jgomes@gmail.com', 'Y', 'User', null, 'joaoUser', '12345'),
	('Ricardo Carvalho', 'ricardo@gmail.com', 'Y', 'Admin', null, 'ricardoAdmin', '12345'),
	('Cristiano Ronaldo', 'cristiano@gmail.com', 'Y', 'Admin', null, 'cristianoAdmin', '12345'),
	('Wilson Manafá', 'wilson@gmail.com', 'Y', 'User', null, 'wilsonUser', '12345'),
	('Mehdi Taremi', 'mehdi@gmail.com', 'Y', 'Admin', null, 'mehdiAdmin', '12345'),
	('Moussa Marega', 'moussa@gmail.com', 'N', 'Admin', null, 'moussaAdmin', '12345'),
	('Rúben Dias', 'ruben@gmail.com', 'N', 'User', null, 'rubenUser', '12345'),
	('Nico Otamendi', 'nico@gmail.com', 'N', 'Admin', null, 'nicoAdmin', '12345'),
	('Tomo Sokota', 'tomo@gmail.com', 'N', 'User', null, 'tomoUser', '12345'),
	('Carlos Secretário', 'carlos@gmail.com', 'N', 'User', null, 'carlosUser', '12345');

 
------------------- GROUP DATA ---------------------------------------------------------------------------------------------------------
insert into "Group" (gr_type, gr_owner, gr_changedat, gr_active, gr_name)
values
	('C', 9, null, 'Y', 'Lord Manafá Channel'),
	('G', 8, null, 'Y', 'CR7 Group'),
	('G', 3, null, 'N', 'João Veloso Group'),
	('C', 2, null, 'N', 'Emanuel Carvalho Channel'),
	('G', 4, null, 'Y', 'Joel Martins Group'),
	('C', 1, null, 'Y', 'Candido Miquelino Channel'),
	('G', 5, null, 'N', 'David Ramos Group'),
	('C', 6, null, 'N', 'João Gomes Channel'),
	('G', 10, null, 'Y', 'Mehdi Taremi Group'),
	('C', 7, null, 'Y', 'Ricardo Carvalho Channel');


 



------------------- MESSAGE DATA ---------------------------------------------------------------------------------------------------------

insert into "Message" (ms_message, ms_sender_id, ms_changedat, ms_active, ms_readed)
values
	('Olá, tudo bem?', 8, null, 'Y', 'N'),
	('Tenho reunião às 18h', 3, null, 'Y', 'Y'),
	('Não te esqueças da chave', 2, null, 'Y', 'N'),
	('Vou agora para Braga', 5, null, 'Y', 'Y'),
	('Sabes a que horas vens?', 9, null, 'N', 'N'),
	('Já viste as notas?', 7, null, 'N', 'Y'),
	('Fiz um bom jogo hoje', 10, null, 'N', 'N'),
	('Fui agora à faculdade', 1, null, 'N', 'Y'),
	('Vou para o trabalho, entretanto..', 8, null, 'Y', 'N'),
	('Já apresentaste o relatório?', 3, null, 'Y', 'Y'),
	('Hoje está imenso calor para treinar', 9, null, 'Y', 'N'),
	('Saiu nos o Vilafranquense para a Taça', 10, null, 'Y', 'Y'),
	('Esta aplicação até me parece bastante interessante', 6, null, 'N', 'N'),
	('Não te preocupes, devo chegar entretanto.', 5, null, 'N', 'Y'),
	('Vamos ver como corre', 9, null, 'Y', 'N'),
	('Reparaste na mudança de tempo?', 4, null, 'Y', 'Y'),
	('Vou agora ao supermercado', 2, null, 'Y', 'N'),
	('Ok.', 10, null, 'Y', 'Y');

 

------------------- FILE DATA ---------------------------------------------------------------------------------------------------------
 



insert into "File"(fl_owner_id, fl_endedat, fl_changedat, fl_active, fl_name)
values
	(11, '2020-04-25', null, 'Y', 'Selfie')
	(2, '2010-08-12', null, 'Y', 'Documento'),
	(8, '1999-05-20', null, 'N', 'Georgina'),
	(13, '2015-07-08', null, 'N', 'Ficheiro'),
	(15, '1998-01-02', null, 'Y', 'Foto'),
	(3, '2001-06-27', null, 'Y', 'Ficheiro de Texto'),
	(11, '2011-07-21', null, 'N', 'Ficheiro mp3'),
	(9, '2014-09-30', null, 'N', 'Contrato de Trabalho'),
	(10, '2018-01-14', null, 'Y', 'Foto'),
	(7, '2008-10-25', null, 'Y', 'Contrato de Trabalho');




------------------- USER_MESSAGE DATA ---------------------------------------------------------------------------------------------------------
 

insert into "User_Message"(um_receiver_id, um_ms_id)
values
	(9, 12),
	(10, 18),
	(3, 1),
	(5, 3),
	(7, 4),
	(2, 5),
	(8, 6),
	(9, 10),
	(4, 14),
	(1, 16);

 
------------------- GROUP_MESSAGE DATA ---------------------------------------------------------------------------------------------------------

insert into "Group_Message"(gm_gr_id, gm_ms_id)
values 
	(1, 2),
	(2, 7),
	(5, 8),
	(6, 9),
	(9, 11),
	(10, 13),
	(2, 15),
	(7, 13);


------------------- GROUP_USER DATA ---------------------------------------------------------------------------------------------------------

insert into "Group_User"(gu_us_id, gu_gr_id)
values
	(1, 8),
	(2, 9),
	(5, 2),
	(6, 2),
	(9, 9),
	(10, 4),
	(1, 1),
	(2, 3),
	(1, 4),
	(2, 4),
	(9, 3),
	(10, 8),
	(5, 3),
	(6, 3);

