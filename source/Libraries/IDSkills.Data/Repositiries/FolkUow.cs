using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

namespace IDSkills.Data
{
    public class FamousFolksUow: UnitOfWork<FamousFolksContext>
    {
        public FamousFolksUow(FamousFolksContext context)
            : base(context)
        {
        }

        public IRepository<Folk> GetFolkRepository()
        {
            return GetRepository<Folk>();
        }

        public IRepository<FolkField> GetFolkFieldRepository()
        {
            return GetRepository<FolkField>();
        }
    }
}
