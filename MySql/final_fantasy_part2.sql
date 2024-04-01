CREATE SCHEMA `human_friends`;

CREATE TABLE pet (
	id INT AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(45),
    type VARCHAR(20),
	dateOfBirth  DATE,
	commands VARCHAR(100)
);

CREATE TABLE pack_animal (
	id INT AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(45),
    type VARCHAR(20),
	dateOfBirth  DATE,
	commands VARCHAR(100)
);

INSERT INTO pet (name, type, dateOfBirth, commands) 
VALUES
	('Fido', 'Dog', '2021-01-10', 'Sit, Stay, Fetch'),
    ('Whiskers', 'Cat', '2019-05-15', 'Sit, Pounce'),
    ('Hammy', 'Hamster', '2021-03-10', 'Roll, Hide'),
    ('Buddy', 'Dog', '2018-12-10', 'Sit, Paw, Bark'),
    ('Smudge', 'Cat', '2022-02-20',	'Sit, Pounce, Scratch'),
    ('Peanut', 'Hamster', '2021-08-01', 'Roll, Spin'),
    ('Bella', 'Dog', '2019-11-11', 'Sit, Stay, Roll'),
    ('Oliver', 'Cat', '2023-06-30',	'Meow, Scratch, Jump');

INSERT INTO pack_animal (name, type, dateOfBirth, commands) 
VALUES
	('Thunder', 'Horse', '2015-07-21', 'Trot, Canter, Gallop'),
    ('Sandy', 'Camel', '2023-11-03', 'Walk, Carry Load'),
    ('Eeyore', 'Donkey', '2017-09-18', 'Walk, Carry Load, Bray'),
    ('Storm', 'Horse', '2014-05-05', 'Trot, Canter'),
    ('Dune', 'Camel', '2018-12-12', 'Walk, Sit'),
    ('Burro', 'Donkey', '2023-01-23', 'Walk, Bray, Kick'),
    ('Blaze', 'Horse', '2016-02-29', 'Trot, Jump, Gallop'),
    ('Sahara', 'Camel', '2015-08-14', 'Walk, Run');

DELETE FROM pack_animal WHERE type = 'Camel';

CREATE TABLE animals_between_year_and_3_years (
	id INT AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(45),
    type VARCHAR(20),
	dateOfBirth  DATE,
	commands VARCHAR(100),
    age VARCHAR(50)
);

SELECT name, type, dateOfBirth, commands FROM (SELECT * FROM pack_animal UNION SELECT * FROM pet) as temp
WHERE DATEDIFF(CURDATE(), dateOfBirth) <= 1095;

INSERT INTO animals_between_year_and_3_years(name, type, dateOfBirth, commands)
SELECT * FROM (SELECT name, type, dateOfBirth, commands FROM (SELECT * FROM pack_animal UNION SELECT * FROM pet) as temp
WHERE DATEDIFF(CURDATE(), temp.dateOfBirth) <= 1095) as temp2;

DROP FUNCTION IF EXISTS age_converter;
DELIMITER $$
CREATE FUNCTION age_converter(date DATE)
	RETURNS VARCHAR(255) 
    DETERMINISTIC
BEGIN
	DECLARE result VARCHAR(255) DEFAULT '';
    DECLARE days INT DEFAULT 0;
    DECLARE days_in_year INT DEFAULT 365;
    DECLARE days_in_month INT DEFAULT 31;
    DECLARE temp INT DEFAULT 0;
    
	SET days = DATEDIFF(CURDATE(), date);

	SET temp = days / days_in_year;
	SET result = concat(temp, " years ");
	SET days = days % days_in_year;
     
	SET temp = days / days_in_month;
	SET result = concat(result, temp, " months"); 
      
	RETURN result;
      
  END $$
  DELIMITER ;

UPDATE animals_between_year_and_3_years
SET age = age_converter(dateOfBirth);

SELECT * FROM pack_animal UNION SELECT * FROM pet