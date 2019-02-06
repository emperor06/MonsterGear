using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterGear
{
    public partial class MonsterUI : Form
    {
        private MonsterGear   app;
        private List<Skill>   selectedSkills = new List<Skill>();
        private List<SkillId> favorites      = new List<SkillId>();
        private AboutBox      about          = new AboutBox();
        private ResultControl resultControl  = new ResultControl();

        public MonsterUI()
        {
            try { app = MonsterGear.GetInstance(); }
            catch (Exception ex) { Error(ex.Message); }

            InitializeComponent();

            about.Visible = false;
            resultInfo.Text = "";
            skillNameText.Text = "";
            skillDescText.Text = "";
            skillExtraText.Text = "";

            skillsList.DataSource = MonsterGear.skills;
            favoritesList.DataSource = favorites;

            gemSlot1_Combo.DataSource = new int[] { 0, 1, 2, 3 };
            gemSlot2_Combo.DataSource = new int[] { 0, 1, 2, 3 };
            gemSlot3_Combo.DataSource = new int[] { 0, 1, 2, 3 };
            // These must be added here otherwise the event is fired when assigning DataSource, while not all combobox are ready.
            gemSlot1_Combo.SelectedIndexChanged += new EventHandler(this.weaponSlot_Changed);
            gemSlot2_Combo.SelectedIndexChanged += new EventHandler(this.weaponSlot_Changed);
            gemSlot3_Combo.SelectedIndexChanged += new EventHandler(this.weaponSlot_Changed);

            resultPanel.Controls.Add(resultControl);

            LoadConfig();
        }

        private void Error(string msg)
        {
            MessageBox.Show(msg, "MonsterGear Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            Environment.Exit(-1); // Because the latter doesn't work at all, at least while running it within Visual Studio ...
        }

        private void LoadConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                string conf = config.AppSettings.Settings["favs"].Value;
                if (conf != null && conf.Length != 0)
                {
                    string[] favs = conf.Split(';');
                    foreach (string f in favs)
                    {
                        try
                        {
                            int id = int.Parse(f);
                            SkillId s = MonsterGear.GetSkillId(id);
                            addFavorite(s);
                        }
                        catch (Exception) {} // Just discard this buggy favorite entry
                    }
                }
            }
            catch (Exception) {} // Happens at least when no config exists. It will be created when the program closes anyway.
        }

        public void SaveConfig()
        {
            if (favorites.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (SkillId s in favorites)
                {
                    sb.Append(s.id).Append(';');
                }
                sb.Remove(sb.Length - 1, 1);
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("favs");
                config.AppSettings.Settings.Add("favs", sb.ToString());
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }

        private Panel GetPanelForSkill(SkillId s)
        {
            FlowLayoutPanel reqPanel = new FlowLayoutPanel();
            reqPanel.AutoSize = true;
            reqPanel.Dock = System.Windows.Forms.DockStyle.Top;
            reqPanel.Location = new System.Drawing.Point(0, 0);
            reqPanel.Name = "reqPanel_" + s.id;
            reqPanel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 4);
            reqPanel.Size = new System.Drawing.Size(906, 36);
            reqPanel.WrapContents = false;

            Label reqLabel = new Label();
            reqLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reqLabel.Location = new System.Drawing.Point(3, 10);
            reqLabel.Name = "reqLabel_" + s.id;
            reqLabel.Size = new System.Drawing.Size(170, 16);
            reqLabel.Text = s.name;
            reqLabel.DoubleClick += (o, e) =>
            {
                Label lab = o as Label;
                int skId = int.Parse(lab.Name.Split('_')[1]);
                removeSelectedSkill(skId);
            };

            reqPanel.Controls.Add(reqLabel);

            for (int i = 1; i <= s.maxRank; ++i)
            {
                RadioButton reqRadio = new RadioButton();
                reqRadio.AutoSize = true;
                reqRadio.Location = new System.Drawing.Point(189 + (20 * i), 13);
                reqRadio.Name = "reqRank_" + s.id + "_" + i;
                reqRadio.Size = new System.Drawing.Size(14, 13);
                reqRadio.TabIndex = (i - 1);
                reqRadio.TabStop = true;
                reqRadio.UseVisualStyleBackColor = true;
                if (i == 1) reqRadio.Checked = true;
                reqRadio.CheckedChanged += (o, e) =>
                {
                    RadioButton r = o as RadioButton;
                    if (r.Checked)
                    {
                        string[] elems = r.Name.Split('_');
                        int skId = int.Parse(elems[1]);
                        int newRank = int.Parse(elems[2]);
                        updateSelectedSkillRank(skId, newRank);
                    }
                };

                reqPanel.Controls.Add(reqRadio);
            }

            return reqPanel;
        }

        private void help_Clicked(object sender, EventArgs e)
        {
            about.Visible = true;
        }

        private Slots GetWeaponSlots()
        {
            int s1 = ((int)gemSlot1_Combo.SelectedValue);
            int s2 = ((int)gemSlot2_Combo.SelectedValue);
            int s3 = ((int)gemSlot3_Combo.SelectedValue);

            Slots slots = new Slots();
            slots.Add(s1, 1);
            slots.Add(s2, 1);
            slots.Add(s3, 1);
            return slots;
        }

        private void updateUserRequest()
        {
            resultInfo.Text = "Please wait ...";
            resultInfo.Refresh();

            int found = executeSearch();

            switch (found)
            {
                case 0:
                    resultInfo.Text = "No armor found";
                    break;
                case -1:
                    resultInfo.Text = "Too many results";
                    break;
                default:
                    resultInfo.Text = found + " armors found";
                    break;
            }
            if (found > 0)
            {
                displayResults(/*sort*/);
            } else
            {
                clearResults();
            }
        }

        private void clearResults()
        {
            resultControl.Armors = null;
        }

        private void displayResults(/*sort*/)
        {
            List<ArmorSet> Results = app.GetResults();
            Results.Sort((a, b) => b.bonusScore.CompareTo(a.bonusScore));
            resultControl.Armors = Results;
        }

        private Label GetLabel(int txt, bool header = false)
        {
            return GetLabel(txt.ToString(), header);
        }

        private Label GetLabel(string txt, bool header = false)
        {
            Label res = new Label();
            res.SuspendLayout();
            res.Text = txt;
            if (header)
            {
                res.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                res.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                res.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            res.AutoSize = true;
            res.Size = new Size(44, 13);
            res.ResumeLayout();
            return res;
        }

        private int executeSearch()
        {
            return app.findArmors(selectedSkills, GetWeaponSlots());
        }

        bool _semaphore = false;
        private void skillList_Changed(object sender, EventArgs e)
        {
            if (_semaphore) return;

            try
            {
                _semaphore = true;
                var listBoxes = new ListBox[] { skillsList, favoritesList };
                foreach (var lst in listBoxes)
                {
                    if (sender == lst)
                    {
                        SkillId s = (SkillId)lst.SelectedValue;
                        updateSkillDetails(s);
                    } else
                    {
                        lst.SelectedIndex = -1;
                    }
                }
            } finally
            {
                _semaphore = false;
            }
        }

        private void skillList_DoubleClick(object sender, EventArgs e)
        {
            var lst = sender as ListBox;
            if (lst != null)
            {
                SkillId s = (SkillId)lst.SelectedValue;
                addSelectedSkill(s);
            }
        }

        private void skillList_Clicked(object sender, EventArgs e)
        {
            var lst = sender as ListBox;
            if ((lst != null) && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                SkillId sk = (SkillId)lst.SelectedValue;
                addFavorite(sk);
            }
        }

        private void favorites_Clicked(object sender, EventArgs e)
        {
            var lst = sender as ListBox;
            if (lst != null && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                SkillId sk = (SkillId)lst.SelectedValue;
                removeFavorite(sk);
            }
        }

        private void addSelectedSkill(SkillId s)
        {
            if (s != null && !selectedSkillsContains(s))
            {
                selectedSkills.Add(new Skill(s, 1));
                this.centerPanel.Controls.Add(GetPanelForSkill(s));
                updateUserRequest();
            }
        }

        private void removeSelectedSkill(int id)
        {
            var itemToRemove = selectedSkills.Single(r => r.skillId.id == id);
            selectedSkills.Remove(itemToRemove);
            Control[] panelToRemove = this.centerPanel.Controls.Find("reqPanel_" + id, false);
            if (panelToRemove != null && panelToRemove.Length != 0)
            {
                this.centerPanel.Controls.Remove(panelToRemove[0]);
            }
            updateUserRequest();
        }

        private bool selectedSkillsContains(SkillId s)
        {
            foreach (Skill skill in selectedSkills)
            {
                if (skill.skillId == s) return true;
            }
            return false;
        }

        private void updateSelectedSkillRank(int id, int newRank)
        {
            foreach (Skill skill in selectedSkills)
            {
                if (skill.skillId.id == id)
                {
                    skill.rank = newRank;
                    break;
                }
            }
            updateUserRequest();
        }

        private void updateSkillDetails(SkillId s)
        {
            if (s != null)
            {
                skillNameText.Text = s.name;
                skillDescText.Text = s.descToString();
                skillExtraText.Text = "Gem Level: " + s.gemLevel + ", Charm Rank: " + s.charmRank;
            }
            else
            {
                skillNameText.Text = "";
                skillDescText.Text = "";
                skillExtraText.Text = "";
            }
        }

        private void addFavorite(SkillId skill)
        {
            if (skill != null && !favorites.Contains(skill))
            {
                favoritesList.DataSource = null;
                favorites.Add(skill);
                favorites.Sort();
                favoritesList.DataSource = favorites;
            }
        }

        private void removeFavorite(SkillId skill)
        {
            if (skill != null && favorites.Contains(skill))
            {
                favoritesList.DataSource = null;
                favorites.Remove(skill);
                favorites.Sort();
                favoritesList.DataSource = favorites;
            }
        }

        private void weaponSlot_Changed(object sender, EventArgs e)
        {
            updateUserRequest();
        }
    }
}
