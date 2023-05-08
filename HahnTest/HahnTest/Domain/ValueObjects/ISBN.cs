namespace HahnTest.Domain.ValueObjects
{
    public class ISBN
    {
        private string _value;

        public ISBN(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("ISBN cannot be empty or null.");
            }

            _value = value;
        }

        public override string ToString() => _value;
    }
}
