using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Documents.SystemFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mpiCodeWebApp.Data
{
    public class MPICodeRepository : IMpiCodeRepository
    {
        private string _connectionString;

        public MPICodeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MPI_Code GetCode()
        {
            var storage = CloudStorageAccount.Parse(_connectionString);
            var tblclient = storage.CreateCloudTableClient(new TableClientConfiguration());
            var table = tblclient.GetTableReference("mpicodes");

            var code = table.ExecuteQuery(new TableQuery<MPI_Code>().Take(1)).FirstOrDefault();

            if (code != null) { 
                var delete = TableOperation.Delete(code);

                table.Execute(delete);
            }
            
            return code;
        }
    }
}
