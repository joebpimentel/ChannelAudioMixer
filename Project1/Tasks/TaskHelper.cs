﻿using System;
using System.Threading.Tasks;
using AudioChannelMixer.Infrastrucure.Error;

namespace AudioChannelMixer.Infrastrucure.Tasks
{
    public static class TaskHelper
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}