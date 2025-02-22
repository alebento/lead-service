namespace LeadsService.Domain.Enums
{
    public enum LeadStatusEnum
    {
        [StringValue("New")]
        New,
        [StringValue("Accepted")]
        Accepted,
        [StringValue("Declined")]
        Declined
    }

    public class StringValueAttribute : Attribute
    {
        public string Value { get; }
        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
