using System;
using System.Collections.Generic;

namespace Task
{
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
}

