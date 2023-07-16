using System.Collections.Generic;

namespace UnitOfWork.Services
{
    public interface IDataSource<T>
    {
        IEnumerable<T> Get();
    }

    public class PlantillaDataSource: IDataSource
    {

    }
}