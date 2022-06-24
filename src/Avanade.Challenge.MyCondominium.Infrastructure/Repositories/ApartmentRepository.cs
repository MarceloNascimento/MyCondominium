using Avanade.Challenge.MyCondominium.Domain.Repositories;
using Avanade.Challenge.MyCondominium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Challenge.MyCondominium.Infra.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Apartment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Apartment> Insert(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public Task<Apartment> Update(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}
