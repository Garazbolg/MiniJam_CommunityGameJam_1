using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(fileName ="New Slider Variable",menuName ="Variables/Slider")]
	public class SliderVariable : ScriptableObject
	{
		public FloatReference MaxValue;
		private FloatVariable Value;

		SliderVariable(){
			Value = new FloatVariable();
			Value.Value = MaxValue.Value;
		}

		public float NormalizedValue(){
			return Value / MaxValue;
		}

		public void ApplyChange(float amount)
		{
			Value.ApplyChange(amount);
		}

		public void ApplyChange(FloatVariable amount)
		{
			Value.ApplyChange(amount);
		}

		private void OnEnable()
		{
			Value.Value = MaxValue.Value;
		}
	}
}
