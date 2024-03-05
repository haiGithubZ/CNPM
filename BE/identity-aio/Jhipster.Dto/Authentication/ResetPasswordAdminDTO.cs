// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jhipster.Dto.Authentication
{
    public class ResetPasswordAdminDTO
    {
        public string Login { get; set; }
        public string NewPassword { get; set; }
        public string RePassword { get; set; }
    }
}
