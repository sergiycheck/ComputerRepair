using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mvvmApp.Dal.Abstract.Repositories
{
    public class OrderRepositoryADO : IRepository<Order>
    {
        string connectionString;
        readonly DataContext db;
        DataTable orderAndItems;
        SqlDataAdapter adapter;
        //private readonly DataTable orderDataTable;

        public OrderRepositoryADO()
        {
            string settings = ConfigurationManager.AppSettings["config"];
            connectionString = ConfigurationManager.ConnectionStrings["MvvmAppDb"].ConnectionString;
            db = new DataContext(connectionString);
        }

        public void Create(Order order)
        {
            db.GetTable<Order>().InsertOnSubmit(order);

            db.SubmitChanges();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var el in order.ItemOrders)
                {
                    string sqlQuery =
                    "Insert into OrderItems (Order_Id, Item_Id)" +
                    "values (@Order_Id,@Item_Id)";
                    
                    
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    SqlParameter OrderIdParam = new SqlParameter("@Order_Id", order.Id);
                    comm.Parameters.Add(OrderIdParam);
                    SqlParameter ItemIdParam = new SqlParameter("@Item_Id", el.ItemId);
                    comm.Parameters.Add(ItemIdParam);
                    int num = comm.ExecuteNonQuery();
                    comm.Dispose();
                }

                if (conn != null)
                {
                    conn.Close();
                }
                    
            }
        }
        public void Delete(int id)
        {
            Order orderToDelete = GetItem(id);
            db.GetTable<Order>().DeleteOnSubmit(orderToDelete);
            db.SubmitChanges();
        }
        public void DeleteComputerFromOrder(int id)
        {
            string sqlQuery =
                "Delete from OrderItems" +
                "Where Item_Id = @id";
            orderAndItems = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                SqlParameter titleParam = new SqlParameter("@id", id);
                comm.Parameters.Add(titleParam);
                adapter = new SqlDataAdapter(comm);

                int num = comm.ExecuteNonQuery();
                //MessageBox.Show(num.ToString());//remove
                if (conn != null)
                    conn.Close();
            }
        }
        public IEnumerable<Order> GetAllItems()
        {
            Table<Order> orders = db.GetTable<Order>();
            return orders.ToList();
        }
        public Table<Order> GetTable()
        {
            return db.GetTable<Order>();
        }

        public Order GetItem(int id)
        {
            return db.GetTable<Order>().FirstOrDefault(or => or.Id == id);
        }

        public IList<Item> GetOrderedItems(int id)
        {
            string sqlQuery =
                "select i.Id,i.Title,i.ImagePath,i.Price,i.Company " +
                "from Items i " +
                "inner join OrderItems oi on i.Id = oi.Item_Id " +
                "inner join Orders o on oi.Order_Id = o.Id " +
                "where o.Id = @id;";
            var result = new List<Item>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                SqlParameter titleParam = new SqlParameter("@id", id);
                comm.Parameters.Add(titleParam);
                adapter = new SqlDataAdapter(comm);
                orderAndItems = new DataTable();

                adapter.Fill(orderAndItems);

                
                foreach (DataRow row in orderAndItems.Rows)
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
                if (conn != null)
                    conn.Close();
            }
            return result;
        }

        #region MyRegion

        //private void ExecuteQuery(string sqlQuery)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand comm = new SqlCommand(sqlQuery, conn);
        //        int num = comm.ExecuteNonQuery();
        //        if (conn != null)
        //            conn.Close();
        //        comm.Dispose();
        //        if (orderDataTable != null)
        //            orderDataTable.Clear();
        //    }
        //}

        #endregion

        public void Save()
        {
            //string query = "Begin Transaction commit";
            //ExecuteQuery(query);
            db.SubmitChanges();
        }

        public void Update(Order order)
        {
            Order orderToUpdate = db.GetTable<Order>().FirstOrDefault(or => or.Id == order.Id);
            orderToUpdate = order;
            db.SubmitChanges();
        }
    }
}
