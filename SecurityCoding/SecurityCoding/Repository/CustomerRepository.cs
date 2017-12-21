using Dapper;
using SecurityCoding.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SecurityCoding.Repository
{
    public class CustomerRepository
    {
        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
            }
        }

        public Customer Add(Customer customer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = $"INSERT INTO [dbo].[Customer]([Name], [Adress] ,[Age] ,[Image]) VALUES('{customer.Name}', '{customer.Adress.Replace("'", "''")}', {customer.Age}, '{customer.Image}')";

                connection.Execute(sql);
            }

            return customer;
        }

        public List<Customer> FindByName(string name)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = "Select * from Customer where Name = '" + name + "'";

                return connection.Query<Customer>(sql).ToList();
            }
        }

        public Customer FindById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = "Select * from Customer where Id = " + Id;

                return connection.Query<Customer>(sql).FirstOrDefault();
            }
        }

        public Customer Update(Customer customer)
        {
            var sql = $"UPDATE [dbo].[Customer] SET [Name] = '{customer.Name}' ,[Adress] = '{customer.Adress}' ,[Age] = {customer.Age} ,[Image] = '{customer.Image}' WHERE [Id] = {customer.Id}";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute(sql);

                return customer;
            }
        }
    }
}