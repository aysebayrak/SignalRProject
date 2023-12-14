﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class MenuTable
	{
		public int MenuTableId { get; set; }
		public string MenuTableName { get; set; }
		public bool MenuTableStatus { get; set; }
		public List<Basket> Baskets { get; set; }
	}
}
