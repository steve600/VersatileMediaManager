using System;

namespace VersatileMediaManager.Communication.Interfaces
{
    public interface IDataAdapter<T1, T2, T3, T4, T5>
    {
        T1 Execute(T2 t2);

        T1 Execute(T3 t3, T4 t4);

        T1 Execute(T3 t3, T5 t5);

        IConnection Connection { get; }
    }
}