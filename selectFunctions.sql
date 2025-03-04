--CREATE FUNCTION dbo.fn_getStores 
--    (@store_id INT = NULL)  -- Default to NULL if not provided
--RETURNS TABLE
--AS
--RETURN
--    -- Select stores based on the value of @store_id
--    SELECT store_id, store_name, phone, email, street, city, state, zip_code
--    FROM sales.stores
--    WHERE (@store_id IS NULL OR @store_id = 0 OR store_id = @store_id);

--==================================================================================

--CREATE FUNCTION fn_getStaffs
--    (@staff_id INT = NULL)  -- Default to NULL if not provided
--RETURNS TABLE
--AS
--RETURN
--    -- Select stores based on the value of @store_id
--    SELECT staff_id, first_name, last_name, email, phone, store_id
--    FROM sales.staffs
--    WHERE (@staff_id IS NULL OR @staff_id = 0 OR staff_id = @staff_id);

--===================================================================================

--CREATE FUNCTION fn_getCategories
--    (@category_id INT = NULL)  -- Default to NULL if not provided
--RETURNS TABLE
--AS
--RETURN
--    -- Select stores based on the value of @store_id
--    SELECT category_id, category_name
--    FROM production.categories
--    WHERE (@category_id IS NULL OR @category_id = 0 OR category_id = @category_id);

--===================================================================================

--CREATE FUNCTION fn_getBrands
--    (@brand_id INT = NULL)  -- Default to NULL if not provided
--RETURNS TABLE
--AS
--RETURN
--    -- Select based on the value of id
--    SELECT brand_id, brand_name
--    FROM production.brands
--    WHERE (@brand_id IS NULL OR @brand_id = 0 OR brand_id = @brand_id);

--===================================================================================

--CREATE FUNCTION fn_getProducts
--	(@product_id INT = NULL)
--RETURNS TABLE
--AS
--RETURN
--	-- Select based on the value of id
--    SELECT product_id, product_name, brand_id, category_id, model_year, list_price
--    FROM production.products
--    WHERE (@product_id IS NULL OR @product_id = 0 OR product_id = @product_id);

--===================================================================================

--CREATE FUNCTION fn_getCustomers
--	(@customer_id INT = NULL)
--RETURNS TABLE
--AS
--RETURN
--	-- Select based on the value of id
--    SELECT customer_id, first_name, last_name, phone, email, street, city, state 
--    FROM sales.customers
--    WHERE (@customer_id IS NULL OR @customer_id = 0 OR customer_id = @customer_id);

--===================================================================================

--CREATE FUNCTION fn_getOrders
--	(@order_id INT = NULL)
--RETURNS TABLE
--AS
--RETURN
--	-- Select based on the value of id
--    SELECT order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id 
--    FROM sales.orders
--    WHERE (@order_id IS NULL OR @order_id = 0 OR order_id = @order_id);

--===================================================================================

--CREATE FUNCTION fn_getOrderItems
--	(@item_id INT = NULL)
--RETURNS TABLE
--AS
--RETURN
--	-- Select based on the value of id
--    SELECT order_id, item_id, product_id, quantity, list_price, discount
--    FROM sales.order_items
--    WHERE (@item_id IS NULL OR @item_id = 0 OR item_id = @item_id);

--===================================================================================

--CREATE FUNCTION fn_getStocks
--    (
--    @store_id INT = NULL,
--    @product_id INT = NULL
--    )
--RETURNS TABLE
--AS
--RETURN
--    SELECT store_id, product_id, quantity
--    FROM production.stocks
--    WHERE
--        -- If both store_id and product_id are NULL, return all rows
--        (@store_id IS NULL AND @product_id IS NULL) 
--        OR
--        -- If both store_id and product_id are provided, filter by both
--        (@store_id IS NOT NULL AND @product_id IS NOT NULL AND store_id = @store_id AND product_id = @product_id);


--===============================================================================================
