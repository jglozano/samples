namespace InferredPoco.Models {
	using System;
	
	[Serializable]
	public class Person {
		public Guid Id {get; set; }
		public string Name {get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == typeof (Person) && Equals((Person) obj);
		}

		public bool Equals(Person other) {
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || other.Id.Equals(Id);
		}

		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
