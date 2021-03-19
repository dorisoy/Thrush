﻿using MvvmCross.Commands;

namespace Thrush.Core.Helpers
{
    public class OpenSource
    {
        public string Title { get; set; }
        public IMvxAsyncCommand<OpenSource> Command { get; set; }
        public string Url { get; set; }
    }
}
