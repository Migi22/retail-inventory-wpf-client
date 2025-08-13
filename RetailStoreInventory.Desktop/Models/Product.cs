using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreInventory.Desktop.Models
{
    /// <summary>
    /// Represents a product in the retail store inventory system.
    /// This is a data model class that holds the essential information about each product.
    /// 
    /// In MVVM architecture, this is part of the "Model" layer - the data structure.
    /// The ViewModels will use this model to display and manipulate product data.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// This is typically auto-generated and used as the primary key in databases.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the product.
        /// This is what customers see and what staff use to identify products.
        /// The 'required' keyword ensures this field cannot be null (C# 11+ feature).
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product currently in stock.
        /// This is used for inventory management and low-stock alerts.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// Using decimal type for precise financial calculations (avoid floating-point errors).
        /// </summary>
        public decimal Price { get; set; }
    }
}
