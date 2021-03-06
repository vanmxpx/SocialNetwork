SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `shorty_test` DEFAULT CHARACTER SET utf8 ;
USE `shorty_test` ;

-- -----------------------------------------------------
-- Table `shorty_test`.`__EFMigrationsHistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`__EFMigrationsHistory` (
  `MigrationId` VARCHAR(95) NOT NULL,
  `ProductVersion` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `shorty_test`.`profile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`profile` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(32) NOT NULL,
  `Name` VARCHAR(32) NOT NULL,
  `LastName` VARCHAR(32) NOT NULL,
  `Gender` TINYINT(3) NOT NULL DEFAULT '2',
  `Location` VARCHAR(64) NULL DEFAULT NULL,
  `Age` TINYINT(3) UNSIGNED NULL DEFAULT NULL,
  `Photo` VARBINARY(8001) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  INDEX `idProfile_idx` (`Id` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 51
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `shorty_test`.`credential`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`credential` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(64) NOT NULL,
  `Password` VARCHAR(64) NOT NULL,
  `DateRegistration` DATETIME(6) NOT NULL,
  `ProfileRef` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC),
  UNIQUE INDEX `ProfileRef_UNIQUE` (`ProfileRef` ASC),
  CONSTRAINT `FK_credential_profile_ProfileRef`
    FOREIGN KEY (`ProfileRef`)
    REFERENCES `shorty_test`.`profile` (`Id`)
    ON DELETE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT =51
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `shorty_test`.`authorization`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`authorization` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `SystemStatus` VARCHAR(45) NOT NULL,
  `DatetimeStart` DATETIME(6) NOT NULL,
  `DatetimeRequest` DATETIME(6) NOT NULL,
  `CredentialRef` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC),
  INDEX `IdCredential_idx` (`CredentialRef` ASC),
  CONSTRAINT `FK_authorization_credential_CredentialRef`
    FOREIGN KEY (`CredentialRef`)
    REFERENCES `shorty_test`.`credential` (`Id`)
    ON DELETE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 101
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `shorty_test`.`followings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`followings` (
  `BloggerRef` INT(11) NOT NULL DEFAULT '0',
  `SubscriberRef` INT(11) NOT NULL,
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`),
  INDEX `idBlogger_idx` (`BloggerRef` ASC),
  INDEX `idSubscriber_idx` (`SubscriberRef` ASC),
  CONSTRAINT `FK_followings_profile_BloggerRef`
    FOREIGN KEY (`BloggerRef`)
    REFERENCES `shorty_test`.`profile` (`Id`)
    ON DELETE NO ACTION,
  CONSTRAINT `FK_followings_profile_SubscriberRef`
    FOREIGN KEY (`SubscriberRef`)
    REFERENCES `shorty_test`.`profile` (`Id`)
    ON DELETE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 103
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `shorty_test`.`post`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `shorty_test`.`post` (
  `Id` BIGINT(20) NOT NULL AUTO_INCREMENT,
  `Text` VARCHAR(256) NOT NULL,
  `Datetime` DATETIME NOT NULL,
  `ProfileRef` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `idProfileAuthor_idx` (`ProfileRef` ASC),
  CONSTRAINT `FK_post_profile_ProfileRef`
    FOREIGN KEY (`ProfileRef`)
    REFERENCES `shorty_test`.`profile` (`Id`)
    ON DELETE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 101
DEFAULT CHARACTER SET = utf8;

-- deleting table data if exists
TRUNCATE TABLE profile;
TRUNCATE TABLE credential;
TRUNCATE TABLE authorization;
TRUNCATE TABLE followings;
TRUNCATE TABLE post;

--insert test data
INSERT INTO `Profile` (`Id`,`Login`,`Name`,`LastName`) VALUES (1,"Vestibulum","Veronica","Baldwin"),(2,"nisi","Jared","Rasmussen"),(3,"nibh.","Jillian","Hayden"),(4,"Aliquam","Rigel","Burks"),(5,"Nullam","Owen","Emerson"),(6,"et","Bethany","Lloyd"),(7,"nunc","Leilani","Pena"),(8,"Nulla","Teegan","Todd"),(9,"ut","Ramona","Jensen"),(10,"Fusce","Jena","Shields");
INSERT INTO `Profile` (`Id`,`Login`,`Name`,`LastName`) VALUES (11,"lorem","Charity","Duran"),(12,"nostra,","Martena","Harding"),(13,"Quisque","Raja","Ruiz"),(14,"eleifend","Cheryl","Burgess"),(15,"Phasellus","Solomon","Sweet"),(16,"auctor,","Ulla","Stewart"),(17,"Curabitur","Reese","Pierce"),(18,"orci","Remedios","Hansen"),(19,"risus,","Kay","Holman"),(20,"per","Josiah","Barton");
INSERT INTO `Profile` (`Id`,`Login`,`Name`,`LastName`) VALUES (21,"rutrum","Curran","Pennington"),(22,"Etiam","Harper","Richards"),(23,"vitae","Tanya","Banks"),(24,"admin","Melvin","Wyatt"),(25,"netus","Aubrey","Moon"),(26,"egestas.","Yuli","Jackson"),(27,"lorem,","Emmanuel","Wise"),(28,"tristique","Aidan","Avery"),(29,"ipsum","Hammett","Howe"),(30,"ut,","Savannah","Delaney");
INSERT INTO `Profile` (`Id`,`Login`,`Name`,`LastName`) VALUES (31,"Sed","Galvin","Alexander"),(32,"nibh","Tallulah","Mcgee"),(33,"velit.","Leonard","Castro"),(34,"eleifend,","Jasmine","Baker"),(35,"Phasellus","Sarah","Mcconnell"),(36,"montes,","Zelda","Hays"),(37,"molestie","Mariko","Bright"),(38,"dolor.","Hilary","Burton"),(39,"ornare,","Meghan","Howell"),(40,"enim.","Timothy","Vinson");
INSERT INTO `Profile` (`Id`,`Login`,`Name`,`LastName`) VALUES (41,"iaculis","Kirk","Chapman"),(42,"pharetra.","Neve","Hendrix"),(43,"adipiscing","Velma","Bowers"),(44,"aliquet.","Ariel","Mcguire"),(45,"Aenean","Camden","Dillard"),(46,"vel","Cleo","Ferguson"),(47,"tempus","Sean","Padilla"),(48,"vestibulum","Rebekah","Mills"),(49,"arcu","Holmes","Mckay"),(50,"adipiscing,","Robert","Alford");

INSERT INTO `credential` (`Id`,`ProfileRef`,`Email`,`Password`,`DateRegistration`) VALUES (1,1,"rutrum.justo.Praesent@nec.net","mi","2018-05-16 16:59:28"),(2,2,"amet.luctus.vulputate@nec.org","vestibulum","2018-01-12 21:27:21"),(3,3,"ligula.Aenean.euismod@sem.edu","orci","2017-12-20 20:05:42"),(4,4,"nulla.Integer@nuncsitamet.com","Aenean","2017-09-02 18:03:18"),(5,5,"netus@orci.com","dictum.","2018-04-28 01:55:51"),(6,6,"dolor.Donec.fringilla@elit.edu","tortor.","2018-03-30 23:08:34"),(7,7,"eu.nibh@eteros.edu","et,","2017-08-27 06:34:46"),(8,8,"Integer.mollis.Integer@Praesentinterdum.ca","ipsum","2017-12-05 00:40:05"),(9,9,"lobortis@ipsum.co.uk","orci.","2017-11-22 13:01:10"),(10,10,"neque.pellentesque.massa@orciUt.net","velit.","2018-06-28 01:00:15");
INSERT INTO `credential` (`Id`,`ProfileRef`,`Email`,`Password`,`DateRegistration`) VALUES (11,11,"elit@egetmollislectus.com","Nam","2018-03-09 14:56:14"),(12,12,"ac@Phasellusataugue.com","orci.","2017-11-18 07:28:58"),(13,13,"id@tellus.co.uk","mattis.","2018-07-25 11:59:29"),(14,14,"convallis@estmauris.net","a,","2018-04-02 03:26:32"),(15,15,"dui.Fusce.diam@Integerinmagna.edu","ipsum","2018-07-04 10:00:18"),(16,16,"ut.dolor.dapibus@Nunc.com","aptent","2018-01-18 05:28:55"),(17,17,"sed@ipsumprimisin.co.uk","vitae,","2017-12-05 10:13:31"),(18,18,"Nunc.ut.erat@sit.co.uk","pede,","2018-04-22 12:44:26"),(19,19,"dolor@risusMorbi.net","scelerisque","2018-01-30 12:43:06"),(20,20,"lacinia@primisin.ca","convallis","2018-04-07 23:33:06");
INSERT INTO `credential` (`Id`,`ProfileRef`,`Email`,`Password`,`DateRegistration`) VALUES (21,21,"placerat.orci@hendreritDonecporttitor.edu","ornare.","2017-08-18 02:14:53"),(22,22,"mi.tempor@lectusa.edu","Nulla","2018-04-04 07:05:13"),(23,23,"magna@nequevenenatislacus.ca","mollis.","2018-04-25 03:18:39"),(24,24,"admin@gmail.com","12345678","2018-03-10 07:18:50"),(25,25,"ante.Vivamus.non@ami.net","imperdiet","2018-05-10 21:41:03"),(26,26,"Ut.tincidunt.vehicula@risusNuncac.com","tristique","2017-11-27 15:20:10"),(27,27,"magna.nec@enimgravida.ca","tempus","2018-06-06 05:02:24"),(28,28,"pede.Cum.sociis@Donec.co.uk","nunc","2018-07-20 18:12:22"),(29,29,"neque@Donec.ca","volutpat.","2018-07-02 20:07:58"),(30,30,"ac.mattis.velit@arcuiaculisenim.org","sed,","2018-07-17 02:18:34");
INSERT INTO `credential` (`Id`,`ProfileRef`,`Email`,`Password`,`DateRegistration`) VALUES (31,31,"pede@QuisquevariusNam.net","nunc","2018-01-17 15:43:23"),(32,32,"quis@dapibusrutrumjusto.com","Suspendisse","2018-05-06 10:07:52"),(33,33,"commodo.at@mattis.edu","a,","2017-11-24 16:23:50"),(34,34,"Nunc.mauris@enimnon.com","mauris,","2017-09-01 00:58:32"),(35,35,"Sed.auctor@Quisqueimperdiet.net","ultrices.","2018-04-12 14:54:52"),(36,36,"eget.varius@Suspendissealiquetsem.co.uk","sit","2018-05-06 13:32:33"),(37,37,"libero.Morbi.accumsan@Pellentesquetincidunttempus.edu","quis,","2017-10-12 17:02:15"),(38,38,"vitae.sodales@Maecenasmalesuadafringilla.net","congue,","2018-01-25 04:31:14"),(39,39,"elit.fermentum.risus@massaMaurisvestibulum.edu","at","2018-04-08 10:30:36"),(40,40,"pede.Cras.vulputate@diamDuis.edu","Vivamus","2018-07-20 20:24:32");
INSERT INTO `credential` (`Id`,`ProfileRef`,`Email`,`Password`,`DateRegistration`) VALUES (41,41,"In.mi.pede@Morbi.org","tempus","2018-03-20 04:39:59"),(42,42,"adipiscing.elit@sitamet.org","Morbi","2017-08-31 04:54:49"),(43,43,"ultricies@Nullamscelerisque.net","dolor,","2018-03-20 01:48:35"),(44,44,"velit@semperrutrum.com","dictum","2018-01-15 01:34:44"),(45,45,"justo.Proin.non@sitamet.com","pede.","2017-10-25 12:31:00"),(46,46,"elit.pharetra@aliquamiaculis.org","Nullam","2018-05-27 12:22:23"),(47,47,"semper.dui@etmalesuadafames.net","libero","2018-01-07 07:27:47"),(48,48,"quis.massa@feugiatplacerat.org","lacus.","2018-02-24 13:09:41"),(49,49,"Vestibulum.ut.eros@faucibusorci.co.uk","Duis","2018-04-07 14:19:17"),(50,50,"Nulla.semper@purusNullamscelerisque.net","dictum","2018-05-30 11:47:44");

INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (1,30,"vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum","2019-08-25 22:20:39"),(2,10,"id risus quis diam luctus lobortis. Class aptent taciti sociosqu","2019-08-25 00:44:57"),(3,27,"Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus.","2019-08-17 21:13:45"),(4,13,"odio. Nam interdum enim non nisi. Aenean eget metus. In","2019-08-16 21:00:04"),(5,33,"Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis in faucibus","2019-08-24 09:58:51"),(6,40,"Fusce diam nunc, ullamcorper eu, euismod ac, fermentum vel, mauris.","2019-08-08 16:16:53"),(7,39,"nisi. Cum sociis natoque penatibus et magnis dis parturient montes,","2019-08-11 20:51:49"),(8,39,"imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit,","2019-08-27 11:57:34"),(9,28,"faucibus lectus, a sollicitudin orci sem eget massa. Suspendisse eleifend.","2019-08-25 10:57:17"),(10,32,"amet, consectetuer adipiscing elit. Aliquam auctor, velit eget laoreet posuere,","2019-08-20 02:45:55");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (11,44,"dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a","2019-08-19 17:00:14"),(12,38,"mollis dui, in sodales elit erat vitae risus. Duis a","2019-08-26 10:56:46"),(13,34,"mauris a nunc. In at pede. Cras vulputate velit eu","2019-08-16 22:18:01"),(14,28,"tempor, est ac mattis semper, dui lectus rutrum urna, nec","2019-08-21 06:05:52"),(15,49,"auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris","2019-08-13 16:45:00"),(16,13,"Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris","2019-08-26 22:20:36"),(17,14,"mauris, rhoncus id, mollis nec, cursus a, enim. Suspendisse aliquet,","2019-08-12 04:22:18"),(18,28,"arcu. Vestibulum ante ipsum primis in faucibus orci luctus et","2019-08-06 02:04:52"),(19,12,"Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero. Integer","2019-08-20 06:14:53"),(20,3,"vulputate dui, nec tempus mauris erat eget ipsum. Suspendisse sagittis.","2019-08-16 21:50:38");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (21,9,"adipiscing elit. Curabitur sed tortor. Integer aliquam adipiscing lacus. Ut","2019-08-10 18:51:11"),(22,45,"aliquet odio. Etiam ligula tortor, dictum eu, placerat eget, venenatis","2019-08-06 16:55:18"),(23,41,"vitae risus. Duis a mi fringilla mi lacinia mattis. Integer","2019-08-16 16:51:14"),(24,37,"vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim.","2019-08-19 15:52:32"),(25,16,"parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor.","2019-08-22 11:13:19"),(26,30,"Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat","2019-08-23 23:07:35"),(27,48,"dictum eu, placerat eget, venenatis a, magna. Lorem ipsum dolor","2019-08-28 13:15:31"),(28,8,"Vivamus non lorem vitae odio sagittis semper. Nam tempor diam","2019-08-26 14:56:44"),(29,22,"blandit enim consequat purus. Maecenas libero est, congue a, aliquet","2019-08-21 09:16:56"),(30,1,"tempor lorem, eget mollis lectus pede et risus. Quisque libero","2019-08-16 13:32:31");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (31,47,"mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean","2019-08-07 19:04:39"),(32,47,"at, nisi. Cum sociis natoque penatibus et magnis dis parturient","2019-08-07 06:40:32"),(33,43,"sapien. Aenean massa. Integer vitae nibh. Donec est mauris, rhoncus","2019-08-14 16:02:55"),(34,9,"et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien,","2019-08-13 19:02:28"),(35,11,"imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus.","2019-08-24 04:37:16"),(36,34,"Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero.","2019-08-09 12:13:27"),(37,2,"posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede","2019-08-22 19:47:06"),(38,16,"nisi nibh lacinia orci, consectetuer euismod est arcu ac orci.","2019-08-18 17:39:12"),(39,13,"Phasellus dapibus quam quis diam. Pellentesque habitant morbi tristique senectus","2019-08-19 15:16:45"),(40,7,"primis in faucibus orci luctus et ultrices posuere cubilia Curae;","2019-08-23 04:20:35");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (41,25,"pulvinar arcu et pede. Nunc sed orci lobortis augue scelerisque","2019-08-16 17:57:31"),(42,1,"aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu","2019-08-10 15:07:30"),(43,29,"ipsum primis in faucibus orci luctus et ultrices posuere cubilia","2019-08-29 06:58:22"),(44,31,"iaculis enim, sit amet ornare lectus justo eu arcu. Morbi","2019-08-17 18:57:35"),(45,7,"ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor","2019-08-25 17:33:14"),(46,47,"vel lectus. Cum sociis natoque penatibus et magnis dis parturient","2019-08-07 00:52:26"),(47,8,"Sed neque. Sed eget lacus. Mauris non dui nec urna","2019-08-10 11:13:00"),(48,20,"Aliquam ultrices iaculis odio. Nam interdum enim non nisi. Aenean","2019-08-28 14:09:41"),(49,8,"Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis","2019-08-28 11:24:17"),(50,22,"lobortis ultrices. Vivamus rhoncus. Donec est. Nunc ullamcorper, velit in","2019-08-29 05:42:30");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (51,14,"et ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat","2019-08-09 10:30:58"),(52,42,"egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor","2019-08-19 21:35:49"),(53,4,"non, bibendum sed, est. Nunc laoreet lectus quis massa. Mauris","2019-08-30 09:04:20"),(54,35,"ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce diam","2019-08-16 18:26:25"),(55,23,"est tempor bibendum. Donec felis orci, adipiscing non, luctus sit","2019-08-09 17:21:51"),(56,37,"magna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam","2019-08-17 02:58:41"),(57,44,"libero nec ligula consectetuer rhoncus. Nullam velit dui, semper et,","2019-08-15 08:12:38"),(58,27,"Donec feugiat metus sit amet ante. Vivamus non lorem vitae","2019-08-20 17:13:02"),(59,24,"eros turpis non enim. Mauris quis turpis vitae purus gravida","2019-08-22 05:59:31"),(60,23,"adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor","2019-08-13 20:03:25");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (61,29,"ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet","2019-08-18 08:33:28"),(62,26,"arcu eu odio tristique pharetra. Quisque ac libero nec ligula","2019-08-26 13:24:57"),(63,1,"nunc id enim. Curabitur massa. Vestibulum accumsan neque et nunc.","2019-08-14 10:59:15"),(64,33,"ac mattis ornare, lectus ante dictum mi, ac mattis velit","2019-08-26 10:19:09"),(65,21,"nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed","2019-08-16 10:28:53"),(66,26,"mattis ornare, lectus ante dictum mi, ac mattis velit justo","2019-08-17 15:35:39"),(67,34,"Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac","2019-08-12 18:58:45"),(68,22,"quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu","2019-08-13 08:47:10"),(69,25,"Donec est mauris, rhoncus id, mollis nec, cursus a, enim.","2019-08-14 12:22:39"),(70,48,"convallis, ante lectus convallis est, vitae sodales nisi magna sed","2019-08-13 00:57:38");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (71,50,"Aliquam nisl. Nulla eu neque pellentesque massa lobortis ultrices. Vivamus","2019-08-19 08:31:38"),(72,27,"lorem ipsum sodales purus, in molestie tortor nibh sit amet","2019-08-17 20:10:29"),(73,8,"Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu","2019-08-18 18:29:07"),(74,14,"est arcu ac orci. Ut semper pretium neque. Morbi quis","2019-08-08 05:28:31"),(75,39,"arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut","2019-08-23 14:40:05"),(76,44,"non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis","2019-08-12 02:01:38"),(77,4,"posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede","2019-08-26 07:20:31"),(78,15,"faucibus leo, in lobortis tellus justo sit amet nulla. Donec","2019-08-11 19:04:32"),(79,47,"Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet","2019-08-16 02:58:47"),(80,34,"Aliquam adipiscing lobortis risus. In mi pede, nonummy ut, molestie","2019-08-18 23:03:40");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (81,32,"elit, pellentesque a, facilisis non, bibendum sed, est. Nunc laoreet","2019-08-17 13:09:20"),(82,5,"lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet","2019-08-09 21:29:02"),(83,8,"Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis","2019-08-06 10:53:25"),(84,40,"urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim.","2019-08-28 05:36:32"),(85,42,"tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu neque","2019-08-06 03:53:53"),(86,42,"sagittis augue, eu tempor erat neque non quam. Pellentesque habitant","2019-08-09 18:08:42"),(87,5,"lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac","2019-08-24 23:13:14"),(88,34,"dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus","2019-08-31 06:40:09"),(89,23,"Nunc pulvinar arcu et pede. Nunc sed orci lobortis augue","2019-08-11 08:13:40"),(90,19,"Nunc ut erat. Sed nunc est, mollis non, cursus non,","2019-08-20 04:32:42");
INSERT INTO `post` (`Id`,`ProfileRef`,`Text`,`DateTime`) VALUES (91,34,"vestibulum lorem, sit amet ultricies sem magna nec quam. Curabitur","2019-08-22 19:33:05"),(92,28,"vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros","2019-08-12 05:48:35"),(93,24,"accumsan convallis, ante lectus convallis est, vitae sodales nisi magna","2019-08-16 21:18:25"),(94,30,"vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu.","2019-08-08 18:00:31"),(95,33,"est, vitae sodales nisi magna sed dui. Fusce aliquam, enim","2019-08-17 14:53:49"),(96,3,"volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla. Integer","2019-08-19 06:40:52"),(97,4,"purus gravida sagittis. Duis gravida. Praesent eu nulla at sem","2019-08-08 20:43:27"),(98,50,"Vestibulum ante ipsum primis in faucibus orci luctus et ultrices","2019-08-26 10:53:49"),(99,29,"scelerisque sed, sapien. Nunc pulvinar arcu et pede. Nunc sed","2019-08-22 08:23:53"),(100,28,"ac metus vitae velit egestas lacinia. Sed congue, elit sed","2019-08-25 14:35:19");

INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (28,6),(9,25),(14,31),(14,38),(20,39),(20,27),(19,12),(38,35),(45,24),(46,29);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (32,14),(47,8),(38,34),(37,29),(11,7),(31,50),(39,24),(41,36),(8,42),(14,39);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (2,43),(20,29),(16,49),(32,29),(21,39),(15,5),(30,7),(40,22),(19,10),(46,10);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (22,18),(42,34),(11,11),(31,30),(49,13),(8,35),(22,21),(15,25),(17,33),(12,25);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (27,47),(5,18),(9,31),(17,38),(6,21),(46,9),(10,6),(33,42),(50,4),(3,48);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (21,5),(17,49),(1,31),(13,45),(25,32),(38,22),(1,21),(28,4),(34,18),(24,9);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (24,22),(18,31),(32,34),(50,50),(37,48),(48,18),(37,7),(12,6),(40,50),(13,4);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (48,27),(26,27),(35,43),(24,23),(25,22),(42,7),(42,48),(10,15),(10,26),(23,48);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (24,31),(35,28),(47,5),(45,5),(4,13),(18,44),(43,2),(17,6),(12,24),(10,27);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (36,21),(22,43),(42,30),(32,28),(33,38),(20,16),(24,27),(40,30),(8,8),(38,32);
INSERT INTO `followings` (`BloggerRef`,`SubscriberRef`) VALUES (1,2),(2,1);

INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (1,5,1,"2019-08-08 19:02:41","2019-09-09 09:30:44"),(2,13,1,"2019-08-18 16:34:44","2019-09-10 10:16:46"),(3,14,0,"2019-08-15 02:08:40","2019-09-30 19:00:57"),(4,44,1,"2019-08-21 15:58:14","2019-09-09 14:29:07"),(5,1,0,"2019-08-19 03:00:34","2019-09-06 03:14:53"),(6,3,0,"2019-08-07 10:24:50","2019-09-17 10:06:10"),(7,25,1,"2019-08-12 01:41:18","2019-09-29 08:39:14"),(8,10,0,"2019-08-14 16:59:29","2019-09-12 15:53:18"),(9,43,0,"2019-08-16 13:18:04","2019-09-12 05:33:25"),(10,11,1,"2019-08-20 10:29:38","2019-09-14 07:18:03");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (11,50,1,"2019-08-25 08:04:48","2019-09-05 21:06:38"),(12,16,1,"2019-08-26 04:01:34","2019-09-11 19:08:47"),(13,40,0,"2019-08-07 12:39:01","2019-09-05 05:40:45"),(14,38,1,"2019-08-25 16:16:57","2019-09-10 05:23:24"),(15,41,1,"2019-08-29 12:22:26","2019-09-20 11:13:03"),(16,19,1,"2019-08-22 22:30:27","2019-09-09 17:33:24"),(17,26,0,"2019-08-23 03:35:12","2019-09-11 13:41:50"),(18,14,1,"2019-08-09 10:44:43","2019-09-01 09:44:00"),(19,36,0,"2019-08-10 05:17:40","2019-09-02 08:35:34"),(20,43,1,"2019-08-25 22:26:01","2019-09-21 17:39:26");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (21,9,1,"2019-08-07 11:46:20","2019-09-26 04:32:53"),(22,49,0,"2019-08-22 13:48:39","2019-09-08 11:33:08"),(23,6,1,"2019-08-08 14:30:09","2019-09-08 20:26:00"),(24,22,1,"2019-08-20 20:04:18","2019-09-07 03:42:13"),(25,17,0,"2019-08-23 23:03:24","2019-09-09 21:14:34"),(26,41,1,"2019-08-25 19:52:11","2019-09-21 14:59:45"),(27,22,0,"2019-08-16 17:43:44","2019-09-16 06:59:06"),(28,25,0,"2019-08-20 15:19:00","2019-09-20 06:31:55"),(29,45,0,"2019-08-29 21:39:21","2019-09-03 19:08:34"),(30,31,0,"2019-08-30 15:37:01","2019-09-04 13:06:56");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (31,5,0,"2019-08-13 20:12:46","2019-09-30 20:01:21"),(32,25,1,"2019-08-13 12:43:44","2019-09-15 19:48:02"),(33,33,0,"2019-08-14 08:51:35","2019-09-18 15:12:28"),(34,44,1,"2019-08-15 02:46:42","2019-09-30 09:33:51"),(35,31,0,"2019-08-30 07:13:33","2019-09-24 18:28:47"),(36,49,1,"2019-08-23 01:01:58","2019-09-09 19:25:38"),(37,33,0,"2019-08-11 02:19:06","2019-09-09 00:24:46"),(38,22,0,"2019-08-25 18:25:13","2019-09-15 01:01:10"),(39,46,1,"2019-08-18 08:29:37","2019-09-06 09:31:25"),(40,43,0,"2019-08-28 01:12:11","2019-09-17 13:01:58");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (41,2,0,"2019-08-07 00:20:15","2019-09-28 09:18:36"),(42,17,0,"2019-08-08 03:54:42","2019-09-13 06:45:49"),(43,43,0,"2019-08-18 01:29:33","2019-09-04 18:04:49"),(44,1,1,"2019-08-12 01:40:07","2019-09-18 21:41:35"),(45,26,1,"2019-08-29 09:29:01","2019-09-29 11:53:43"),(46,32,1,"2019-08-23 08:51:22","2019-09-16 00:08:52"),(47,6,1,"2019-08-22 16:30:55","2019-09-20 15:21:28"),(48,46,1,"2019-08-23 14:27:49","2019-09-02 21:53:50"),(49,37,0,"2019-08-24 05:25:13","2019-09-22 19:15:05"),(50,5,0,"2019-08-30 10:45:19","2019-09-03 19:31:12");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (51,25,0,"2019-08-31 18:54:56","2019-09-30 11:56:59"),(52,9,1,"2019-08-06 18:42:38","2019-09-02 06:50:12"),(53,24,0,"2019-08-26 22:49:36","2019-09-02 05:17:58"),(54,7,1,"2019-08-29 13:08:40","2019-09-25 07:24:50"),(55,8,1,"2019-08-08 19:24:44","2019-09-07 20:50:22"),(56,39,1,"2019-08-06 23:31:04","2019-09-29 06:13:42"),(57,32,1,"2019-08-16 21:08:02","2019-09-11 05:08:07"),(58,43,1,"2019-08-30 12:28:17","2019-09-23 01:32:04"),(59,10,0,"2019-08-15 07:23:30","2019-09-26 07:23:39"),(60,44,0,"2019-08-12 15:10:51","2019-09-10 14:01:41");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (61,48,0,"2019-08-22 22:55:33","2019-09-23 05:12:22"),(62,33,1,"2019-08-08 01:49:32","2019-09-24 01:42:40"),(63,28,1,"2019-08-13 02:30:55","2019-09-06 12:35:04"),(64,9,0,"2019-08-27 12:17:02","2019-09-07 13:45:44"),(65,47,1,"2019-08-06 14:00:26","2019-09-06 06:25:13"),(66,50,1,"2019-08-25 15:17:35","2019-09-14 10:03:19"),(67,10,1,"2019-08-06 19:22:57","2019-09-25 20:28:31"),(68,39,1,"2019-08-06 16:31:23","2019-09-20 11:31:52"),(69,39,0,"2019-08-15 20:24:00","2019-09-08 07:39:14"),(70,43,0,"2019-08-30 12:44:33","2019-09-10 03:37:01");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (71,25,1,"2019-08-20 07:26:56","2019-09-20 01:36:57"),(72,49,0,"2019-08-16 00:09:29","2019-09-12 15:19:53"),(73,45,1,"2019-08-07 11:12:54","2019-09-10 14:33:06"),(74,41,1,"2019-08-07 14:03:01","2019-09-08 00:52:13"),(75,8,0,"2019-08-17 10:04:33","2019-09-06 13:19:52"),(76,25,0,"2019-08-28 04:19:14","2019-09-02 00:59:32"),(77,30,0,"2019-08-24 15:48:53","2019-09-19 05:27:42"),(78,24,1,"2019-08-16 19:09:04","2019-09-28 21:27:39"),(79,21,1,"2019-08-21 17:02:37","2019-09-21 15:12:38"),(80,19,1,"2019-08-27 02:08:14","2019-09-11 06:40:50");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (81,43,1,"2019-08-17 18:23:39","2019-09-14 23:15:02"),(82,42,1,"2019-08-12 03:54:25","2019-09-24 10:20:56"),(83,4,0,"2019-08-30 21:00:06","2019-09-17 19:18:08"),(84,48,1,"2019-08-12 03:39:48","2019-09-08 17:28:18"),(85,42,1,"2019-08-14 04:13:11","2019-09-08 09:16:27"),(86,29,0,"2019-08-27 11:49:41","2019-09-05 16:44:43"),(87,18,1,"2019-08-07 18:40:48","2019-09-26 14:56:52"),(88,48,0,"2019-08-29 22:16:47","2019-09-08 03:35:44"),(89,31,0,"2019-08-18 05:05:02","2019-09-14 12:49:35"),(90,41,0,"2019-08-22 03:59:30","2019-09-25 01:12:07");
INSERT INTO `authorization` (`Id`,`CredentialRef`,`SystemStatus`,`DatetimeStart`,`DatetimeRequest`) VALUES (91,35,1,"2019-08-16 23:32:47","2019-09-03 16:17:08"),(92,38,1,"2019-08-29 05:41:23","2019-09-30 13:19:38"),(93,36,0,"2019-08-31 19:10:51","2019-09-28 21:25:56"),(94,40,0,"2019-08-11 16:20:43","2019-09-30 18:43:14"),(95,25,1,"2019-08-07 19:49:49","2019-09-25 02:09:35"),(96,50,1,"2019-08-27 08:22:37","2019-09-04 12:07:56"),(97,25,1,"2019-08-27 06:14:37","2019-09-15 07:11:59"),(98,6,1,"2019-08-19 07:42:53","2019-09-28 00:53:49"),(99,32,0,"2019-08-06 23:59:36","2019-09-22 09:00:16"),(100,22,0,"2019-08-18 18:39:27","2019-09-30 08:29:19");


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
