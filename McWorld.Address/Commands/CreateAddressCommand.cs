namespace McWorld.Address
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using System.Collections.Generic;

    public class CreateAddressCommand : ICommand
    {
        public ICollection<Address> Addresses { get; private set; }
        public CreateAddressCommand(ICollection<Address> addresses)
        {
            Addresses = addresses;
        }
    }
}
