using static LINQ.DataSources.Source;
using LINQ.Models;
using System.Collections;

namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Session01

			#region Var vs dynamic
			//var name = "Shaker";
			//Console.WriteLine(name.GetType().Name);
			//name = 10; Invalid
			//Compiler Can Detect DataType Of Variable based on Value at Compile Time
			//We Must initialize Var Varible 
			//We Cannot initialize With Null
			//First Initialize

			//dynamic name = "Shaker";
			//name = 10;
			//name = 10.5;
			//dynamic name = null; Invalid
			//Console.WriteLine(name);
			//CLR Can Detect DataType Of Variable Based on Last Initialize at RunTime
			//We May Initialize Dynamic Variable
			// We Can Initialize With Null
			// Last Initialize

			//var std = new Student() { Name = "Shaker", Grade = 90, Major = "CS" };
			//Console.WriteLine(std.Name);//More Safe

			//dynamic std02 = new Student() { Name = "Shaker", Grade = 90, Major = "CS" };
			//Console.WriteLine(std02.Age); //Less Safe
			#endregion


			#region Anonymous Type
			//var emp01 = new { Id = 1, Name = "Shaker", Salary = 1000 };
			//Console.WriteLine(emp01.GetType().Name); //Anonymous0`3
			//var emp02 = new { Id = 1 ,Name = "Shaker" , Salary = 1000 };
			//Console.WriteLine(emp02.GetType().Name); //Anonymous0`3

			//Anonymous Immutable Type

			//Console.WriteLine(emp02.GetType() == emp01.GetType());
			// 1. The Same Properties Name(Case Sensitive)
			// 2. in The Same Order

			//Console.WriteLine(emp01.Equals(emp02));//Based On Value
			//Console.WriteLine(emp01 == emp02);//Based On Reference

			//var emp01 = new { Id = 1, Name = "Shaker", Salary = 1000 };

			//var emp02 = new {Id = 2, emp01.Name, NewSalary= emp01.Salary };

			//var emp02 = emp01 with { Salary = 2000 }; 
			#endregion

			#region Whats LINQ

			//LINQ => Language Integrated Query
			// LINQ Consists Of +40 Operator
			// Divided into 13 Category
			// againt Sequence Of Data (Object Of Class) [ORM]
			// at (SQL Server - MySQL - Oracle ---)
			// All Extension Methods inside Class Called Enummerable
			// USe LINQ Operators With Any Sequence (Object Of Class) implement IEnummerable 
			//Local Sequence L2O - L2XML
			//Remote Sequence L2EF

			//var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			//Even Numbers
			//1. Fluent Sentax (Method)
			//1.Throw Static Class

			//var EvenNumbers = Enumerable.Where(numbers, (N) => N % 2 == 0);


			//2.Throw Extension Methods [Recommend]

			//var EvenNumbers = numbers.Where((P) => P % 2 == 0);


			//2. Query Sentax [Like Sql Syntax]
			//Start With From 
			//End With select or Group By

			//EvenNumbers = from n in numbers
			//			  where n % 2 == 0
			//			  select n; //*


			//var std = new List<Student>(){

			//	new Student() { Name = "Ali", Grade = 80, Major = "CS" },
			//	new Student() { Name = "Ahmed", Grade = 90, Major = "CS" },
			//	new Student() { Name = "Mohamed", Grade = 100, Major = "CS" },
			//	new Student() { Name = "Mohamed", Grade = 75, Major = "IT" },
			//	new Student() { Name = "Mohamed", Grade = 70, Major = "SW" }

			//};

			//var Students = std.Where((s) => s.Grade > 70 && s.Major =="CS")
			//	.OrderByDescending(s => s.Name)
			//	.Select(s => new { s.Name, s.Grade, s.Major });


			//var QueryStd = from s in std
			//			   where s.Grade > 70 && s.Major == "CS"
			//			   orderby s.Name descending
			//			   select new { s.Name, s.Grade };


			#endregion

			#region Defered Execution vs Immediate Execution

			//var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			//var evenNumbers = numbers.Where((n) => n % 2 == 0).ToList();// 2  4 6  8  10
			//var evenNumbers02 = numbers.Where((n) => n % 2 == 0);// 2  4 6  8  10
			//															//Where Operator => Difered Execution



			//numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

			//foreach (var item in evenNumbers)
			//{
			//	Console.WriteLine(item); //2 4 6 8 10 12 14
			//}

			#endregion

			#region Filtering - Where - OfType<T> Defered Execxution

			//var Products = ProductList.Where((p) => p.UnitsInStock > 0 && p.Category == "Beverages");
			//Return From First 10 Products The Products That Have UnitsInStock > 0 and Category = "Beverages"

			//ue inedx to Retrieve First 10 Products -- doesnt have index in Query sytax
			//var Products = ProductList.Where((p, i) => p.Category == "Beverages" && p.UnitsInStock > 0 && i < 10);



			//ArrayList Products = new ArrayList() { 
			//	"Shaker", "Ahmed", "Ali", 
			//	1, 2, 3, 
			//	10.5, 20.5, 30.5 
			//};

			//var FilteredItems = Products.OfType<string>();
			////var FilteredItems = Products.Cast<string>();



			//foreach (var item in FilteredItems)
			//{
			//	Console.WriteLine(item);
			//}





			#endregion

			#region (Projection / Transform ) Select , SelectMany Defered Execution
			//var ProductNames = ProductList.Select((P) => P.ProductName);


			//var ProductNames = from p in ProductList
			//				   select p.ProductName;

			//var Numbers = new List<int>() { 5, 3 , 2 , 7 , 8 , 9 , 6 , 7 , 10};
			//var num = Numbers.Select(P => P > 5);
			////Inplace

			////var NumbeersInPlace = Numbers.Select((n, i) => new {Number = n , InPlace = n==i});
			//var numbersInSequence = Numbers.Select((P, i) => $"{i + 1} = {P}");





			//SelectMany => Transform Each Element in Sequence to Another Sequence and Flatten the Resulting Sequence

			//var result = CustomerList.SelectMany(o => o.Orders);


			#endregion


			#region Ordering - Defered Execution



			////var result = ProductList.OrderBy(P => P.UnitPrice);
			//var result = ProductList.OrderBy(P => P.UnitsInStock).ThenByDescending(P => P.UnitPrice);

			////result = from P in ProductList
			////		 orderby P.UnitPrice descending
			////		 select P;




			//var numbers = new List<int>() { 5, 3, 2, 7, 8, 9, 6, 7, 10 };

			//var result = numbers.Reverse<int>();


			#endregion



			#endregion

			#region Session02

			#region Element Operators - Immediate Execution
			//var MyProductList = new List<Product>();

			//var result = MyProductList.First();
			//result = ProductList.Last();

			//var result = MyProductList.LastOrDefault();
			//var result = ProductList.FirstOrDefault(((P) => P.Category == "Beverage"), new Product() { ProductName = "Default Product" });

			////var result = ProductList.ElementAt(1);
			//var result = ProductList.ElementAtOrDefault(1000);

			//var DiscountedProduct = new List<Product>() ;

			//var result = DiscountedProduct.Single();
			//          Return If There are only one element in the Sequence
			//          Throw Exception if The Sequence is Empty
			//          Throw Exception if The Sequence has more than element

			//result = ProductList.Single((P) => P.ProductID == 2200);

			//var result = DiscountedProduct.SingleOrDefault(new Product() { ProductName = "Default Product" });
			//          Throw Exception if The Sequence has more than element
			//          Return Product If There are only one element in the Sequence
			//          If There are Empty Sequence Return The Specified Product

			//var result = DiscountedProduct.SingleOrDefault((P) => P.Category == "Beverages");
			//          Throw Exception if The Sequence has more than element Match Condition
			//          If There are Empty Sequence Return The Default Value

			//result = ProductList.SingleOrDefault(((P) => P.Category == "Beverage"), new Product() { ProductName = "Default Product" });
			//          Throw Exception if The Sequence has more than element Match Condition
			//          If There are Empty Sequence Return The Default Specified Value
			//          If There are Doesnt Match Condition on The Sequence Return The Default Specified Value

			//Hybrid Synatx
			//var result01 = (from p in ProductList
			//				where p.UnitsInStock == 0
			//				select p).FirstOrDefault();


			//Console.WriteLine(result?.ProductName ?? "NA");

			#endregion

			#region Aggregate Operators - Immediate Execution
			//var DiscountedProduct = new List<Product>() ;

			//var result = DiscountedProduct.Count();
			//result = ProductList.Count((P) => P.Category == "Spices & Condiments");

			//var result = ProductList.Sum(P => P.UnitPrice);
			//var result = DiscountedProduct.Sum(P => P.UnitPrice);


			//var result = ProductList.Max(new CompareBasedOnUnitInStock());
			//var result = ProductList.Max(P => P.UnitPrice);

			//.NET06 - C#10 2021
			//var result = ProductList.MaxBy(P => P.UnitPrice);
			// result = ProductList.MaxBy(P => P.UnitsInStock);

			//Console.WriteLine(result);



			////Specification Pattern
			//string[] name = { "Ahmed", "Shaker", "Abdelfattah" };
			//string message = "Hello";
			//var result = name.Aggregate((FirstWord, SecondWord) => $"{FirstWord} {SecondWord}");
			// result = name.Aggregate( message,(FirstWord, SecondWord) => $"{FirstWord} {SecondWord}");
			// result = name.Aggregate( message,(FirstWord, SecondWord) => $"{FirstWord} {SecondWord}");


			//Console.WriteLine(result);

			#endregion

			#region Quantifiers Operators - Immediate Execution
			//var EmptyProducts = new List<Product>();

			//var result = EmptyProducts.Any();
			// result = EmptyProducts.Any(P => P.Category == "Bevevvfrages");

			//var result = ProductList.Contains<Product>(new Product { ProductID = 1, ProductName = "Black Tea 250g", Category = "Beverages", UnitPrice = 60.0000M, UnitsInStock = 39 });
			//var result = ProductList.Contains<Product>(IEqualityComparer)


			//result = ProductList.Count();
			//Console.WriteLine(result);





			#endregion

			#region Partitioning Operators - Defered Execution
			//var emptyList = new List<Product>();
			////var result = emptyList.Take(3);

			//var Products = ProductList.TakeWhile((P , I) => P.UnitsInStock > 0 && I < 10);

			#endregion

			#region Set Operators - Defered Execution

			var numbers = new List<int>() { 1, 2, 3, 3, 3, 6, 6, 8, 9, 10 };
			//var result = ProductList.DistinctBy(P => P.Category);

			//var Sequnce01 = Enumerable.Range(1, 49);
			//var Sequnce02 = Enumerable.Range(30, 70);

			int x = 10;
			Console.WriteLine(x.GetHashCode());

			//var sequence03 = Sequnce01.Union(Sequnce02);//From Sequence 01 + Sequence 02 Without Duplication
			////var sequence03 = Sequnce01.Intersect(Sequnce02);
			//var sequence03 = Sequnce01.Except(Sequnce02);


			//var Sequence01 = new List<Product>()
			//{
			//				new Product { ProductID = 1, ProductName = "Black Tea 250g", Category = "Beverages", UnitPrice = 60.0000M, UnitsInStock = 39 },
			//new Product { ProductID = 2, ProductName = "Green Tea 100g", Category = "Beverages", UnitPrice = 45.0000M, UnitsInStock = 17 },
			//new Product { ProductID = 3, ProductName = "Tahini 500g", Category = "Spices & Condiments", UnitPrice = 95.0000M, UnitsInStock = 13 },

			//};
			//var Sequence02 = new List<Product>()
			//{
			//				new Product { ProductID = 1, ProductName = "Black Tea 250g", Category = "Beverages", UnitPrice = 60.0000M, UnitsInStock = 39 },
			//				new Product { ProductID = 4, ProductName = "Cumin Powder 200g", Category = "Spices & Condiments", UnitPrice = 45.0000M, UnitsInStock = 53 },
			//              new Product { ProductID = 5, ProductName = "Coriander Powder 200g", Category = "Spices & Condiments", UnitPrice = 42.5000M, UnitsInStock = 0 },


			//};




			//var sequence03 = Sequence01.Union(Sequence02, new CompareBasedOnIdProduct());


			#endregion
			#endregion


			//foreach (var item in sequence03)
			//{
			//	Console.WriteLine(item);
			//}
		}
	}
}
