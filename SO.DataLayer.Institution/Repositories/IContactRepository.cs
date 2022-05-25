using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Contact = SO.DataLayer.Institution.Model.Contact;

namespace SO.DataLayer.Institution.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact, int>
    {
    }
}
