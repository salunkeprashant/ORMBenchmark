﻿using System;
using System.Collections.Generic;

namespace EFCoreBencher.EntityClasses
{
	/// <summary>Class which represents the entity 'ItemCategory'.</summary>
	public partial class ItemCategory : CommonEntityBase
	{
		#region Class Extensibility Methods
		/// <summary>Method called from the constructor</summary>
		partial void OnCreated();
		#endregion

		/// <summary>Initializes a new instance of the <see cref="ItemCategory"/> class.</summary>
		public ItemCategory() : base()
		{
			this.Inventories = new List<Inventory>();
			OnCreated();
		}

		/// <summary>Gets or sets the CategoryId field. </summary>
		public System.Int32 CategoryId { get; set;}
		/// <summary>Gets or sets the CategoryName field. </summary>
		public System.String CategoryName { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'Inventory.ItemCategory - ItemCategory.Inventories (m:1)'</summary>
		public List<Inventory> Inventories { get; set;}
	}
}
