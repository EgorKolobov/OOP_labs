using System.Xml.XPath;

namespace Lab5
{
    public class ClientBuilder : IBuilder
    {
        private Client _client = new Client();

        public ClientBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            _client = new Client();
        }

        public void SetName(string name)
        {
            this._client.SetName(name);
        }

        public void SetSurname(string surname)
        {
            this._client.SetSurname(surname);
        }

        public void SetAddress(string address)
        {
            this._client.SetAddress(address);
        }

        public void SetPassportID(int passportId)
        {
            this._client.SetPassportId(passportId);
        }

        public Client GetClient()
        {
            var result = this._client;
            this.Reset();
            return result;
        }
    }
}