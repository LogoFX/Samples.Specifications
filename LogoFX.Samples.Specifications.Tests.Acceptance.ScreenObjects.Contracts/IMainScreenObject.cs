using System.Collections.Generic;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts
{
    public interface IMainScreenObject
    {
        IEnumerable<object> GetWarehouseItems();
    }
}