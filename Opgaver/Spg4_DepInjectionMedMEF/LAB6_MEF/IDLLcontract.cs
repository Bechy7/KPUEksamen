using System;

public interface IDllContract
{
    void Init(IAppUtil util);
    bool Run();
    void TearDown();
}
