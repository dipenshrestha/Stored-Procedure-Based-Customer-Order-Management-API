--https://www.sqlservertutorial.net/getting-started/sql-server-sample-database/
create database APIcom;
create schema sales;
create schema production;

create TABLE sales.stores (
	store_id INT PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255),
	street VARCHAR (255),
	city VARCHAR (255),
	state VARCHAR (10),
	zip_code VARCHAR (5)
);

CREATE TABLE sales.staffs (
	staff_id INT PRIMARY KEY,
	first_name VARCHAR (50) NOT NULL,
	last_name VARCHAR (50) NOT NULL,
	email VARCHAR (255) NOT NULL UNIQUE,
	phone VARCHAR (25),
	store_id INT NOT NULL,
	FOREIGN KEY (store_id) 
        REFERENCES sales.stores (store_id) 
        ON DELETE CASCADE 
		ON UPDATE CASCADE,
);

CREATE TABLE production.categories (
	category_id INT PRIMARY KEY,
	category_name VARCHAR (255) NOT NULL
);

CREATE TABLE production.brands (
	brand_id INT PRIMARY KEY,
	brand_name VARCHAR (255) NOT NULL
);

CREATE TABLE production.products (
	product_id INT PRIMARY KEY,
	product_name VARCHAR (255) NOT NULL,
	brand_id INT NOT NULL,
	category_id INT NOT NULL,
	model_year SMALLINT NOT NULL, --16 bits
	list_price DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (category_id) 
        REFERENCES production.categories (category_id) 
        ON DELETE CASCADE 
		ON UPDATE CASCADE,
	FOREIGN KEY (brand_id) 
        REFERENCES production.brands (brand_id) 
        ON DELETE CASCADE 
		ON UPDATE CASCADE
);

CREATE TABLE sales.customers (
	customer_id INT PRIMARY KEY,
	first_name VARCHAR (255) NOT NULL,
	last_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255) NOT NULL,
	street VARCHAR (255),
	city VARCHAR (50),
	state VARCHAR (25)
);

