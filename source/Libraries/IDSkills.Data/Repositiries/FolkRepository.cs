using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

namespace IDSkills.Data
{
    public class FolkRepository: Repository<Folk>
    {
        public FolkRepository(FamousFolksContext context)
            : base(context)
        {
        }
    }
}
