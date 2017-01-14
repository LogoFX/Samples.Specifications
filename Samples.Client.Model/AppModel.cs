using System;
using LogoFX.Client.Mvvm.Model;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{
    //TODO: consider moving IsNew and Id to the model constructors
    internal abstract class AppModel : EditableModel<Guid>, IAppModel
    {        
        public bool IsNew { get; set; }
    }
}
