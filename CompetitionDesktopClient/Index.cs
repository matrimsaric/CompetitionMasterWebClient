namespace CompetitionDesktopClient
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bUserManagement_Click(object sender, EventArgs e)
        {
            UserMaster userMaster = new UserMaster();
            userMaster.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player pl = new Player();
            pl.ShowDialog(this);
        }
    }
}
