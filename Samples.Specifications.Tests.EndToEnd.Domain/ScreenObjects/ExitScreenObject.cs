using System;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Contracts.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects
{
    internal class ExitScreenObject : IExitScreenObject
    {
        public bool IsDisplayed()
        {
            var application = ApplicationContext.Application;
            Window exitWindow = null;
            try
            {
                exitWindow = application?.GetWindowByTitle("Exit options");
            }
            catch (Exception e)
            {
            }
            return exitWindow?.Visible ?? false;
        }

        public void ExitWithSave()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowByTitle("Exit options");

            var exitControl = exitWindow?.Get<Button>("ExitWithSave");
            exitControl?.Click();
        }

        public void ExitWithoutSave()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowByTitle("Exit options");

            var exitControl = exitWindow?.Get<Button>("ExitWithoutSave");
            exitControl?.Click();
        }

        public void Cancel()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowByTitle("Exit options");

            var exitControl = exitWindow?.Get<Button>("ExitCancel");
            exitControl?.Click();
        }
    }
}