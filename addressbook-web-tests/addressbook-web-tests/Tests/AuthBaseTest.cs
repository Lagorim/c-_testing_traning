﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    public class AuthBaseTest : BaseTest
    {
        [SetUp]
        public void SetUpLogin()
        {
            application.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
