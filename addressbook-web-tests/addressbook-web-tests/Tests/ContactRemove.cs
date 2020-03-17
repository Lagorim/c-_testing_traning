﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookTest
{
    [TestFixture]
    public class ContactRemove : BaseTest
    {
        [Test]
        public void RemoveContact()
        {
            application.Contacts.Remove();
            application.CloseDialogWindow();
        }

    }
}