using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage
{
    public partial class FormTweak : Form
    {

        private FormMain main;
        private ByteStream romStream;

        private List<Tank> areaTanks;
        private List<Tank> increaseTanks;
        private List<ElevatorPair> elevatorPairs;
        private List<MapIcon> mapIcons;
        private List<Hatch> hatches;
        private List<BreakBlock> breakBlocks;
        private List<Statue> statueList;

        public FormTweak(FormMain main)
        {
            InitializeComponent();

            this.main = main;
            this.romStream = ROM.Stream;

            TweakData.GetData();
            LoadTank();
        }

        private void LoadTank() 
        {
            LoadAreaTank();
            //MF: USA or Europe have no increase amounts
            if (Version.GameCode == "AMTE" || Version.GameCode == "AMTP") 
                button_applyIncrease.Visible = dataGridView_increaseTank.Visible = label_increaseTank.Visible = false;
            else LoadIncreaseTank();
        }

        private void LoadAreaTank()
        {
            areaTanks = new List<Tank>();
            for (int i = 0; i < 8; i++)
            {
                areaTanks.Add(new Tank(romStream, i, false));
            }
            dataGridView_areaTanks.AutoGenerateColumns = false;
            dataGridView_areaTanks.DataSource = areaTanks;
            if(Version.IsMF) dataGridView_areaTanks.Columns["superTank"].Visible = false;
        }

        private void LoadIncreaseTank()
        {
            increaseTanks = new List<Tank>();
            for (int i = 0; i < TweakData.Difficulty.Count; i++)
            {
                increaseTanks.Add(new Tank(romStream, i, true));
            }
            dataGridView_increaseTank.AutoGenerateColumns = false;
            dataGridView_increaseTank.DataSource = increaseTanks;
            if (Version.IsMF) dataGridView_increaseTank.Columns["superTank"].Visible = false;
        }

        private void LoadElevator()
        {
            elevatorPairs = new List<ElevatorPair>();
            if (Version.IsMF)
            {
                for (int i = 0; i < 11; i++)
                {
                    elevatorPairs.Add(new ElevatorPair(romStream, i));
                }
                //hide two coordinate columns, because they don't exist in fusion
                dataGridView_elevators.Columns["coord1Elevator"].Visible = dataGridView_elevators.Columns["coord2Elevator"].Visible = false;
            }
            else
            {
                //in zm, pair 0 is unknow data, skip
                for (int i = 1; i < 9; i++)
                {
                    elevatorPairs.Add(new ElevatorPair(romStream, i));
                }
            }
            dataGridView_elevators.AutoGenerateColumns = false;
            area1Elevator.Items.AddRange(Version.AreaNames);
            area2Elevator.Items.AddRange(Version.AreaNames);
            dataGridView_elevators.DataSource = elevatorPairs;
        }

        private void LoadHatchBlockIcon()
        {
            LoadHatch();
            LoadBlock();
            LoadMapIcon();
        }

        private void LoadHatch()
        {
            if(romStream.Read8(TweakData.HatchFlashOffset) == 0xE0) checkBox_hatchFlash.Checked = true;
            hatches = new List<Hatch>();
            for (int i = 0; i < 4; i++)
            {
                hatches.Add(new Hatch(romStream, i));
            }
            comboBox_hatchType.SelectedIndex = 0;
            numericUpDown_hatchHits.Hexadecimal = Hex.ToHex;
        }

        private void LoadBlock()
        {
            breakBlocks = new List<BreakBlock>();
            for (int i = 0; i < TweakData.BreakableBlocks.Count; i++)
            {
                breakBlocks.Add(new BreakBlock(romStream, i));
            }
            comboBox_blockType.DataSource = TweakData.BreakableBlocks;
            comboBox_blockType.SelectedIndex = 0;
        }

        private void LoadMapIcon()
        {
            mapIcons = new List<MapIcon>();
            for (int i = 0; i < 7; i++)
            {
                mapIcons.Add(new MapIcon(romStream, i));
            }
            dataGridView_mapIcons.AutoGenerateColumns = false;
            eventMapIcon.DataSource = TweakData.Events;
            typeMapIcon.DataSource = TweakData.MapIcon;
            //eventMapIcon.Items.AddRange(TweakData.Events);
            //typeMapIcon.Items.AddRange(TweakData.MapIcon);
            dataGridView_mapIcons.DataSource = mapIcons;
            //foreach(DataGridViewRow row in dataGridView_mapIcons.Rows)
            //    row.Cells["eventMapIcon"].ToolTipText = (string)row.Cells["eventMapIcon"].Value;
        }

        private void LoadStatue()
        {
            statueList = new List<Statue>();
            for (int i = 0;i < 10;i++) 
                statueList.Add(new Statue(romStream, i));
            dataGridView_statue.AutoGenerateColumns = false;
            statueArea.Items.AddRange(Version.AreaNames);
            statueTargetArea.Items.AddRange(Version.AreaNames);
            statueStartIcon.DataSource = TweakData.StatueIcon.Values.ToArray();
            statueEndIcon.DataSource = TweakData.StatueIcon.Values.ToArray();
            statueCheckType.DataSource = TweakData.CheckType;
            statueTriggerEvent.DataSource = TweakData.Events;

            dataGridView_statue.DataSource = statueList;

            //initialize equip/event column
            var rows = dataGridView_statue.Rows;
            foreach (DataGridViewRow row in rows)
            {
                var quipEventRow = row.Cells["statueEquipEvent"] as DataGridViewComboBoxCell;
                quipEventRow.DataSource = row.Cells["statueCheckType"].Value switch
                {
                    "Beam/bombs" => TweakData.BeamBomb,
                    "Suit/misc" => TweakData.SuitMisc,
                    "Event" => TweakData.Events,
                    _ => TweakData.Events
                };
            }
        }

        private void button_applyTank_Click(object sender, EventArgs e)
        {
            if(areaTanks == null ||  areaTanks.Count == 0) return;
            //check total of all area tanks
            byte[] checks = {0, 0, 0, 0};
            for (int i = 0; i < Version.AreaNames.Length; i++)
            {
                checks[0] += Hex.ToByte(areaTanks[i].Energy);
                checks[1] += Hex.ToByte(areaTanks[i].Missile);
                checks[2] += Hex.ToByte(areaTanks[i].Super);
                checks[3] += Hex.ToByte(areaTanks[i].Power);
            }
            if (checks[0] != Hex.ToByte(areaTanks[areaTanks.Count - 1].Energy) || checks[1] != Hex.ToByte(areaTanks[areaTanks.Count - 1].Missile)
                || checks[2] != Hex.ToByte(areaTanks[areaTanks.Count - 1].Super) || checks[3] != Hex.ToByte(areaTanks[areaTanks.Count - 1].Power))
            {
                var result = MessageBox.Show("总计数量不对与各区物品数量合集不同，是否继续保存？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;
            }
            //for (int i = 0; i <= Version.AreaNames.Length; i++) areaTanks[i].Write(romStream, i, false);
            for (int i = 0; i <= Version.AreaNames.Length; i++) areaTanks[i].Write(romStream);

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl.SelectedIndex)
            {
                case 0:
                    LoadTank();
                    break; 
                case 1:
                    LoadElevator();
                    break;
                case 2:
                    LoadHatchBlockIcon();
                    break;
                case 3:
                    LoadStatue();
                    break;
                default:
                    LoadTank();
                    break;
            }

        }

        private void button_applyElevator_Click(object sender, EventArgs e)
        {
            if(elevatorPairs == null ||  elevatorPairs.Count == 0) return;
            foreach (ElevatorPair pair in elevatorPairs)
            {
                pair.Write(romStream);
            }
        }

        private void comboBox_hatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown_hatchHits.Value = hatches[comboBox_hatchType.SelectedIndex].Hits;

            for (int index = 0; index < checkedListBox_hatchWeakness.Items.Count; index++)
            {
                checkedListBox_hatchWeakness.SetItemChecked(index, hatches[comboBox_hatchType.SelectedIndex].Weakness.HasFlag((Weakness)Math.Pow(2, index)));
            }
        }

        private void comboBox_blockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < checkedListBox_blockWeakness.Items.Count; index++)
            {
                if (index != checkedListBox_blockWeakness.Items.Count -1) checkedListBox_blockWeakness.SetItemChecked(index, breakBlocks[comboBox_blockType.SelectedIndex].Weakness.HasFlag((Weakness)Math.Pow(2, index)));
                else checkedListBox_blockWeakness.SetItemChecked(index, breakBlocks[comboBox_blockType.SelectedIndex].Weakness.HasFlag(Weakness.BombChain));
            }
        }

        private void button_hatchApply_Click(object sender, EventArgs e)
        {
            //set hitFlash state
            if (checkBox_hatchFlash.Checked) romStream.Write8(TweakData.HatchFlashOffset, 0xE0);
            else romStream.Write8(TweakData.HatchFlashOffset, 0xD0);
            hatches[comboBox_hatchType.SelectedIndex].Hits = (ushort)numericUpDown_hatchHits.Value;
            Weakness weakness = Weakness.None;
            for (int index = 0; index < checkedListBox_hatchWeakness.Items.Count; index++)
            {
                if (checkedListBox_hatchWeakness.GetItemChecked(index)) weakness |= (Weakness)Math.Pow(2, index);
            }
            hatches[comboBox_hatchType.SelectedIndex].Weakness = weakness;
            hatches[comboBox_hatchType.SelectedIndex].Write(romStream);
        }

        private void button_blockApply_Click(object sender, EventArgs e)
        {
            Weakness weakness = Weakness.None;
            for (int index = 0; index < checkedListBox_blockWeakness.Items.Count; index++)
            {
                if (checkedListBox_blockWeakness.GetItemChecked(index) && index != checkedListBox_blockWeakness.Items.Count - 1) weakness |= (Weakness)Math.Pow(2, index);
                else if (checkedListBox_blockWeakness.GetItemChecked(index)) weakness |= Weakness.BombChain;
            }
            breakBlocks[comboBox_blockType.SelectedIndex].Weakness = weakness;
            breakBlocks[comboBox_blockType.SelectedIndex].Write(romStream);
        }

        private void button_mapIconApply_Click(object sender, EventArgs e)
        {
            if(mapIcons == null || mapIcons.Count == 0) { return; }
            foreach (MapIcon mapIcon in mapIcons)
            {
                mapIcon.Write(romStream);
            }
        }

        private void button_applyIncrease_Click(object sender, EventArgs e)
        {
            if(increaseTanks == null || increaseTanks.Count == 0) return;
            foreach (Tank tank in increaseTanks)
                tank.Write(romStream);
        }

        private void button_statueApply_Click(object sender, EventArgs e)
        {
            if (statueList == null || statueList.Count == 0) return;
            for (int i = 0; i < statueList.Count; i++)
                statueList[i].Write(romStream, i);
        }

        private void dataGridView_statue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if ((e.ColumnIndex == dataGridView_statue.Columns["statueCheckType"].Index))
            {
                var row = dataGridView_statue.Rows[e.RowIndex];
                if (row != null)
                {
                    string typeValue = row.Cells[e.ColumnIndex].Value as string;
                    var euipEvent = row.Cells[dataGridView_statue.Columns["statueEquipEvent"].Index] as DataGridViewComboBoxCell;

                    euipEvent.DataSource = typeValue switch
                    {
                        "Beam/bombs" => TweakData.BeamBomb,
                        "Suit/misc" => TweakData.SuitMisc,
                        "Event" => TweakData.Events,
                        _ => TweakData.Events
                    };
                }
            }
        }
    }
}
