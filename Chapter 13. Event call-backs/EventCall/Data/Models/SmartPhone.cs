namespace EventCall.Data.Models
{
    public class SmartPhone
    {
        public int Id { get; set; }
        public string SmartPhoneName { get; set; }

        public bool IsAvailable { get; set; }

        public string Price { get; set; }

        public List<Feature> SmartPhoneFeatures { get; set; }
    }

    public class Feature
    {
        public string Specification { get; set; }

        public string Value { get; set; }
    }
}
