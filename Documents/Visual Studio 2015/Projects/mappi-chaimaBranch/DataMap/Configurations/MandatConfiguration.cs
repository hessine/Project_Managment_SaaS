﻿using DomainMap;
using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Configurations
{
  public  class MandatConfiguration : EntityTypeConfiguration<Mandate>
    {
        public MandatConfiguration()
        {
            
        }

    }
}