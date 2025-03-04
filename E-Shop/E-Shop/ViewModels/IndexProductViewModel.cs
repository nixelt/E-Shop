﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.ViewModels
{
    public class IndexProductViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int OldPrice { get; set; }

        public byte[] Image { get; set; }
    }
}