﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using RCPylonRaceManagerWithRazorPages.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISeason _season;

        public int Year { get; set; }
        public SeasonDTO SeasonDTO { get; set; }
        public IHtmlContent ListData { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISeason season)
        {
            _logger = logger;
            _season = season;
        }

        public async Task<IActionResult> OnGet()
        {
            var season = await _season.GetASeason(2021);
            SeasonDTO = new SeasonDTO()
            {
                Year = season.Year
            };

            var builder = new HtmlContentBuilder();

            builder.AppendFormat($"<td>{season.Year}</td>");

            ListData = builder;

            return Page();
        }
    }
}
