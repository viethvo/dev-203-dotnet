using Dapper;
using NLog;
using SecurityCoding.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SecurityCoding.Repository
{
    public class CustomerRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
            }
        }

        public Customer Add(Customer customer)
        {
            string sqlStatement = @"INSERT INTO [dbo].[Customer]([Name], [Adress] ,[Age] ,[Image], [AccountId]) VALUES(@name, @address, @age, @image, @accountId)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sqlStatement;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@address", customer.Adress);
                    command.Parameters.AddWithValue("@age", customer.Age);
                    command.Parameters.AddWithValue("@image", customer.Image);
                    command.Parameters.AddWithValue("@accountId", customer.AccountId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return customer;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return null;
                    }
                }
            }
        }

        public List<Customer> FindByName(string name, string accountId)
        {
            string sqlStatement = @"Select * from Customer where Name = @name and AccountId = @accountId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sqlStatement;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@accountId", accountId);
                    try
                    {
                        connection.Open();
                        return connection.Query<Customer>(sqlStatement, new { Name=name, AccountId = accountId}).ToList();
                    } catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return null;
                    }
                }
            }
        }

        public Customer FindById(int Id, string accountId)
        {
            string sqlStatement = @"Select * from Customer where Id = @Id and AccountId = @accountId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sqlStatement;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@accountId", accountId);
                    try
                    {
                        connection.Open();
                        return connection.Query<Customer>(sqlStatement, new { Id = Id, AccountId = accountId }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return null;
                    }
                }
            }
        }

        public Customer Update(Customer customer, string accountId)
        {
            string sqlStatement = @"UPDATE [dbo].[Customer] SET [Name] = @name ,[Adress] = @address ,[Age] = @age ,[Image] = @image WHERE [Id] = @id AND [AccountId] = @accountId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sqlStatement;
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@name", customer.Name ?? string.Empty);
                    command.Parameters.AddWithValue("@address", customer.Adress ?? string.Empty);
                    command.Parameters.AddWithValue("@age", customer.Age);
                    command.Parameters.AddWithValue("@image", customer.Image ?? string.Empty);
                    command.Parameters.AddWithValue("@accountId", customer.AccountId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return customer;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}