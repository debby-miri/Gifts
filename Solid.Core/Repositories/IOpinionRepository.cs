using Gifts;
using Solid.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IOpinionRepository
    {
        Task<Opinion> AddOpinion(Opinion opinion);
    }
}
