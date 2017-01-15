using System;
using System.Threading.Tasks;
using System.Windows;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModel.Shared;

namespace Samples.Specifications.Client.Presentation.Shell
{
    class DefaultMessageService : IMessageService
    {
        public MessageResult Show(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None)
        {
            throw new NotImplementedException();
        }

        public Task<MessageResult> ShowAsync(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None)
        {
            throw new NotImplementedException();
        }

        public MessageResult ShowError(Exception error, string caption = "")
        {
            MessageBox.Show("Error", "Exit options");
            return MessageResult.OK;            
        }
    }
}