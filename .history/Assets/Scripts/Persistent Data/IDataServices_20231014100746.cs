public interface IDataServices 
{
    bool SaveData<T>(string Relativepath, T Data, bool Encrypted);

    T LoadData<T>(string RelativePath, bool Encrypted);
}
