﻿namespace Zundoko.Web.Models.Abstracts
{
    public interface ILayoutViewModel
    {
        public AppSettings AppSettings { get; set; }

        public string Title { get; set; }
    }
}
