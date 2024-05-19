using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserDomain.ControlModule;
using UserDomain.ControlModule.Interfaces;
using UserDomain.model;
using UserDomain.Model;

namespace CompetitionDesktopClient
{
    public partial class UserLookup : Form
    {
        private IUserManager userMaster = new UserManager();
        internal PrimeUser selectedUser = null;
        private List<PrimeUser> data;

        public UserLookup()
        {
            InitializeComponent();

            dgvUsers.AutoGenerateColumns = false;

            // load all users
            Task<PrimeUserCollection> allUsers = userMaster.GetAllActiveUsers();// default to active only
            PrimeUserCollection primeUsers = allUsers.Result;

            data = new List<PrimeUser>();

            foreach (PrimeUser usr in primeUsers)
            {
                data.Add(usr);
            }
            dgvUsers.DataSource = data;


        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvUsers.SelectedRows.Count > 0)
            {
                bOk.Enabled = true;
                string? codeFound = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();

                if(string.IsNullOrEmpty(codeFound) == false )
                {
                   PrimeUser? oneFound = data.Find(x => x.Code == codeFound);
                    if(oneFound != null )
                    {
                        selectedUser = oneFound;
                    }
                }

            }
            else
            {
                bOk.Enabled = false;    
            }
        }
    }
}
