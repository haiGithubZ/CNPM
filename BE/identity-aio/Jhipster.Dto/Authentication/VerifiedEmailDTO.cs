using System;
namespace Jhipster.Dto.Authentication
{
    public class VerifiedEmailDTO
    {
        public string Login { get; set; }
        public string Key { get; set; }
    }
    public class VerifiedEmailRqDTO
    {
        public string Login { get; set; }
        public string Value { get; set; }
    }
}

