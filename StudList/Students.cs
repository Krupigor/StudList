using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudList
{
	class Students: IComparable<Students>
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public int Group { get; set; }

		public int ID { get; set; }
		int x = 0;
		int newbranch = 9;


		public int CompareTo(Students s)
		{
			return this.Name.CompareTo(s.Name);
		}
	}
}
