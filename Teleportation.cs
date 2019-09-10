using System;

namespace Task
{
	public class Teleportation : Spell
	{

		public Teleportation (string name):base(name)
		{
		}
		public override void Success(Student s)
		{
			//display the message for success
			s.GetDistance = s.GetDistance + 4;
			Console.WriteLine ("You have been teleported by 4 km to " + s.GetDistance);
		}
		public override void Failure(Student s)
		{
			s.GetHealth = s.GetHealth - 5;
			//display the message for Failure
			Console.WriteLine ("Thug! Thug!");
			Console.WriteLine ("Your spell failed and your health has been reduced to " + s.GetHealth);

		}

	}
}

