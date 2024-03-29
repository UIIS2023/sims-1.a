﻿using InitialProject.Model;
using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Domain.RepositoryInterfaces
{
    public interface IGuideRepository:IGenericRepository<Guide>
    {
        public Guide GetByUsername(string username);

        public Guide Update(Guide guide);
    }
}
