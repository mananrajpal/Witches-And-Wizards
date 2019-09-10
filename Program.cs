using System;
using System.Collections.Generic;

namespace Task
{
	class MainClass
	{

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

}

