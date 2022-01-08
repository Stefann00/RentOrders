using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using RentOrders.Models;

namespace RentOrders.Data
{
    public class OrderDatabase
    {
            readonly SQLiteAsyncConnection _database;
            public OrderDatabase(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<OrderList>().Wait();
                 _database.CreateTableAsync<Car>().Wait();
                _database.CreateTableAsync<ListCar>().Wait();
        }

        public Task<int> SaveCarAsync(Car car)
        {
            if (car.ID != 0)
            {
                return _database.UpdateAsync(car);
            }
            else
            {
                return _database.InsertAsync(car);
            }
        }

        public Task<int> DeleteCarAsync(Car car)
        {
            return _database.DeleteAsync(car);
        }
        public Task<List<Car>> GetCarsAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }


        public Task<List<OrderList>> GetOrderListsAsync()
            {
                return _database.Table<OrderList>().ToListAsync();
            }
            public Task<OrderList> GetOrderListAsync(int id)
            {
                return _database.Table<OrderList>()
                .Where(i => i.ID == id)
               .FirstOrDefaultAsync();
            }
            public Task<int> SaveOrderListAsync(OrderList olist)
            {
                if (olist.ID != 0)
                {
                    return _database.UpdateAsync(olist);
                }
                else
                {
                    return _database.InsertAsync(olist);
                }
            }
            public Task<int> DeleteOrderListAsync(OrderList olist)
            {
                return _database.DeleteAsync(olist);
            }

        public Task<int> SaveListCarAsync(ListCar listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Car>> GetListCarsAsync(int orderlistid)
        {
            return _database.QueryAsync<Car>(
            "select C.ID, C.Model, C.Color from Car C"
            + " inner join ListCar LC"
            + " on C.ID = LC.CarID where LC.OrderListID = ?",
            orderlistid);
        }
    }
}
