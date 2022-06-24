﻿using Avanade.Challenge.MyCondominium.Domain.Entities;

namespace Avanade.Challenge.MyCondominium.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment> Insert(Apartment apartment);
        Task<Apartment> Update(Apartment apartment);
        Task<bool> Delete(Apartment apartment);
        Task<IList<Apartment>> GetAll();
    }
}