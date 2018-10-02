﻿using System;
using System.Threading.Tasks;
using Solid.Practices.Scheduling;

namespace Samples.Client.Model
{
    internal static class ServiceRunner
    {
        public static async Task RunAsync(Action method) => await TaskRunner.RunAsync(method);

        public static async Task<TResult> RunWithResultAsync<TResult>(Func<TResult> method) =>
            await TaskRunner.RunAsync(method);

        public static async Task RunAsync(Func<Task> method) =>
            await await TaskRunner.RunAsync(async () => await method());

        public static async Task<TResult> RunWithResultAsync<TResult>(Func<Task<TResult>> method) =>
            await await TaskRunner.RunAsync(async () => await method());
    }
}