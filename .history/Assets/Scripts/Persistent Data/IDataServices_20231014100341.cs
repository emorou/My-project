

public interface IDataServices 
{
    bool saveData<T>(string Relativepath, T data, bool Encrypted);

    T LoadData<T>()
}
