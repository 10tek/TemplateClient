﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateClient.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
