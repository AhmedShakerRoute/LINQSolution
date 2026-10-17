using System.Diagnostics.CodeAnalysis;

namespace LINQ.Models
{
	public class CompareBasedOnUnitInStock : IComparer<Product>
	{
		public int Compare(Product? x, Product? y)
		{
			if(x is null)
			{
				if (y is null) return 0;
				return -1;
			}

			return x.UnitsInStock.CompareTo(y?.UnitsInStock);
		}

		
	}

	public class CompareBasedOnIdProduct : IEqualityComparer<Product>
	{
		public bool Equals(Product? x, Product? y)
		{
			if (x is null)
			{
				if (y is null) return true;
				return false;
			}
			return x.ProductID.Equals(y?.ProductID);
		}
		public int GetHashCode([DisallowNull] Product obj)
		{
			return obj.ProductID.GetHashCode();
		}
	}


	public class Product : IComparable<Product>
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Category { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }

		//public override bool Equals(object? obj)
		//{
		//	Product? product = obj as Product;
		//	if (product is null) return false;
		//	return this.ProductID.Equals(product.ProductID) && this.ProductName.Equals(product.ProductName)
		//		&& this.Category.Equals(product.Category)
		//		&& this.UnitPrice.Equals(product.UnitPrice)
		//		&& this.UnitsInStock.Equals(product.UnitsInStock);
		//}
		//public override int GetHashCode()
		//{
		//	return this.ProductID.GetHashCode() ^ this.ProductName.GetHashCode() 
		//		^ this.Category.GetHashCode() ^ this.UnitsInStock.GetHashCode() 
		//		^ this.UnitPrice.GetHashCode();
		//}
		public int CompareTo(Product? other) => this.UnitPrice.CompareTo(other?.UnitPrice);

		public override string ToString() => $"ProductID={ProductID}, ProductName={ProductName}, Category={Category}, UnitPrice={UnitPrice:C2}, UnitsInStock={UnitsInStock}";
	}
}
