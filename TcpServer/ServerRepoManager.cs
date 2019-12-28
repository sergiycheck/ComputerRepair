using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;

namespace TcpServer
{
    public class ServerRepoManager
    {
        ItemRepositoryADO itemRepoAdo;
        OrderRepositoryADO orderRepositoryADO;
        UserRepository<User> userRepo;
        ItemRepositoryEF itemRepoEF;
        OrderRepositoryEF orderRepoEF;
        public ServerRepoManager() 
        {
            itemRepoAdo = new ItemRepositoryADO();
            orderRepositoryADO = new OrderRepositoryADO();
            ApplicationContext context = new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext");
            userRepo = new UserRepository<User>(context);
            itemRepoEF = new ItemRepositoryEF(context);
            orderRepoEF = new OrderRepositoryEF(context);
        }
        public void CreateItem(Item item) 
        {
            try
            {
                try
                {
                    itemRepoAdo.Create(item);
                }
                catch (Exception ex)
                {

                }
                
                itemRepoEF.Create(item);
            }
            catch (Exception ex) 
            {
            }
            
        }
        public void CreateOrder(Order order) 
        {
            try
            {
                try
                {
                    orderRepositoryADO.Create(order);
                }
                catch (Exception ex)
                {

                }
                
                orderRepoEF.Create(order);
            }
            catch(Exception ex) 
            {

            }
            
        }
        public void CreateUser(User user)
        {
            try 
            {
                userRepo.Create(user);
            }catch(Exception ex) 
            {

            }
            
        }
    }
}
