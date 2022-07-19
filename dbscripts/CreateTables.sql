
CREATE SEQUENCE IF NOT EXISTS airline_company_id_seq
	INCREMENT 1
	MINVALUE 0
	NO MAXVALUE
	START WITH 0;

CREATE TABLE IF NOT EXISTS "airline_company" (
	"id" INTEGER NOT NULL DEFAULT nextval('airline_company_id_seq'::regclass),
	"name" VARCHAR NOT NULL,
	"name_en" VARCHAR NOT NULL,
	"icao_code" VARCHAR NOT NULL,
	"iata_code" VARCHAR NOT NULL,
	"rf_code" VARCHAR NOT NULL,
	"country" VARCHAR NOT NULL,
	PRIMARY KEY ("id")
);

insert into "airline_company" values (
	1, 'АО "Авиакомпания "Азимут""', 'Azimuth', 
	'AZO', 'A4', 'А4', 'Россия');
	
insert into "airline_company" values (
	2, 'АО "Авиакомпания "Икар""', 'Ikar', 
	'KAR', 'EO', 'АЬ', 'Россия');
	
insert into "airline_company" values (
	3, 'АО "Авиакомпания "Россия""', 'Rossiya', 
	'SDM', 'FV', 'ПЛ', 'Россия');
	
insert into "airline_company" values (
	4, 'АО "Авиакомпания "Сибирь""', 'S7', 
	'SBI', 'S7', 'С7', 'Россия');
	
insert into "airline_company" values (
	5, 'АО "Авиакомпания "Якутия""', 'Yakutia', 
	'SYL', 'R3', 'ЯК', 'Россия');
	
insert into "airline_company" values (
	6, 'АО "Авиакомпания АЛРОСА', 'Alrosa', 
	'DRU', '6R', 'ЯМ', 'Россия');
	
insert into "airline_company" values (
	7, 'АО "АК НордСтар"', 'NordStar', 
	'TYA', 'Y7', 'ТИ', 'Россия');
	
insert into "airline_company" values (
	8, 'АО "АК Смартавиа"', 'Smartavia', 
	'AUL', '5N', '5Н', 'Россия');
	
insert into "airline_company" values (
	9, 'АО "ИрАэро"', 'Iraero', 
	'IAE', 'IO', 'РД', 'Россия');
	
insert into "airline_company" values (
	10, 'АО "Ред Вингс"', 'Red Wings', 
	'RWZ', 'WZ', 'ИН', 'Россия');
	
insert into "airline_company" values (
	11, 'ОАО АК "Уральские авиалинии"', 'Ural Airlines', 
	'SVR', 'U6', 'У6', 'Россия');
	
insert into "airline_company" values (
	12, 'ООО "Северный Ветер', 'Nordwind', 
	'NWS', 'N4', 'КЛ', 'Россия');
	
insert into "airline_company" values (
	13, 'ПАО "Авиакомпания "Ютэйр""', 'UTair', 
	'UTA', 'UT', 'ЮТ', 'Россия');
	
insert into "airline_company" values (
	14, 'ПАО "Аэрофлот"', 'Aeroflot', 
	'AFL', 'SU', 'СУ', 'Россия');
	
insert into "airline_company" values (
	15, 'АО "Авиакомпания «Ижавиа»"', 'Izhavia', 
	'IZA', 'I8', 'ИЖ', 'Россия');

CREATE TABLE IF NOT EXISTS data_all
(
    operation_id bigint,
    type character varying COLLATE pg_catalog."default",
    "time" timestamp without time zone,
    place character varying COLLATE pg_catalog."default",
    sender character varying COLLATE pg_catalog."default",
    transaction_time timestamp with time zone,
    validation_status character varying COLLATE pg_catalog."default",
    operation_time_timezone smallint,
    passenger_id bigint,
    surname character varying COLLATE pg_catalog."default",
    name character varying COLLATE pg_catalog."default",
    patronymic character varying COLLATE pg_catalog."default",
    birthdate character varying COLLATE pg_catalog."default",
    gender_id numeric(1,0),
    passenger_document_id bigint,
    passenger_document_type character varying COLLATE pg_catalog."default",
    passenger_document_number character varying COLLATE pg_catalog."default",
    passenger_document_disabled_number character varying COLLATE pg_catalog."default",
    passenger_document_large_number character varying COLLATE pg_catalog."default",
    passenger_type_id numeric(2,0),
    passenger_type_name character varying COLLATE pg_catalog."default",
    passenger_type_type character varying COLLATE pg_catalog."default",
    ra_category character varying COLLATE pg_catalog."default",
    description character varying COLLATE pg_catalog."default",
    is_quota boolean,
    ticket_id bigint,
    ticket_number character varying COLLATE pg_catalog."default",
    ticket_type numeric(1,0),
    airline_route_id bigint,
    airline_code character varying COLLATE pg_catalog."default",
    depart_place character varying COLLATE pg_catalog."default",
    depart_datetime timestamp without time zone,
    arrive_place character varying COLLATE pg_catalog."default",
    arrive_datetime timestamp without time zone,
    pnr_id character varying COLLATE pg_catalog."default",
    operating_airline_code character varying COLLATE pg_catalog."default",
    depart_datetime_timezone smallint,
    arrive_datetime_timezone smallint,
    city_from_code character varying COLLATE pg_catalog."default",
    city_from_name character varying COLLATE pg_catalog."default",
    airport_from_icao_code character varying COLLATE pg_catalog."default",
    airport_from_rf_code character varying COLLATE pg_catalog."default",
    airport_from_name character varying COLLATE pg_catalog."default",
    city_to_code character varying COLLATE pg_catalog."default",
    city_to_name character varying COLLATE pg_catalog."default",
    airport_to_icao_code character varying COLLATE pg_catalog."default",
    airport_to_rf_code character varying COLLATE pg_catalog."default",
    airport_to_name character varying COLLATE pg_catalog."default",
    flight_nums text COLLATE pg_catalog."default",
    fare_code character varying COLLATE pg_catalog."default",
    fare_price integer
);

