﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class DetailsRepository<T>:GenericRepository<T> where T : Detail
    {
        public DetailsRepository(ApplicationContext context) : base(context) 
        {

        }
    }
}
