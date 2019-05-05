
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(fileName = "New Boolean Variable", menuName = "Variables/Base/Boolean")]
	public class BoolVariable : ScriptableObject
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		public bool Value;

		public void SetValue(bool value)
		{
			Value = value;
		}

		public void SetValue(BoolVariable value)
		{
			Value = value.Value;
		}

		public void Toggle(){
			Value = !Value;
		}

		public static implicit operator bool(BoolVariable reference)
		{
			return reference.Value;
		}
	}
}