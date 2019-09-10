using System;

namespace Task
{
	public class Code
	{
		public Code ()
		{
		}
	}
	public enum Skill
	{
		Novice ,
		Adept ,
		Master
	}
	public enum Difficulty
	{
		Easy ,
		Medium ,
		Hard 
	}
	public enum SizeSpell
	{
		Grow,
		Shrink
	}


	public abstract class Spell
	{

		Difficulty _difficulty;
		private string _name;
		public Spell (string name)
		{
			_name = name;
		}
		public String GetName
		{
			get 
			{ 
				return _name;
			}
		}


		public Difficulty SetDifficulty
		{
			//sets the difficulty of the spell
			get
			{ 
				return _difficulty;
			}
			set
			{ 
				_difficulty = value;
			}
		}


		public bool EvaluateSkill(Student s)
		{
			bool answer = false;
			//evaluates the difficulty type and skill
			if (SetDifficulty == Difficulty.Easy ) 
			{

				Random rnd = new Random ();
				int random = rnd.Next (1, 100);
				if (s.SetSkill == Skill.Novice)
				{
					if (random < 90) 
					{
						answer = true;
					} 
				} 
				else if (s.SetSkill == Skill.Adept) 
				{
					answer = true;
				} 
				else if (s.SetSkill == Skill.Master) 
				{
					answer = true;
				}

			} 
			else if (SetDifficulty == Difficulty.Medium) 
			{
				Random rnd = new Random ();
				int random = rnd.Next (1, 100);
				if (s.SetSkill == Skill.Novice) 
				{
					if (random < 40) 
					{
						answer = true;
					}
				} 
				else if (s.SetSkill == Skill.Adept) 
				{

					if (random < 80)
					{
						answer = true;
					} 
				} 
				else if (s.SetSkill == Skill.Master) 
				{
					answer = true;
				}
			}
			else if (SetDifficulty == Difficulty.Hard) 
			{
				Random rnd = new Random ();
				int random = rnd.Next (1, 100);
				if(s.SetSkill == Skill.Novice)
				{
					if (random < 10) 
					{
						answer = true;
					} 
				}
				else if (s.SetSkill == Skill.Adept) 
				{
					if (random < 50) 
					{
						answer = true;
					} 
				}
				else if (s.SetSkill == Skill.Master) 
				{
					answer = true;
				}
			}
			return answer;
		}
		public abstract void Success(Student s);
		public abstract void Failure(Student s);
	}
	public class Student
	{
		List<Spell> spells = new List<Spell>();
		Skill _skill;
		private string _name;
		private int _health;
		private int _distance;
		private int _size;

		public Student (string name)
		{
			_name = name;
			_health = 50;
			_distance = 0;
			_size = 55;

		}
		//property for getting name
		public String GetName
		{
			get 
			{ 
				return _name;
			}
			set
			{ 
				_name = value;
			}
		}
		//property for getting and setting health
		public int GetHealth
		{
			get 
			{ 
				return _health;
			}
			set
			{ 
				_health = value;
			}
		}
		//property for getting and setting distance
		public int GetDistance
		{
			get 
			{ 
				return _distance;
			}
			set
			{ 
				_distance = value;
			}
		}
		//property for getting and setting size
		public int GetSize
		{
			get 
			{ 
				return _size;
			}
			set
			{ 
				_size = value;
			}
		}
		//function to add a spell to the spell list
		public void AddSpell(Spell p)
		{
			//adds spell to spell list
			spells.Add (p);
		}
		//function for unit testing to check if the spell was added
		public bool CheckSpell(Spell name)
		{
			bool final = false;
			foreach (Spell p in spells) 
			{
				if (p == name) 
				{
					final = true;
				}
			}
			return final;
		}
		public Skill SetSkill
		{
			//sets the skill of the student
			get
			{ 
				return _skill;
			}
			set
			{ 
				_skill = value;
			}
		}

		public void CastSpell(Spell name)
		{
			//cast spell and checks whether the spell was success or failure
			foreach (Spell p in spells) 
			{
				if (p == name) 
				{
					bool evaulate = p.EvaluateSkill (this);
					if (evaulate == true) 
					{
						p.Success (this);
					} 
					else 
					{
						p.Failure (this);
					}

				}
			}
		}
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
		[TestFixture ()]
		public class TestClass
		{
			[Test ()]
			public void SetSkill ()
			{
				Student Manan = new Student ("Manan");
				Manan.SetSkill = Skill.Adept;
				Skill getskill = Manan.SetSkill;
				Assert.AreEqual (Skill.Adept, getskill);
			}
			[Test ()]
			public void SetDifficulty ()
			{
				Teleportation telpo = new Teleportation ("telpo");
				telpo.SetDifficulty = Difficulty.Hard;
				Difficulty getdifficulty = telpo.SetDifficulty;
				Assert.AreEqual (Difficulty.Hard , getdifficulty );
			}
			[Test ()]
			public void AddSpell ()
			{
				Student naman = new Student ("Manan");
				Teleportation typo = new Teleportation ("typo");
				Healing healo = new Healing ("healo");
				naman.AddSpell (typo);
				bool check = naman.CheckSpell (typo);
				Assert.AreEqual (true, check);
			}
			[Test()]
			public void Evaluate()
			{
				Student alex = new Student ("alex");
				Healing heal = new Healing ("heal");
				heal.SetDifficulty = Difficulty.Medium;
				alex.SetSkill = Skill.Novice;
				bool answer = heal.EvaluateSkill (alex);
				Assert.AreEqual (true, answer ,"Student with novice difficulty casting spell of difficulty medium with 40% chances of success.");
			}

		}





}

