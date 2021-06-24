using RCPylonRaceManagerWithSQLServer.Data;
using RCPylonRaceManagerWithSQLServer.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCPylonRaceManagerWithSQLServer.Forms
{
    public partial class EntryForm : Form
    {
        private readonly PylonDbContext _context;
        private readonly ISeason _season;

        public EntryForm(PylonDbContext context, ISeason season)
        {
            _context = context;
            _season = season;
            InitializeComponent();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void ShowSeason_Click(object sender, EventArgs e)
        {
            //var season = _context.Seasons.FirstOrDefault(x => x.Year == 2021);

            var season = await _season.GetASeason(2021);

            //var result = season.Result;
            MessageBox.Show($"{season.Year}");            
        }
    }
}
