using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Fornecedores.Models.ViewModels;

namespace CRUD_Fornecedores.Data
{
    public class CRUD_FornecedoresContext : DbContext
    {
        public CRUD_FornecedoresContext (DbContextOptions<CRUD_FornecedoresContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_Fornecedores.Models.Provider>? Provider { get; set; }
    }
}
