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
        //common
        private List<Tank> areaTanks;
        private List<Tank> increaseTanks;
        private List<ElevatorPair> elevatorPairs;
        //zero mission
        private List<MapIcon> mapIcons;
        private List<Hatch> hatches;
        private List<BreakBlock> breakBlocks;
        private List<Statue> statueList;
        private List<Target> targets;
        //fusion
        private List<NavRoom> navRooms;
        private List<SuitDamageReduction> suitDamageReductionList;
        private List<DimLight> dimLightList;
        private List<Monologue> monologueList;
        private List<Security> securities;
        private List<FusionEventInfo> fusionEventInfos;

        public FormTweak(FormMain main)
        {
            InitializeComponent();

            this.main = main;
            this.romStream = ROM.Stream;
            InitTabpages();
        }

        private void InitTabpages()
        {
            TweakData.GetData();
            //remove unsupport pages
            if (Version.IsMF)
            {
                tabControl.TabPages.RemoveByKey("tabPage_hatch");
                tabControl.TabPages.RemoveByKey("tabPage_statue");
            }
            else
            {
                tabControl.TabPages.RemoveByKey("tabPage_nav");
                tabControl.TabPages.RemoveByKey("tabPage_fusionMisc");
                tabControl.TabPages.RemoveByKey("tabPage_fusionEvent");
            }
            //load first page
            LoadTankPage();
        }

        private void LoadTankPage() 
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

        private void LoadElevatorPage()
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
            if (Version.IsMF)
            {//add number of elevator for monologue events
                dataGridView_elevators.RowHeadersWidth = 45;
                foreach (DataGridViewRow row in dataGridView_elevators.Rows)
                {
                    row.HeaderCell.Value = Hex.ToString(row.Index);
                }
            }
        }

        private void LoadHatchBlockIconPage()
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
            dataGridView_mapIcons.DataSource = mapIcons;
        }

        private void LoadStatuePage()
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

        private void LoadNavPage()
        {
            LoadNavRoom();
            LoadTarget();
        }

        private void LoadNavRoom()
        {
            navRooms = new List<NavRoom>();
            for (int i = 0; i < 12; i++)
            {
                navRooms.Add(new NavRoom(romStream, i));
            }
            navRoom_area.Items.AddRange(Version.AreaNames);
            dataGridView_navRoom.DataSource = navRooms;
            dataGridView_navRoom.RowHeadersWidth = 50;
            foreach (DataGridViewRow row in dataGridView_navRoom.Rows)
            {
                row.HeaderCell.Value = Hex.ToString(row.Index);
            }
        }

        private void LoadTarget()
        {
            targets = new List<Target>();
            for (int i = 0; i < 0x21; i++)
                targets.Add(new Target(romStream, i));
            navTarget_area.DataSource = TweakData.TargetArea;
            navTarget_direction.DataSource = TweakData.TargetDirection;
            dataGridView_navTarget.AutoGenerateColumns = false;
            dataGridView_navTarget.DataSource = targets;
        }
        
        private void LoadFusionMiscPage()
        {
            LoadSuit();
            LoadDimEvent();
            LoadMonologue();
            LoadSecurity();
        }

        private void LoadSuit()
        {
            suitDamageReductionList = new List<SuitDamageReduction>();
            for (int i = 0;i < 4; i++)
                suitDamageReductionList.Add(new SuitDamageReduction(romStream, i));
            suit_fusion.Items.AddRange(SuitDamageReduction.percent);
            suit_varia.Items.AddRange(SuitDamageReduction.percent);
            suit_gravity.Items.AddRange(SuitDamageReduction.percent);
            dataGridView_suit.DataSource = suitDamageReductionList;
        }

        private void LoadDimEvent()
        {
            dimLightList = new List<DimLight>();
            for(int i = 0; i < 4; i++)
                dimLightList.Add(new DimLight(romStream, i));
            dimEvent_event.DataSource = TweakData.Events;
            dataGridView_dimEvent.DataSource = dimLightList;
        }

        private void LoadMonologue()
        {
            monologueList = new List<Monologue>();
            for(int i = 0; i < 6 ; i++)
                monologueList.Add(new Monologue(romStream, i));
            monologue_event.DataSource = TweakData.Events;
            monologue_subEventStart.DataSource = monologue_subEventEnd.DataSource = TweakData.SubEvent;
            dataGridView_monologue.DataSource = monologueList;
        }

        private void LoadSecurity()
        {
            securities = new List<Security>();
            for(int i = 0;i < 4 ; i++)
                securities.Add(new Security(romStream, i));
            security_level.Items.AddRange(Security.levels);
            security_area.Items.AddRange(Version.AreaNames);
            security_preEvent.DataSource = security_newEvent.DataSource = TweakData.Events;
            security_subEvent.DataSource = TweakData.SubEvent;
            dataGridView_security.DataSource = securities;
        }

        private void LoadFusionEventPage()
        {
            fusionEventInfos = new List<FusionEventInfo>();
            for(int i = 0; i < TweakData.Events.Count ; i++)
                fusionEventInfos.Add(new FusionEventInfo(romStream, i));
            fusionEvent_area.Items.AddRange(Version.AreaNames);
            //FF means not use this parameter
            fusionEvent_area.Items.Add("FF");
            fusionEvent_eventType.DataSource = TweakData.EventType;
            dataGridView_fusionEvent.AutoGenerateColumns = false;
            dataGridView_fusionEvent.DataSource = fusionEventInfos;
            //add number of event
            dataGridView_fusionEvent.RowHeadersWidth = 55;
            foreach (DataGridViewRow row in dataGridView_fusionEvent.Rows)
            {
                row.HeaderCell.Value = Hex.ToString(row.Index);
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
            switch(tabControl.SelectedTab.Name)
            {
                case "tabPage_tank":
                    LoadTankPage();
                    break;
                case "tabPage_elevator":
                    LoadElevatorPage();
                    break;
                case "tabPage_hatch":
                    LoadHatchBlockIconPage();
                    break;
                case "tabPage_statue":
                    LoadStatuePage();
                    break;
                case "tabPage_nav":
                    LoadNavPage();
                    break;
                case "tabPage_fusionMisc":
                    LoadFusionMiscPage();
                    break;
                case "tabPage_fusionEvent":
                    LoadFusionEventPage();
                    break;
                default:
                    LoadTankPage();
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

        private void button_navRoomApply_Click(object sender, EventArgs e)
        {
            if (navRooms == null || navRooms.Count == 0) return;
            foreach (NavRoom room in navRooms) 
                room.Write(romStream);
        }

        private void button_navTargetApply_Click(object sender, EventArgs e)
        {
            if(targets == null || targets.Count == 0) { return; }
            foreach (Target target in targets)
                target.Write(romStream);
        }

        private void button_dimEventApply_Click(object sender, EventArgs e)
        {
            if (dimLightList == null || dimLightList.Count == 0) return;
            foreach(DimLight dimLight in dimLightList)
                dimLight.Write(romStream);
        }

        private void button_securityApply_Click(object sender, EventArgs e)
        {
            if(securities == null || securities.Count == 0) return ;
            foreach(Security sec in securities)
                sec.Write(romStream);
        }

        private void button_monologueApply_Click(object sender, EventArgs e)
        {
            if(monologueList == null || monologueList.Count == 0) return;
            foreach(Monologue monologue in monologueList)
                monologue.Write(romStream);
        }

        private void button_suitApply_Click(object sender, EventArgs e)
        {
            if(suitDamageReductionList == null || suitDamageReductionList.Count == 0) return;
            foreach(SuitDamageReduction suitDamageReduction in suitDamageReductionList)
                suitDamageReduction.Write(romStream);
        }

        private void dataGridView_fusionEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView_fusionEvent.Columns["fusionEvent_apply"].Index) return;
            fusionEventInfos[e.RowIndex].Write(romStream);
        }
    }
}
