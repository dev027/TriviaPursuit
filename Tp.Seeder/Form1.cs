using System.Windows.Forms;
using Tp.Seeder.Seeds;

namespace Tp.Seeder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnSeedCategories.Click += BtnSeedCategories_Click;
        }

        /// <summary>
        /// BtnSeedCategories_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.InvalidOperationException">Ignore.</exception>
        private void BtnSeedCategories_Click(object sender, System.EventArgs e)
        {
            var seeded = CategorySeeder.Seed();

            var icon = seeded ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
            var message = seeded ? "Categories seeded" : "Categories already seeded";

            MessageBox.Show(message, @"Seed Categories", MessageBoxButtons.OK, icon);
        }
    }
}
