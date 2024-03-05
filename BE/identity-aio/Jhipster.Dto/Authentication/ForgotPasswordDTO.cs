// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jhipster.Dto.Authentication
{
    public class ForgotPasswordDTO
    {
    }

    public class ForgotPasswordOTPRqDTO
    {
        public string Login { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }


    public class ForgotPasswordResetRqDTO
    {
        public string Login { get; set; }
        public string Key { get; set; }
    }

    public class ForgotPasswordMethodRsDTO
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class ForgotPasswordCompleteRpDTO
    {
        public string NewPassword { get; set; }
        public string Login { get; set; }
        public string Key { get; set; }
    }
}
