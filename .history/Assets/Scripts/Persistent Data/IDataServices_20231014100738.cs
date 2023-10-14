public interface IDataServices 
{
    bool saveData<T>(string Relativepath, T Data, bool Encrypted);

    T LoadData<T>(string RelativePath, bool Encrypted);
}
