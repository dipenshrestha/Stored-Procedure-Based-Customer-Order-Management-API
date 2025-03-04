--CREATE PROCEDURE inupStores 
--	@store_id INT,
--	@store_name VARCHAR (255),
--	@phone VARCHAR (25),
--	@email VARCHAR (255),
--	@street VARCHAR (255),
--	@city VARCHAR (255),
--	@state VARCHAR (10),
--	@zip_code VARCHAR (5)  
--AS 
--BEGIN
--	SET NOCOUNT ON; --prevent the row affected message from being displayed
--	--First Try to update into stores if the id exists
--	BEGIN TRY
--		UPDATE sales.stores SET store_name=@store_name, 
--		phone=@phone, email=@email, street=@street, city=@city, state=@state, zip_code=@zip_code WHERE store_id = @store_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH

--	-- ====================================================================================================
--	-- IF the update operation fails then try to insert the data
--	-- such that if there exists records take the recent previous id and add it by 1 and set it as its id
--	-- else i.e. there are no records then just set it as 1
--	-- ====================================================================================================

--	IF @@ROWCOUNT=0
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(store_id) FROM sales.stores;

--		-- Insert new store
--		INSERT INTO sales.stores (store_id, store_name, phone, email, street, city, state, zip_code) 
--		VALUES (
--			COALESCE(@store_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--			@store_name, @phone, @email, @street, @city, @state, @zip_code
--		);

--		PRINT 'Insert successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;

--	ELSE
--	BEGIN 
--		PRINT 'update successful!';
--	END
--END;


--=======================================================================================================================

--CREATE PROCEDURE inupStaffs 
--	@staff_id INT ,
--	@first_name VARCHAR (50),
--	@last_name VARCHAR (50),
--	@email VARCHAR (255),
--	@phone VARCHAR (25),
--	@store_id INT
--AS 
--BEGIN
--	SET NOCOUNT ON; --prevent the row affected message from being displayed
--	--First Try to update into table if the id exists
--	BEGIN TRY
--		UPDATE sales.staffs SET first_name=@first_name, last_name=@last_name, email=@email, phone=@phone,store_id = @store_id WHERE staff_id=@staff_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH

--	-- ====================================================================================================
--	-- IF the update operation fails then try to insert the data
--	-- such that if there exists records take the recent previous id and add it by 1 and set it as its id
--	-- else i.e. there are no records then just set it as 1
--	-- ====================================================================================================

--	IF @@ROWCOUNT=0
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT, @check INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(staff_id) FROM sales.staffs;

--		--to check if there is id in our table
--		SELECT @check = COUNT(*) FROM sales.stores WHERE store_id = @store_id;

--		IF @check <> 0
--		BEGIN TRY
--			-- Insert new store
--			INSERT INTO sales.staffs (staff_id, first_name, last_name, email, phone, store_id) 
--			VALUES (
--				COALESCE(@staff_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--				@first_name, @last_name, @email, @phone, @store_id
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--			THROW 50001, 'Staff ID doesnot exists', 1;
--			-- to use this error into api 
--			--	catch (SqlException ex)
--			--{
--			--	// Catch custom error thrown from SQL Server
--			--	if (ex.Number == 50001)
--			--	{
--			--		return BadRequest($"Custom SQL Error: {ex.Message}");
--			--	}

--			--	// General error handling
--			--	return StatusCode(500, $"Internal server error: {ex.Message}");
--			--}
--		END CATCH;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;

--	ELSE
--	BEGIN 
--		PRINT 'update successful!';
--	END
--END;

--===================================================================================================================

--CREATE PROCEDURE inupCategories 
--	@category_id INT,
--	@category_name VARCHAR(255)
--AS 
--BEGIN
--	SET NOCOUNT ON; --prevent the row affected message from being displayed
--	--First Try to update into table if the id exists
--	BEGIN TRY
--		UPDATE production.categories SET category_name = @category_name WHERE category_id = @category_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH

--	-- ====================================================================================================
--	-- IF the update operation fails then try to insert the data
--	-- such that if there exists records take the recent previous id and add it by 1 and set it as its id
--	-- else i.e. there are no records then just set it as 1
--	-- ====================================================================================================

--	IF @@ROWCOUNT=0
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT, @check INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(category_id) FROM production.categories;
--		BEGIN TRY
--			-- Insert new data
--			INSERT INTO production.categories (category_id, category_name) 
--			VALUES (
--				COALESCE(@category_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--				@category_name
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--			THROW 50001, 'Categories ID doesnot exists', 1;
--		END CATCH;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;

--	ELSE
--	BEGIN 
--		PRINT 'update successful!';
--	END
--END;


--===================================================================================================================

--CREATE PROCEDURE inupBrands 
--	@brand_id INT,
--	@brand_name VARCHAR(255)
--AS 
--BEGIN
--	DECLARE @check INT;
--	--to check if there is id in our table
--	SELECT @check = COUNT(*) FROM production.brands WHERE brand_id = @brand_id;
--	IF @check <> 0
--	BEGIN TRY
--		UPDATE production.brands SET brand_name = @brand_name WHERE brand_id = @brand_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH
--	ELSE 
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(brand_id) FROM production.brands;
--		BEGIN TRY
--			-- Insert new store
--			INSERT INTO production.brands (brand_id, brand_name) 
--			VALUES (
--				COALESCE(@brand_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--				@brand_name
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--			THROW 50001, 'Brand ID doesnot exists', 1;
--		END CATCH;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END;

--===================================================================================================================

--CREATE PROCEDURE inupProducts 
--	@product_id INT,
--	@product_name VARCHAR (255),
--	@brand_id INT,
--	@category_id INT,
--	@model_year SMALLINT,
--	@list_price DECIMAL (10, 2)
--AS 
--BEGIN
--	DECLARE @checkProduct INT,@checkBrand INT, @checkCategory INT;
--	--to check if there is id in our table
--	SELECT @checkProduct = COUNT(*) FROM production.products WHERE product_id = @product_id;
--	SELECT @checkBrand = COUNT(*) FROM fn_getBrands(@brand_id);
--	SELECT @checkCategory = COUNT(*) FROM fn_getCategories(@category_id);
--	IF @checkProduct <> 0 AND @checkBrand <> 0 AND @checkCategory <> 0
--	BEGIN TRY
--		UPDATE production.products SET product_name=@product_name, brand_id=@brand_id, category_id=@category_id, 
--		model_year=@model_year, list_price=@list_price WHERE product_id = @product_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH
--	ELSE 
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(product_id) FROM production.products;
--		IF @checkBrand <> 0 AND @checkCategory <> 0
--		BEGIN TRY
--			-- Insert new store
--			INSERT INTO production.products (product_id, product_name, brand_id, category_id, model_year, list_price) 
--			VALUES (
--				COALESCE(@product_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--				@product_name, @brand_id, @category_id, @model_year, @list_price
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--		END CATCH;
--		ELSE
--		BEGIN
--			print 'No such Brand or Categories ID'
--		END
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END;

--===================================================================================================================

--CREATE PROCEDURE inupCustomers 
--	@customer_id INT,
--	@first_name VARCHAR (255),
--	@last_name VARCHAR (255),
--	@phone VARCHAR (25),
--	@email VARCHAR (255),
--	@street VARCHAR (255),
--	@city VARCHAR (50),
--	@state VARCHAR (25)
--AS 
--BEGIN
--	DECLARE @checkCustomer INT;
--	--to check if there is id in our table
--	SELECT @checkCustomer = COUNT(*) FROM sales.customers WHERE customer_id = @customer_id;
--	IF @checkCustomer <> 0
--	BEGIN TRY
--		UPDATE sales.customers SET first_name=@first_name, last_name=@last_name, phone=@phone, email=@email,
--		street=@street, city=@city, state=@state WHERE customer_id = @customer_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH
--	ELSE 
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(customer_id) FROM sales.customers;
--		BEGIN TRY
--			-- Insert new store
--			INSERT INTO sales.customers (customer_id, first_name, last_name, phone, email, street, city, state) 
--			VALUES (
--				COALESCE(@customer_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--				@first_name, @last_name, @phone, @email, @street, @city, @state
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--		END CATCH;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END;

--===================================================================================================================

--CREATE PROCEDURE inupOrders 
--	@order_id INT, 
--	@customer_id INT, 
--	@order_status tinyint, 
--	@order_date DATE, 
--	@required_date DATE, 
--	@shipped_date DATE,
--	@store_id INT, 
--	@staff_id INT
--AS 
--BEGIN
--	DECLARE @checkOrder INT,@checkCustomer INT, @checkStore INT, @checkStaff INT;
--	--to check if there is id in our table
--	SELECT @checkOrder = COUNT(*) FROM sales.orders WHERE order_id = @order_id;
--    SELECT @checkCustomer = COUNT(*) FROM sales.customers WHERE customer_id = @customer_id;
--	SELECT @checkStore = COUNT(*) FROM fn_getStores(@store_id);
--	SELECT @checkStaff = COUNT(*) FROM fn_getStaffs(@staff_id);

--	-- Debugging prints
--    PRINT 'Order Exists: ' + CAST(@checkOrder AS VARCHAR);
--    PRINT 'Customer Exists: ' + CAST(@checkCustomer AS VARCHAR);
--    PRINT 'Store Exists: ' + CAST(@checkStore AS VARCHAR);
--    PRINT 'Staff Exists: ' + CAST(@checkStaff AS VARCHAR);

--	IF @checkOrder <> 0 AND @checkCustomer <> 0 AND @checkStore <> 0 AND @checkStaff <> 0
--	BEGIN TRY
--		UPDATE sales.orders SET order_id = @order_id, 
--		customer_id = @customer_id, 
--		order_status = @order_status, 
--		order_date = @order_date, 
--		required_date = @required_date, 
--		shipped_date = @shipped_date,
--		store_id = @store_id, 
--		staff_id = @staff_id WHERE order_id = @order_id;
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH
--	ELSE 
--	BEGIN TRY
--		-- Declare variable
--		DECLARE @PreviousId INT;

--		-- Get the highest store_id
--		SELECT @PreviousId = MAX(order_id) FROM sales.orders;
--		IF @checkCustomer <> 0 AND @checkStore <> 0 AND @checkStaff <> 0
--		BEGIN TRY
--			-- Insert new store
--			INSERT INTO sales.orders (order_id, customer_id, order_status, order_date, required_date, shipped_date,store_id, staff_id) 
--			VALUES (
--				COALESCE(@order_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
--			@customer_id, @order_status, @order_date, @required_date, @shipped_date,@store_id, @staff_id
--			);
--			PRINT 'Insert successful!';
--		END TRY
--		BEGIN CATCH
--			PRINT 'Error Occurred!';
--			PRINT ERROR_MESSAGE(); -- Get the error message
--		END CATCH;
--		ELSE
--		BEGIN
--			print 'No such Customer, Store, or Staff ID!'
--		END
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END;

--===================================================================================================================

CREATE PROCEDURE inupOrderItems
	@order_id INT,
	@item_id INT,
	@product_id INT,
	@quantity INT,
	@list_price DECIMAL (10, 2),
	@discount DECIMAL (4, 2)
AS 
BEGIN
	DECLARE @checkItem INT, @checkOrder INT,@checkProduct INT;
	--to check if there is id in our table
	SELECT @checkItem = COUNT(*) FROM sales.order_items WHERE item_id = @item_id;
	SELECT @checkOrder = COUNT(*) FROM sales.orders WHERE order_id = @order_id;
	SELECT @checkProduct = COUNT(*) FROM production.products WHERE product_id = @product_id;

	-- Debugging prints
    PRINT 'Item Exists: ' + CAST(@checkItem AS VARCHAR);
    PRINT 'Order Exists: ' + CAST(@checkOrder AS VARCHAR);
    PRINT 'Product Exists: ' + CAST(@checkProduct AS VARCHAR);

	IF @checkItem <> 0 AND @checkOrder <> 0 AND @checkProduct <> 0 
	BEGIN TRY
		UPDATE sales.order_items SET 
		order_id = @order_id,
		product_id = @product_id,
		quantity = @quantity,
		list_price = @list_price,
		discount = @discount
		WHERE item_id = @item_id;
	END TRY
	BEGIN CATCH
		PRINT 'Error Occurred!';
		PRINT ERROR_MESSAGE(); -- Get the error message
	END CATCH
	ELSE 
	BEGIN TRY
		-- Declare variable
		DECLARE @PreviousId INT;

		-- Get the highest store_id
		SELECT @PreviousId = MAX(item_id) FROM sales.order_items;
		IF @checkOrder <> 0 AND @checkProduct <> 0 
		BEGIN TRY
			-- Insert new store
			INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount) 
			VALUES (
			@order_id,
				COALESCE(@item_id, @PreviousId + 1, 1), --Coalesce(): Returns the first non-NULL value found.
			@product_id, @quantity, @list_price, @discount
			);
			PRINT 'Insert successful!';
		END TRY
		BEGIN CATCH
			PRINT 'Error Occurred!';
			PRINT ERROR_MESSAGE(); -- Get the error message
		END CATCH;
		ELSE
		BEGIN
			print 'No such Order or Product ID!'
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error Occurred!';
		PRINT ERROR_MESSAGE(); -- Get the error message
	END CATCH;
END;

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
--==============================================================================================
CREATE PROCEDURE inupStocks
	@store_id INT,
	@product_id INT,
	@quantity INT
AS 
BEGIN
	DECLARE @checkStocks INT, @checkStore INT,@checkProduct INT;
	--to check if there is id in our table
	SELECT @checkStocks = COUNT(*) FROM production.stocks WHERE (store_id = @store_id AND product_id = @product_id);
	SELECT @checkStore = COUNT(*) FROM sales.stores WHERE store_id = @store_id;
	SELECT @checkProduct = COUNT(*) FROM production.products WHERE product_id = @product_id;

	-- Debugging prints
    PRINT 'Store Exists: ' + CAST(@checkStore AS VARCHAR);
    PRINT 'Product Exists: ' + CAST(@checkProduct AS VARCHAR);

	IF @checkStocks<>0 AND @checkStore <> 0 AND @checkProduct <> 0 
	BEGIN TRY
		UPDATE production.stocks SET 
		quantity = @quantity
		WHERE (store_id = @store_id AND product_id = @product_id);
	END TRY
	BEGIN CATCH
		PRINT 'Error Occurred!';
		PRINT ERROR_MESSAGE(); -- Get the error message
	END CATCH
	ELSE 
	BEGIN TRY
		IF @checkStore <> 0 AND @checkProduct <> 0 
		BEGIN TRY
			-- Insert new store
			INSERT INTO production.stocks (store_id, product_id, quantity) 
			VALUES (@store_id, @product_id, @quantity);
			PRINT 'Insert successful!';
		END TRY
		BEGIN CATCH
			PRINT 'Error Occurred!';
			PRINT ERROR_MESSAGE(); -- Get the error message
		END CATCH;
		ELSE
		BEGIN
			print 'No such Store or Product ID!'
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error Occurred!';
		PRINT ERROR_MESSAGE(); -- Get the error message
	END CATCH;
END;