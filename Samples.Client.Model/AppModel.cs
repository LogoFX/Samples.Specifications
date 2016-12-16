using System;
using LogoFX.Client.Mvvm.Model;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{
    internal abstract class AppModel : EditableModel<Guid>, IAppModel
    {
    }
}
