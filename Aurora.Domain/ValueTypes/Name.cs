using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aurora.Domain.ValueTypes
{
    public struct Name
    {
        private readonly string _value;
        public readonly Contract contract;

        private Name(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator Name(string value) =>
            new Name(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Inform a valid name.");

            if (_value.Length < 5)
                return AddNotification("The name must have more than 05 chars.");

            if (Regex.IsMatch(_value, (@"[^a-zA-Z]")))
                return AddNotification("The name must not contain any special characters or numbers.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Name), message);
            return false;
        }
    }
}
