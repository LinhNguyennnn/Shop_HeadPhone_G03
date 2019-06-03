using System;
using System.Collections.Generic;
using HP_Persistence;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace HP_DAL
{
    public class Order_DAL
    {
        private MySqlDataReader reader;
        private MySqlConnection connection;
        private string query;
        public bool CreateOrder(Order order)
        {
            bool result = false;

            connection = DbHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;

            command.CommandText = @"lock tables Items write, Orders write,OrderDetails write;";
            command.ExecuteNonQuery();

            MySqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                int? orderId = 0;

                command.CommandText = @"insert into Orders(Cus_ID, Order_Status, Order_Date, Address_Shipping) values (@Cus_ID, @Order_Status, @Order_Date,@Address_Shipping);";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Cus_ID", order.Customer.Cus_ID);
                command.Parameters.AddWithValue("@Order_Status", order.Status);
                command.Parameters.AddWithValue("@Address_Shipping", order.Address_Shipping);
                command.Parameters.AddWithValue("@Order_Date", order.Order_Date);
                command.ExecuteNonQuery();
                command.CommandText = @"select LAST_INSERT_ID() as Order_ID";
                using (reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orderId = reader.GetInt32("Order_ID");
                    }
                }
                order.Order_ID = orderId;
                foreach (var item in order.ItemsList)
                {
                    command.CommandText = @"insert into OrderDetails(Order_ID,Produce_Code) values (" + order.Order_ID + ", " + item.Produce_Code + ");";
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
                result = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
                throw;
            }
            finally
            {
                command.CommandText = @"unlock tables;";
                command.ExecuteNonQuery();
                connection.Close();
                DbHelper.CloseConnection();
            }
            return result;
        }
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            query = @"select * from Orders where Cus_ID = " + customerId + ";";
            reader = DbHelper.ExecQuery(query,DbHelper.OpenConnection());
            List<Order> order = null;
            if (reader != null)
            {
                order = GetListOrderInfo(reader);
            }
            DbHelper.CloseConnection();
            return order;
        }

        public bool DeleteOrder(int? orderId)
        {
            bool result = false;
            connection = DbHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = @"lock tables Customers write, Items write, Orders write,OrderDetails write;";
            command.ExecuteNonQuery();
            MySqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.CommandText = $"delete from OrderDetails where order_ID = {orderId};";
                command.ExecuteNonQuery();
                command.CommandText = $"delete from Orders where order_ID = {orderId};";
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                transaction.Rollback();
            }
            finally
            {
                command.CommandText = @"unlock tables;";
                command.ExecuteNonQuery();
                connection.Close();
                DbHelper.CloseConnection();
            }
            return result;
        }
        private List<Order> GetListOrderInfo(MySqlDataReader reader)
        {
            List<Order> ListOrders = new List<Order>();
            while (reader.Read())
            {
                Order order = GetOrder(reader);
                ListOrders.Add(order);
            }
            return ListOrders;
        }

        private Order GetOrder(MySqlDataReader reader)
        {
            Order order = new Order();
            order.Order_ID = reader.GetInt32("Order_ID");
            order.Order_Date = reader.GetDateTime("Order_Date");
            order.Address_Shipping = reader.GetString("Address_Shipping");
            order.Status = reader.GetString("Order_Status");
            order.Customer = new Customers();
            order.Customer.Cus_ID = reader.GetInt32("Cus_ID");
            return order;
        }
        
        public bool UpdateStatusOrder(int? orderId)
        {
            bool result = false;
            connection = DbHelper.OpenConnection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = @"lock tables Customers write, Items write, Orders write,OrderDetails write;";
            command.ExecuteNonQuery();
            MySqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.Clear();
                command.CommandText = $"Update ignore Orders set Order_Status = 'Thành công' where Order_ID = @Order_Id";
                command.Parameters.AddWithValue("@Order_Id", orderId);
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                transaction.Rollback();
            }
            finally
            {
                command.CommandText = @"unlock tables;";
                command.ExecuteNonQuery();
                connection.Close();
            }
            DbHelper.CloseConnection();
            return result;
        }
        private Order GetStatus(MySqlDataReader reader)
        {
            Order order = new Order();
            order.Status = reader.GetString("Order_Status");
            return order;
        }
    }
}