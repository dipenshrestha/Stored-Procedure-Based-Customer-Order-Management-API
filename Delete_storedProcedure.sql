--CREATE PROCEDURE deleteStores 
--	@store_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the stores data using id
--		DELETE FROM sales.stores WHERE store_id = @store_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END;

--========================================================================

--CREATE PROCEDURE deleteStaffs 
--	@staff_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the stores data using id
--		DELETE FROM sales.staffs WHERE staff_id = @staff_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--================================================================================

--CREATE PROCEDURE deleteCategories 
--	@category_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM production.categories WHERE category_id = @category_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=====================================================================================

--CREATE PROCEDURE deleteBrands 
--	@brand_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM production.brands WHERE brand_id = @brand_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=====================================================================================

--CREATE PROCEDURE deleteProducts 
--	@product_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM production.products WHERE product_id = @product_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=====================================================================================

--CREATE PROCEDURE deleteCustomers 
--	@customer_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM sales.customers WHERE customer_id = @customer_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=======================================================================================

--CREATE PROCEDURE deleteOrders 
--	@order_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM sales.orders WHERE order_id = @order_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=======================================================================================

--CREATE PROCEDURE deleteOrderItems
--	@item_id INT
--AS 
--BEGIN
--	BEGIN TRY
--		-- Delete the data using id
--		DELETE FROM sales.order_items WHERE item_id = @item_id;
--		PRINT 'Delete successful!';
--	END TRY
--	BEGIN CATCH
--		PRINT 'Error Occurred!';
--		PRINT ERROR_MESSAGE(); -- Get the error message
--	END CATCH;
--END

--=======================================================================================

CREATE PROCEDURE deleteStocks
	@store_id INT,
	@product_id INT
AS 
BEGIN
	BEGIN TRY
		-- Delete the data using id
		DELETE FROM production.stocks WHERE (store_id = @store_id AND product_id = @product_id);
		PRINT 'Delete successful!';
	END TRY
	BEGIN CATCH
		PRINT 'Error Occurred!';
		PRINT ERROR_MESSAGE(); -- Get the error message
	END CATCH;
END
