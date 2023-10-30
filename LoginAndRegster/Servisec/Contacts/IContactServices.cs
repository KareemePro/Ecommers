namespace LoginAndRegster.Servisec.Contacts
{
    public interface IContactServices
    {
        Task SendMessage(Contact model);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact?> GetById(int id);
        bool Delete(int id);
    }
}
