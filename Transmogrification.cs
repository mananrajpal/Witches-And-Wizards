using System;

namespace Task
{
	public class Transmogrification : Spell
	{
		SizeSpell sizefactor;
		public Transmogrification (string name):base(name)
		{
		}
		public SizeSpell ChangeSize
		{
			get
			{ 
				return sizefactor;
			}
			set
			{ 
				sizefactor = value;
			}
		}
		public override void Success(Student s)
		{
			//increase size
			if (ChangeSize == SizeSpell.Grow) {
				s.GetSize = s.GetSize + 5;
				Console.WriteLine ("Your size has been increased to " + s.GetSize);
			} 
			else 
			{
				s.GetSize = s.GetSize - 5;
				Console.WriteLine ("Your size has been descreased to " + s.GetSize);
			}
		}
		public override void Failure(Student s)
		{
			//grow or shrink size
			if (ChangeSize == SizeSpell.Grow) {
				s.GetSize = s.GetSize - 5;
				Console.WriteLine ("Spell failed and your size has been descreased to " + s.GetSize);
			} 
			else 
			{
				s.GetSize = s.GetSize + 5;
				Console.WriteLine ("Spell failed and your size has been increased to " + s.GetSize);
			}
		}
	}
}

