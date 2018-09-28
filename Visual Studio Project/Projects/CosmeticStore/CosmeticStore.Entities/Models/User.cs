﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CosmeticStore.Models
{
    public class User
    {
        [Key]
        public int uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}