insert into data_all values (
	104327, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:11:23.935504+00', 'invalid_operation_time', 
	-3,25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС',
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73605, '5552139254232', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO',
	'2022-02-23 08:25:00', 'THALSZ', '', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ',
	'Шереметьево', '"SU1701, SU1711"', 'PZZSOC',740000), (
	104310, 'issued', '2022-04-23 00:25:00', 'AVIA CENTER LLC','', '2022-03-11 07:57:35.700013+00', '', 0, 30695, 'Ivanov', 'Ivan',
	'Ivanovich', '2015-08-16', 0, 30703, '04', '2215123123', 'MSE-2009N1065334', '', 8, 'ребенок инвалид от 0-12 лет', 'invalid_child',
	'ИНВ-PБ', 'Ребенок инвалид от 0-12 лет с предоставлением места', true, 73592, '67A2183740555', 1, 1911, 'SU', 'VVO', '2022-05-23 03:45:00',
	'SVO', '2022-05-23 08:25:00', 'THALSZ', 'FV', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE',
	'ШРМ', 'Шереметьево', 'SU1710(FV6290)', 'PZZSOC', 740000), (
	104312, 'issued', '2022-04-23 00:25:00', 'AVIA CENTER LLC', '', '2022-03-11 08:01:31.201693+00', '', 0, 30695, 'Ivanov', 'Ivan', 
	'Ivanovich', '2015-08-16', 0, 30703, '04', '2215123123', 'MSE-2009N1065334', '', 8, 'ребенок инвалид от 0-12 лет', 'invalid_child',
	'ИНВ-PБ', 'Ребенок инвалид от 0-12 лет с предоставлением места', true, 73594, '67A2183740556', 1, 1911, 'SU', 'VVO', '2022-05-23 03:45:00',
	'SVO', '2022-05-23 08:25:00', 'THALSZ', 'FV', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE',
	'ШРМ', 'Шереметьево', 'SU1710(FV6290)', 'PZZSOC', 740000), (
	104163, 'issued', '2022-01-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-02 14:34:08.383779+00', '', 0, 25688, 'Ivanov', 
	'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 3, 'молодежь', 'youth', 'МЛД', 'Гражданин в возрасте от 12 до 23 лет',
	true, 73471, '5552139254239', 1, 1852, 'SU', 'SVO', '2022-03-01 16:10:00', 'VVO', '2022-03-02 07:40:00', 'THALSZ', '', 0, 0, 'MOW', 
	'Москва', 'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'SU1700', 'PZZSOC', 740000), (
	104163, 'issued', '2022-01-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-02 14:34:08.383779+00', '', 0, 25688, 'Ivanov', 
	'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 3, 'молодежь', 'youth', 'МЛД', 'Гражданин в возрасте от 12 до 23 лет',
	true, 73471, '5552139254239', 1, 1851, 'SU', 'VVO', '2022-02-23 09:20:00', 'SVO', '2022-02-23 11:25:00', 'THALSZ', '', 0, 0, 'VVO', 
	'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1505"', 'PZZSOC', 740000), (
	104210, 'issued', '2022-02-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-04 09:15:06.720005+00', 'invalid_ticket', 0, 30695,
	'Ivanov', 'Ivan', 'Ivanovich', '2015-08-16', 0, 30703, '04', '2215123123', 'MSE-2009N1065334', '', 8, 'ребенок инвалид от 0-12 лет',
	'invalid_child', 'ИНВ-PБ', 'Ребенок инвалид от 0-12 лет с предоставлением места', true, 73508, '5552139254500', 1,1858, 'SU', 'DYR',
	'2022-03-23 12:45:00', 'DME', '2022-03-23 11:25:00', 'THALSZ', 'FV', 0, 0, 'DYR', 'Анадырь', 'UHMA', 'АНЫ', 'Анадырь', 'MOW', 'Москва',
	'UUDD', 'ДМД', 'Домодедово', 'SU1710(FV6290)', 'PZZSOC',740000), (
	104329, 'used', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:11:34.119476+00', '', -3, 25688, 'Ivanov', 
	'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', '"Мужчины от 60 лет, Женщины от 55 лет"',
	true, 73607, '5552139254232', 1, 1880, 'SU', 'SVO', '2022-03-01 13:10:00', 'VVO', '2022-03-01 21:40:00', 'THALSZ', '', 0, 0, 'MOW', 'Москва',
	'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', '"SU1700, SU1712"', 'PZZSOC', 740000), (
	104329, 'used', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:11:34.119476+00', '', -3, 25688, 'Ivanov',
	'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', '"Мужчины от 60 лет, Женщины от 55 лет"',
	true, 73607, '5552139254232', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO', '2022-02-23 08:25:00', 'THALSZ', '', 0, 0, 'VVO', 
	'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1711"', 'PZZSOC', 740000), (
	104335, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:12:25.181211+00', 'invalid_operation_time', 
	-3, 25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73613, '5552139254210', 1, 1880, 'SU', 'SVO', '2022-03-01 13:10:00', 'VVO', 
	'2022-03-01 21:40:00', 'THALSZ', '', 0, 0, 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток',
	'"SU1700, SU1712"', 'PZZSOC', 740000), (
	104335, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:12:25.181211+00', 'invalid_operation_time', 
	-3, 25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73613, '5552139254210', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO', '2022-02-23 08:25:00',
	'THALSZ', '', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1711"',
	'PZZSOC', 740000), (
	104170, 'used', '2022-03-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', '', '2022-03-03 10:30:33.212388+00', '', 0, 30695, 'Ivanov', 'Ivan', 
	'Ivanovich', '2015-08-16', 0, 30703, '04', '2215123123', 'MSE-2009N1065334', '', 8, 'ребенок инвалид от 0-12 лет', 'invalid_child', 'ИНВ-PБ', 
	'Ребенок инвалид от 0-12 лет с предоставлением места', true, 73475, '5552139254500', 1, 1858, 'SU', 'DYR', '2022-03-23 12:45:00', 'DME', 
	'2022-03-23 11:25:00', 'THALSZ', 'FV', 0, 0, 'DYR', 'Анадырь', 'UHMA', 'АНЫ', 'Анадырь', 'MOW', 'Москва', 'UUDD', 'ДМД', 'Домодедово',
	'SU1710(FV6290)', 'PZZSOC', 740000), (
	104331, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:11:59.506889+00', 'invalid_operation_time', 
	-3, 25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73609, '5552139254233', 1, 1880, 'SU', 'SVO', '2022-03-01 13:10:00', 'VVO', '2022-03-01 21:40:00',
	'THALSZ', '', 0, 0, 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', '"SU1700, SU1712"',
	'PZZSOC', 740000), (
	104331, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:11:59.506889+00', 'invalid_operation_time', 
	-3, 25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73609, '5552139254233', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO', '2022-02-23 08:25:00',
	'THALSZ', '', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1711"',
	'PZZSOC', 740000), (
	104337, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:14:52.991758+00', 'invalid_ticket', -3, 25688,
	'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73615, '5552139254210', 1, 1880, 'SU', 'SVO', '2022-03-01 13:10:00', 'VVO', '2022-03-01 21:40:00',
	'THALSZ', '', 0, 0, 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', '"SU1700, SU1712"',
	'PZZSOC', 740000), (
	104337, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 09:14:52.991758+00', 'invalid_ticket', -3, 25688,
	'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73615, '5552139254210', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO', '2022-02-23 08:25:00',
	'THALSZ', '', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1711"',
	'PZZSOC', 740000), (
	104325, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 08:13:51.395024+00', 'invalid_operation_time', -3,
	25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73603, '5552139254231', 1, 1880, 'SU', 'SVO', '2022-03-01 13:10:00', 'VVO', '2022-03-01 21:40:00',
	'THALSZ', '', 0, 0, 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', '"SU1700, SU1712"',
	'PZZSOC', 740000), (
	104325, 'issued', '2022-06-23 03:25:00', 'AVIA CENTER LLC (MOSCOW)', 'dev_code', '2022-03-30 08:13:51.395024+00', 'invalid_operation_time', -3,
	25688, 'Ivanov', 'Ivan', 'Ivanovich', '2001-08-16', 0, 25688, '00', '2215123123', '', '', 4, 'пенсионер', 'elderly', 'ПНС', 
	'"Мужчины от 60 лет, Женщины от 55 лет"', true, 73603, '5552139254231', 1, 1879, 'SU', 'VVO', '2022-02-22 23:20:00', 'SVO', '2022-02-23 08:25:00',
	'THALSZ', '', 0, 0, 'VVO', 'Владивосток', 'UHWW', 'ВВО', 'Владивосток', 'MOW', 'Москва', 'UUEE', 'ШРМ', 'Шереметьево', '"SU1701, SU1711"',
	'PZZSOC',740000);

