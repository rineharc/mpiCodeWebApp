using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mpiCodeWebApp.Data
{
    public interface IMpiCodeRepository
    {
        MPI_Code GetCode();
    }
}
