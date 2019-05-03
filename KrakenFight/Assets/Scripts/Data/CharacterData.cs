using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Variables;

namespace Game.Data
{
	[CreateAssetMenu]
	public class CharacterData : ScriptableObject
	{
		public SliderVariable HP;
		public FloatVariable Speed;
		public FloatVariable Damage;
	}

}