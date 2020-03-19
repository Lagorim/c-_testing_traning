﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressbookTest
{
    public class BaseTest
    {
        protected ApplicationManager application;

        [SetUp]
        public void SetupApplicationManager()
        {
            application = ApplicationManager.GetInstance();
        }  
    }
}
