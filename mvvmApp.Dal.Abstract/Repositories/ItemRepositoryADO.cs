using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using mvvmApp.Dal.Abstract.Client;
using mvvmApp.Dal.Abstract.Entities;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class ItemRepositoryADO : IRepository<Item>
    {
        private readonly string connectionString;
        SqlDataAdapter adapter;
        DataTable itemsTable;
        string error;
        DataTable detailsTable;


        public List<Detail> GetDetails(int itemId) 
        {
            detailsTable = new DataTable();
            string sql = "select * from detail " +
                "where Item_Id = @itemId";
            List<Detail> result = new List<Detail>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(sql, connection);
                SqlParameter itemIdParam = new SqlParameter("@itemId", itemId);
                command.Parameters.Add(itemIdParam);

                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(detailsTable);


                foreach (DataRow row in detailsTable.Rows)
                {
                    var el = new Detail
                    {
                        Company = row["Company"].ToString(),
                        ImagePath = row["ImagePath"].ToString(),
                        Title = row["Title"].ToString(),
                        Price = Convert.ToInt32(row["Price"]),
                        Id = Convert.ToInt32(row["Id"]),
                        Item_Id = Convert.ToInt32(row["Item_Id"]),
                        Status = Convert.ToInt32(row["Status"]) == 1 ? true : false 
                    };
                    result.Add(el);
                }
                if (connection != null)
                    connection.Close();
                if (detailsTable != null)
                    detailsTable.Clear();
            }
            catch (Exception ex)
            {
            }
            return result;

        }
        public void RepairDetail(int detailId) 
        {
            string sql = "Update detail set status = 1 " +
                "where id  = @detailId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlParameter detailIdParam = new SqlParameter("@detailId", detailId);
                    command.Parameters.Add(detailIdParam);


                    int num = command.ExecuteNonQuery();
                    command.Dispose();
                    if (conn != null)
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

            }

            
        }

        public List<Item> GetOrderedComputers()
        {
            string sqlQuery =
                "select * from Items " +
                "where Id in " +
                "(select Item_Id from OrderItems)";

            return GetItemsFromQuery(sqlQuery);

        }
        public void RepairComputer(int ItemId, int OrderId) 
        {
            string query =
                "Delete from OrderItems " +
                "where Order_Id = @orderId " +
                "and Item_Id = @ItemId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(query, conn);
                    SqlParameter idParam = new SqlParameter("@orderId",OrderId);
                    comm.Parameters.Add(idParam);

                    SqlParameter idItemParam = new SqlParameter("@ItemId", ItemId);
                    comm.Parameters.Add(idItemParam);

                    int num = comm.ExecuteNonQuery();
                    comm.Dispose();
                    if (conn != null)
                        conn.Close();
                }
            }
            catch (Exception ex)
            {

                
            }
        }
        public List<ItemAndOrderId> GetOrderedComputersAndOrderId() 
        {
            
            List<Item> items = GetOrderedComputers();

            List<ItemAndOrderId> itemandOrderId = new List<ItemAndOrderId>();

            List<OrderItem> OrderIdItemId = new List<OrderItem>();
            string query =
                "select * from OrderItems";
            try
            {
                DataTable orderItemsDataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    adapter = new SqlDataAdapter(command);

                    connection.Open();

                    adapter.Fill(orderItemsDataTable);

                    foreach (DataRow row in orderItemsDataTable.Rows)
                    {
                        var el = new OrderItem
                        {

                            OrderId = Convert.ToInt32(row["Order_Id"]),
                            ItemId = Convert.ToInt32(row["Item_Id"])
                        };
                        OrderIdItemId.Add(el);
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }
            foreach(var el in OrderIdItemId) 
            {
                foreach(var ordItem in items) 
                {
                    if(el.ItemId == ordItem.Id) 
                    {
                        itemandOrderId.Add(new ItemAndOrderId 
                        {
                            item=  ordItem,
                            OrderId = el.OrderId
                        });
                    }
                }
            }
            return itemandOrderId;

        }


        public ItemRepositoryADO()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["MvvmAppDb"].ConnectionString;

            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }
            

        }
        #region
        //private void ExecuteQuery(string sqlQuery)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand comm = new SqlCommand(sqlQuery, conn);
        //        int num = comm.ExecuteNonQuery();
        //        comm.Dispose();
        //        if (conn != null)
        //            conn.Close();
        //        if(itemsTable!=null)
        //            itemsTable.Clear();
        //    }
        //}
        #endregion
        public void Create(Item item)
        {
            //ExecuteQuery(sqlQuery);
            string sqlQueryParametrized =
                "Insert into Items (Title,ImagePath,Price,Company)" +
                "Values (@Title,@ImagePath,@Price,@Company)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sqlQueryParametrized, conn);
                SqlParameter titleParam = new SqlParameter("@Title", item.Title);
                comm.Parameters.Add(titleParam);
                SqlParameter ImagePathParam = new SqlParameter("@ImagePath", item.ImagePath);
                comm.Parameters.Add(ImagePathParam);
                SqlParameter PriceParam = new SqlParameter("@Price", item.Price);
                comm.Parameters.Add(PriceParam);
                SqlParameter CompanyParam = new SqlParameter("@Company", item.Company);
                comm.Parameters.Add(CompanyParam);

                int num = comm.ExecuteNonQuery();
                comm.Dispose();
                if (conn != null)
                    conn.Close();
            }
        }
        
        public void Delete(int id)
        {
            string sqlQuery =
                "Delete from Items " +
                "Where id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                SqlParameter idParam = new SqlParameter("@Id",id);
                comm.Parameters.Add(idParam);

                int num = comm.ExecuteNonQuery();
                comm.Dispose();
                if (conn != null)
                    conn.Close();
            }
        }
        private List<Item> GetItemsFromQuery(string sql)
        {
            var result = new List<Item>();
            try
            {
                itemsTable = new DataTable();
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(itemsTable);


                foreach (DataRow row in itemsTable.Rows)
                {
                    var el = new Item
                    {
                        Company = row["Company"].ToString(),
                        ImagePath = row["ImagePath"].ToString(),
                        Title = row["Title"].ToString(),
                        Price = Convert.ToInt32(row["Price"]),
                        Id = Convert.ToInt32(row["Id"])
                    };
                    result.Add(el);
                }
                if (connection != null)
                    connection.Close();
                if (itemsTable != null)
                    itemsTable.Clear();
            }
            catch (Exception ex)
            {
            }


            return result;
        }
        public IEnumerable<Item> GetAllItems()
        {
            string sql = "Select * from Items";
            return GetItemsFromQuery(sql);
        }
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            string sql = "Select * from Items";
            itemsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                await connection.OpenAsync();
                adapter.Fill(itemsTable);

                var result = new List<Item>();
                foreach (DataRow row in itemsTable.Rows)
                {
                    var el = new Item
                    {
                        Company = row["Company"].ToString(),
                        ImagePath = row["ImagePath"].ToString(),
                        Title = row["Title"].ToString(),
                        Price = Convert.ToInt32(row["Price"]),
                        Id = Convert.ToInt32(row["Id"])
                    };
                    result.Add(el);
                }
                if (connection != null)
                    connection.Close();
                return result;
            }
         
        }

        public Item GetItem(int id)
        {
            string sql = "Select * from Items " +
                "where id = @Id";
            var res = new Item();
            itemsTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlParameter idParam = new SqlParameter("@Id", id);
                    command.Parameters.Add(idParam);
                    adapter = new SqlDataAdapter(command);

                    connection.Open();

                    adapter.Fill(itemsTable);

                    foreach (DataRow row in itemsTable.Rows)
                    {
                        var el = new Item
                        {
                            Company = row["Company"].ToString(),
                            ImagePath = row["ImagePath"].ToString(),
                            Title = row["Title"].ToString(),
                            Price = Convert.ToInt32(row["Price"]),
                            Id = Convert.ToInt32(row["Id"])
                        };
                        res = el;
                    }
                    connection.Close();
                    if (itemsTable != null)
                        itemsTable.Clear();
                }
            }
            catch (Exception ex)
            {

            }
            

            return res;

        }

        public void Save()
        {
            //string query = "Begin Transaction commit";
            //ExecuteQuery(query);
            
        }

        public void Update(Item item)
        {


            string sqlQueryParam = 
                "Update Items " +
                "Set " +
                "Title = @Title," +
                "ImagePath = @ImagePath," +
                "Price = @Price," +
                "Company = @Company " +
                "Where Id = @Id";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sqlQueryParam, conn);

                SqlParameter param = new SqlParameter("@Title", SqlDbType.NVarChar, -1);
                param.Value = item.Title;
                comm.Parameters.Add(param);

                SqlParameter ImagePathParam = new SqlParameter("@ImagePath", SqlDbType.NVarChar, -1);
                ImagePathParam.Value = item.ImagePath;
                comm.Parameters.Add(ImagePathParam);

                SqlParameter PriceParam = new SqlParameter("@Price",SqlDbType.Int);
                PriceParam.Value = item.Price;
                comm.Parameters.Add(PriceParam);

                SqlParameter CompanyParam = new SqlParameter("@Company", SqlDbType.NVarChar, -1);
                CompanyParam.Value = item.Company;
                comm.Parameters.Add(CompanyParam);

                SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int);
                idParam.Value = item.Id;
                comm.Parameters.Add(idParam);


                try 
                {
                    int num = comm.ExecuteNonQuery();
                }
                catch(Exception ex) 
                {
                }
                
                comm.Dispose();
                if (conn != null)
                    conn.Close();

            }
        }
        public void SendToServer<T>(T elem) 
        {
            ClientTcpAction client = new ClientTcpAction();
            client.SendData(elem);
        }


    }
}
