namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService.MiddleWare;

public interface IContactsRepository
{
    void add(Contacts item);

    IEnumerable<Contacts> GetAll();

    Contacts Find(string key);

    void Remove(string id);

    void Update(Contacts item);

    bool CheckValidUserKey(string reqkey);
}