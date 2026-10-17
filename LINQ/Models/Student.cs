using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
	internal class Student
	{
		public string Name { get; set; }
		public int Grade { get; set; }
		public string Major { get; set; }

		public override string ToString() => $"{Name} - {Grade} - {Major}";
	}
}
