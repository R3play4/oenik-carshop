create table car_brands
(
	id int identity primary key ,
	name varchar(20),
	country varchar(20),
	url varchar(100), 
	founded date ,
	yearly_revenue int
)

insert into car_brands (name, country, founded, yearly_revenue) values('Peugeot', 'France', '1810/01/15', 38)
insert into car_brands (name, country, founded, yearly_revenue) values('Opel', 'Germany', '1862/01/21', 19)
insert into car_brands (name, country, founded, yearly_revenue) values('Mercedes', 'Germany', '1926/06/28', 78)
insert into car_brands (name, country, founded, yearly_revenue) values('BMW', 'Germany', '1916/03/07', 98)


create table car_models
(
	id int identity primary key ,
	brand_id int,
	name varchar(20),
	production_start date,
	engine_size int, 
	horsepower int, 
	starting_price int
)

insert into car_models ( brand_id, name, production_start, engine_size, horsepower, starting_price) values( 2, '406', '2002/04/12', 1400, 85, 3000 )
insert into car_models ( brand_id, name, production_start, engine_size, horsepower, starting_price) values( 1, 'Megane', '2000/03/22', 2000, 110, 4500 )
insert into car_models ( brand_id, name, production_start, engine_size, horsepower, starting_price) values( 3, 'Astra', '1999/09/17', 1400, 95, 3100)
insert into car_models ( brand_id, name, production_start, engine_size, horsepower, starting_price) values( 1, 'M5', '2010/03/22', 4000, 220, 8000 )

create table extras
(
	id int identity primary key ,
	category_name varchar(20),
	name varchar(20),
	price int, 
	color varchar(10), 
	reuseable tinyint 
)

insert into extras (category_name, name, price, reuseable) values ('Interior', 'Air Conditioning', 100,  0 )
insert into extras (category_name, name, price, reuseable) values ('Engine', 'Turbo', 250,  0 )