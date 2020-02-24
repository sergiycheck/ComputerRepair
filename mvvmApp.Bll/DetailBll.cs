using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTOs;
using mvvmApp.Bll.Mapper;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;

namespace mvvmApp.Bll
{
    public class DetailBll
    {
        Mapper.Mapper Mapper;
        private DetailsRepository<Detail> repository;
        public DetailBll()
        {
            repository = new DetailsRepository<Detail>
                (
                new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext")
                );
            Mapper = new Mapper.Mapper();
        }

        public List<DetailDTO> GetAll(int compId)
        {
            return Mapper.Convert(repository.GetCompDetails(compId));

        }

        public void Repair(int id)
        {
            var detail = repository.GetById(id);
            detail.Status = true;
            repository.Update(detail);
        }
    }
}
