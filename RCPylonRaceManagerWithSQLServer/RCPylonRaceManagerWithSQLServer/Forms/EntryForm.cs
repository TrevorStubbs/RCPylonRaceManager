using RCPylonRaceManagerWithSQLServer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCPylonRaceManagerWithSQLServer.Forms
{
    public partial class EntryForm : Form
    {
        private readonly PylonDbContext _context;

        public EntryForm(PylonDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowSeason_Click(object sender, EventArgs e)
        {
            var season = _context.Seasons.FirstOrDefault(x => x.Year == 2021);

            MessageBox.Show($"{season.Year}");
        }
    }
}
