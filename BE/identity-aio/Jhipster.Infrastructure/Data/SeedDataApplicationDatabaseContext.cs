// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Jhipster.Crosscutting.Constants;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jhipster.Infrastructure.Data
{
    public class SeedDataApplicationDatabaseContext
    {
        private readonly ModelBuilder modelBuilder;

        public SeedDataApplicationDatabaseContext(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {

        }
    }
}
