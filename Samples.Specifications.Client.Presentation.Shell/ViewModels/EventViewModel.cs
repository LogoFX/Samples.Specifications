using System;
using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    public sealed class EventViewModel : ObjectViewModel<IEvent>
    {
        public EventViewModel(IEvent model)
            : base(model)
        {

        }

        public DateTime Time => Model.Time;

        public string Message => Model.Message;
    }
}