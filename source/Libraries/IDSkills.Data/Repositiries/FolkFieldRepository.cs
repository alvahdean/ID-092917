using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

namespace IDSkills.Data
{
    public class FolkFieldRepository: Repository<FolkField>
    {
        public FolkFieldRepository(FamousFolksContext context)
            : base(context)
        {
        }
    }
}
