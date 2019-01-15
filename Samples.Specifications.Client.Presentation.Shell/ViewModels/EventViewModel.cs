using System;
using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{   
    public sealed class EventViewModel : ObjectViewModel<IEvent>, IEventViewModel
    {
        public EventViewModel(IEvent model)
            : base(model)
        {

        }

        public DateTime Time => Model.Time;

        public string Message => Model.Message;
    }
}