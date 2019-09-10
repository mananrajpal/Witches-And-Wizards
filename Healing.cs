using System;

namespace Task
{
	public class Healing : Spell
	{
		public Healing (string name):base(name)
		{
		}
		public override void Success(Student s)
		{
			//display the message for success
			s.GetHealth = s.GetHealth  + 5;
			Console.WriteLine ("Your health has been restored to " +  s.GetHealth );
		}
		public override void Failure(Student s)
		{
			//display the message for Failure
			s.GetHealth  = s.GetHealth  - 5;
			Console.WriteLine ("Your cast failed and your health has been reduced to " + s.GetHealth );
		}
	}
}

