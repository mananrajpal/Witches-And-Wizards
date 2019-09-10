using System;

namespace Task
{
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
}

