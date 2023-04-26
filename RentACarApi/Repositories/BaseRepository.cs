using RentACarApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarApi.Repositories
{
    public class BaseRepository
    {
        public readonly DatabaseContext databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