CREATE TABLE sales.orders (
	order_id INT PRIMARY KEY,
	customer_id INT,
	order_status tinyint NOT NULL, --8 bits
	-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
	order_date DATE NOT NULL,
	required_date DATE NOT NULL,
	shipped_date DATE,
	store_id INT NOT NULL,
	staff_id INT NOT NULL,
	FOREIGN KEY (customer_id) 
        REFERENCES sales.customers (customer_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (store_id) 
        REFERENCES sales.stores (store_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (staff_id) 
        REFERENCES sales.staffs (staff_id) 
        ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE sales.order_items(
	order_id INT,
	item_id INT,
	product_id INT NOT NULL,
	quantity INT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	discount DECIMAL (4, 2) NOT NULL DEFAULT 0,
	PRIMARY KEY (order_id, item_id),
	FOREIGN KEY (order_id) 
        REFERENCES sales.orders (order_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) 
        REFERENCES production.products (product_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE production.stocks (
	store_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY (store_id, product_id),
	FOREIGN KEY (store_id) 
        REFERENCES sales.stores (store_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) 
        REFERENCES production.products (product_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

--=======================================================================================================
--For Stores

--This will insert the data into Stores
EXEC inupStores 1,'ferrari','9860744627','ferrari@gmail.com','magam','Bhaktapur','Bagmati','1000'

--This will update the data into stores whose id=1
EXEC inupStores 1,'lamborghini','9860744627','lamborghini@gmail.com','magam','Bhaktapur','Bagmati','2000'

--This will take previous id i.e. 1 and add 1 to it i.e. store_id = 2
EXEC inupStores null,'Bentley','9860744627','Bentley@gmail.com','magam','Bhaktapur','Bagmati','3000'

--This will insert data with custom id i.e. store_id = 109
EXEC inupStores 109,'McLaren Speedtail','9860744627','McLaren@gmail.com','magam','Bhaktapur','Bagmati','4000'

--This will take previous id i.e. 109 and add 1 to it i.e. store_id = 110
EXEC inupStores null,'Rimac Nevera','9860744627','Rimac@gmail.com','magam','Bhaktapur','Bagmati','5000'

--this will select all the data from stores
select * from fn_getStores(null)

--this will select the data that matched the id i.e. store_id=1
select * from fn_getStores(1)

--this will delete data from stores where store_id = 109
EXEC deleteStores 109

--==============================================================================================================
-- For Staffs

EXEC inupStaffs 1, 'zero', 'Stha', 'zerostha76@gmail.com','9860744627','2'

select * from fn_getStaffs(null);

EXEC deleteStaffs 760314

--===============================================================================================================
--for categories
EXEC inupCategories 1, 'Cars'
EXEC inupCategories 1, 'Super Car'
EXEC inupCategories 77, 'Bike'
EXEC inupCategories null, 'Plane'

select * from fn_getCategories(null);
select * from fn_getCategories(1);

EXEC deleteCategories 77

--===============================================================================================================
--for brands
EXEC inupBrands 1, 'BMW'
EXEC inupBrands 1, 'Not BMW'
EXEC inupBrands 77, 'Bike'
EXEC inupBrands null, 'Plane'

select * from fn_getBrands(null);
select * from fn_getBrands(1);

EXEC deleteBrands 78

--===============================================================================================================
--for products
EXEC inupProducts 1, 'Side-mirror', 1, 2, 2019, 200000
EXEC inupProducts 1, 'Side-Light', 1, 2, 2019, 300000
EXEC inupProducts 5, 'Chains Pocket', 1, 2, 2019, 250000
EXEC inupProducts null,'Head Light', 1, 2, 2019, 500000

select * from fn_getProducts(null);
select * from fn_getProducts(1);

EXEC deleteProducts 1

--===================================================================================================================
--for Customers
EXEC inupCustomers 2, 'Dipen', 'Stha', '9860744637', 'dipnstha@gmail.com','magam','Nepal','Bagmati'
EXEC inupCustomers 1, 'Depen', 'Shrestha', '9860744637', 'dipoen@gmail.com','magam','Nepal','Bagmati'
EXEC inupCustomers 66, 'Ram', 'cozi', '9860744637', 'ramam@gmail.com','magam','Nepal','Bagmati'
EXEC inupCustomers null, 'Sita', 'Shrestha', '9860744637', 'sita@gmail.com','magam','Nepal','Bagmati'

Select * from fn_getCustomers(null)
Select * from fn_getCustomers(1)

EXEC deleteCustomers 2

--===================================================================================================================
--for Orders
EXEC inupOrders 1, 1, 4, '2025-2-27', '2025-3-1','2025-3-2',1,1
EXEC inupOrders 1, 1, 4, '2025-2-25', '2025-3-1','2025-3-2',1,1
EXEC inupOrders 10, 1, 4, '2025-2-27', '2025-3-1','2025-3-2',1,1
EXEC inupOrders null, 1, 4, '2025-2-27', '2025-3-1','2025-3-2',1,1

Select * from fn_getOrders(null)
Select * from fn_getOrders(1)

EXEC deleteOrders 0

--======================================================================================================================
--for OrderItems
EXEC inupOrderItems 1, 1, 1, 5, 50000.00, 50.00
EXEC inupOrderItems 1, 1, 1, 12, 30000.00, 20.00
EXEC inupOrderItems 1, 10, 1, 5, 50000.00, 50.00
EXEC inupOrderItems 1, null, 1, 5, 50000.00, 50.00

Select * from fn_getOrderItems(null)
Select * from fn_getOrderItems(1)

EXEC deleteOrderItems 11

--======================================================================================================================
--for Stocks
EXEC inupStocks 1, 1, 200
EXEC inupStocks 1, 1, 300
EXEC inupStocks 2, 1, 500

Select * from fn_getStocks(null,null)
Select * from fn_getStocks(1,1)

EXEC deleteStocks 1,1
EXEC deleteStocks 2,1