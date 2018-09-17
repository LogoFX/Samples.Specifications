using System;

// ReSharper disable once CheckNamespace
namespace LogoFX.Client.Mvvm.Commanding
{
    internal static class CommandFactory
    {
        internal static IActionCommand GetCommand(ref IActionCommand field, Func<bool> when, Action @do)
        {
            return field ?? (field = ActionCommand.When(when).Do(@do));
        }
    }
}
