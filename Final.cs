using System;

namespace Task
{
	public class Final
	{
		public Final ()
		{
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

		public static void Main (string[] args)
		{
			string decission;
			List<Student> students = new List<Student> ();
			//variable for storing student name entered by the user
			Student student1 = new Student("Manan");
			Student student2 = new Student ("Alex");
			Student student3 = new Student ("Jake");
			Student student4 = new Student ("Andrew");
			Student student5 = new Student ("Mitch");
			Student student6 = new Student ("Anthony");
			Student student7 = new Student ("Kayaz");
			Student student8 = new Student ("Lucky");
			Student student9 = new Student ("Naman");
			Student student10 = new Student ("Mannie");
			//adding students to the studentslist
			students.Add (student1);
			students.Add (student2);
			students.Add (student3);
			students.Add (student4);
			students.Add (student5);
			students.Add (student6);
			students.Add (student7);
			students.Add (student8);
			students.Add (student9);
			students.Add (student10);
			Console.WriteLine ("List of students");
			foreach (Student stud in students) 
			{
				Console.WriteLine (stud.GetName);
			}
			do
			{
				Console.WriteLine ("Please enter your name");
				string name = Console.ReadLine ();
				//checking name entered by students against student objects
				foreach (Student s in students) 
				{
					if (s.GetName == name) 
					{
						Console.WriteLine ("Hello " + name + " welcome to Swinwarts School of Wizadry");
						Console.WriteLine (s.GetName);
						//for allowing the user to set the skill type for that student
						Console.WriteLine ("Please select the Skill level\n" + "1: Novice \n" + "2: Adept\n" + "3: Master\n");
						String value  = Console.ReadLine ();
						switch (value) 
						{
						case "1":
							student1.SetSkill = Skill.Novice;
							break;
						case "2":
							student1.SetSkill = Skill.Adept;
							break;
						case "3":
							student1.SetSkill = Skill.Master;
							break;
						default :
							student1.SetSkill = Skill.Novice;
							break;
						}

						Console.WriteLine ("You know the following spells:");
						//using random class to create a random number to choose between different spells
						Random rnd = new Random ();
						int random = rnd.Next (1,5);
						switch (random) 
						{
						case 1:
							Teleportation teleportate = new Teleportation ("teleportate");
							teleportate.SetDifficulty = Difficulty.Hard;
							s.AddSpell (teleportate);
							Cast (teleportate, "This is a type of teleporation spell with difficulty hard", s);
							break;
						case 2:
							Healing heal = new Healing ("heal");
							heal.SetDifficulty = Difficulty.Easy;
							s.AddSpell (heal);
							Cast (heal, "This is a type of Healing spell with difficulty easy", s);
							break;
						case 3:
							Transmogrification trans = new Transmogrification ("transo");
							trans.SetDifficulty = Difficulty.Medium;
							s.AddSpell (trans);	
							//code for growing or shrinking size
							Console.WriteLine ("Would you like to grow or shrink size?");
							string size = Console.ReadLine ();
							if (size == "grow") 
							{
								trans.ChangeSize = SizeSpell.Grow;
							} 
							else 
							{
								trans.ChangeSize = SizeSpell.Shrink;
							}
							Cast (trans, "This is a type of Transmogrification spell with difficulty medium", s);

							break;
						default:
							Teleportation tel = new Teleportation ("tel");
							tel.SetDifficulty = Difficulty.Easy;
							s.AddSpell (tel);
							Cast (tel, "This is a type of Teleportation spell with difficulty easy", s);
							break;
						}
					}
				}
				Console.WriteLine("Would you like to continue?");
				decission = Console.ReadLine();
			}while(decission == "yes");
		}
		public static void Cast(Spell p, string s, Student student)
		{
			Console.WriteLine (p.GetName +" "+ s);
			Console.WriteLine ("Write the name of spell to cast it");
			string name = Console.ReadLine ();
			if (name == p.GetName) 
			{
				student.CastSpell (p);
			} 
			else 
			{
				Console.WriteLine ("You can only cast spell given above.");
			}
		}

	}

		public static void Cast(Spell p, string s, Student student)
		{
			Console.WriteLine (p.GetName +" "+ s);
			Console.WriteLine ("Write the name of spell to cast it");
			string name = Console.ReadLine ();
			if (name == p.GetName) 
			{
				student.CastSpell (p);
			} 
			else 
			{
				Console.WriteLine ("You can only cast spell given above.");
			}
		}

	}

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

