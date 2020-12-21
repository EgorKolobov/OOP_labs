namespace Lab5
{
    public interface IBuilder
    {
        void SetName(string name);
        void SetSurname(string surname);
        void SetPassportID(int passportId);
        void SetAddress(string address);
    }
}