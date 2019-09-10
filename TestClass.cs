using NUnit.Framework;
using System;

namespace Task
{
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

