using ContactManager.DAL.Entities;
using ContactManager.DAL.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.DAL.Repositories.Interfaces;

public interface IContactDataRepository : IRepositoryBase<ContactData>
{
}
