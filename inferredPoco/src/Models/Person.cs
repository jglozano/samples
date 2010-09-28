namespace inferredPoco.Models {
	using System;
	
	[Serializable]
	public class Person {
		public Guid Id {get; set; }
		public string Name {get; set; }
	}
}
