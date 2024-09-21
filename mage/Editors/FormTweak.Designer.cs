namespace mage
{
    partial class FormTweak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTweak));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_tank = new System.Windows.Forms.TabPage();
            this.dataGridView_increaseTank = new System.Windows.Forms.DataGridView();
            this.difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.energyIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.missileIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_applyIncrease = new System.Windows.Forms.Button();
            this.label_increaseTank = new System.Windows.Forms.Label();
            this.button_applyTank = new System.Windows.Forms.Button();
            this.dataGridView_areaTanks = new System.Windows.Forms.DataGridView();
            this.areaTank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.energyTank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.missileTank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superTank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerTank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_areaTanks = new System.Windows.Forms.Label();
            this.tabPage_elevator = new System.Windows.Forms.TabPage();
            this.button_applyElevator = new System.Windows.Forms.Button();
            this.dataGridView_elevators = new System.Windows.Forms.DataGridView();
            this.area1Elevator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.room1Elevator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coord1Elevator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area2Elevator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.room2Elevator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coord2Elevator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_hatch = new System.Windows.Forms.TabPage();
            this.button_mapIconApply = new System.Windows.Forms.Button();
            this.label_MapIcon = new System.Windows.Forms.Label();
            this.dataGridView_mapIcons = new System.Windows.Forms.DataGridView();
            this.eventMapIcon = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.typeMapIcon = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.mapX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pixelOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_block = new System.Windows.Forms.GroupBox();
            this.button_blockApply = new System.Windows.Forms.Button();
            this.label_blockWeakness = new System.Windows.Forms.Label();
            this.comboBox_blockType = new System.Windows.Forms.ComboBox();
            this.checkedListBox_blockWeakness = new System.Windows.Forms.CheckedListBox();
            this.label_blockType = new System.Windows.Forms.Label();
            this.groupBox_hatch = new System.Windows.Forms.GroupBox();
            this.checkBox_hatchFlash = new System.Windows.Forms.CheckBox();
            this.checkedListBox_hatchWeakness = new System.Windows.Forms.CheckedListBox();
            this.button_hatchApply = new System.Windows.Forms.Button();
            this.label_hatchWeakness = new System.Windows.Forms.Label();
            this.numericUpDown_hatchHits = new System.Windows.Forms.NumericUpDown();
            this.label_hatchHits = new System.Windows.Forms.Label();
            this.comboBox_hatchType = new System.Windows.Forms.ComboBox();
            this.label_hatchType = new System.Windows.Forms.Label();
            this.tabPage_statue = new System.Windows.Forms.TabPage();
            this.button_statueApply = new System.Windows.Forms.Button();
            this.dataGridView_statue = new System.Windows.Forms.DataGridView();
            this.statueArea = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueStartCoordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statueEndCoordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statueStartIcon = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueTargetArea = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueTargetCoordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statueEndIcon = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueCheckType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueEquipEvent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statueTriggerEvent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage_tank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_increaseTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_areaTanks)).BeginInit();
            this.tabPage_elevator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_elevators)).BeginInit();
            this.tabPage_hatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mapIcons)).BeginInit();
            this.groupBox_block.SuspendLayout();
            this.groupBox_hatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hatchHits)).BeginInit();
            this.tabPage_statue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_statue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_tank);
            this.tabControl.Controls.Add(this.tabPage_elevator);
            this.tabControl.Controls.Add(this.tabPage_hatch);
            this.tabControl.Controls.Add(this.tabPage_statue);
            this.tabControl.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_tank
            // 
            this.tabPage_tank.Controls.Add(this.dataGridView_increaseTank);
            this.tabPage_tank.Controls.Add(this.button_applyIncrease);
            this.tabPage_tank.Controls.Add(this.label_increaseTank);
            this.tabPage_tank.Controls.Add(this.button_applyTank);
            this.tabPage_tank.Controls.Add(this.dataGridView_areaTanks);
            this.tabPage_tank.Controls.Add(this.label_areaTanks);
            resources.ApplyResources(this.tabPage_tank, "tabPage_tank");
            this.tabPage_tank.Name = "tabPage_tank";
            this.tabPage_tank.UseVisualStyleBackColor = true;
            // 
            // dataGridView_increaseTank
            // 
            this.dataGridView_increaseTank.AllowUserToAddRows = false;
            this.dataGridView_increaseTank.AllowUserToDeleteRows = false;
            this.dataGridView_increaseTank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_increaseTank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.difficulty,
            this.energyIncrease,
            this.missileIncrease,
            this.superIncrease,
            this.powerIncrease});
            resources.ApplyResources(this.dataGridView_increaseTank, "dataGridView_increaseTank");
            this.dataGridView_increaseTank.Name = "dataGridView_increaseTank";
            this.dataGridView_increaseTank.RowTemplate.Height = 23;
            // 
            // difficulty
            // 
            this.difficulty.DataPropertyName = "Difficulty";
            resources.ApplyResources(this.difficulty, "difficulty");
            this.difficulty.Name = "difficulty";
            this.difficulty.ReadOnly = true;
            // 
            // energyIncrease
            // 
            this.energyIncrease.DataPropertyName = "Energy";
            resources.ApplyResources(this.energyIncrease, "energyIncrease");
            this.energyIncrease.MaxInputLength = 3;
            this.energyIncrease.Name = "energyIncrease";
            // 
            // missileIncrease
            // 
            this.missileIncrease.DataPropertyName = "Missile";
            resources.ApplyResources(this.missileIncrease, "missileIncrease");
            this.missileIncrease.MaxInputLength = 3;
            this.missileIncrease.Name = "missileIncrease";
            // 
            // superIncrease
            // 
            this.superIncrease.DataPropertyName = "Super";
            resources.ApplyResources(this.superIncrease, "superIncrease");
            this.superIncrease.MaxInputLength = 3;
            this.superIncrease.Name = "superIncrease";
            // 
            // powerIncrease
            // 
            this.powerIncrease.DataPropertyName = "Power";
            resources.ApplyResources(this.powerIncrease, "powerIncrease");
            this.powerIncrease.MaxInputLength = 3;
            this.powerIncrease.Name = "powerIncrease";
            // 
            // button_applyIncrease
            // 
            resources.ApplyResources(this.button_applyIncrease, "button_applyIncrease");
            this.button_applyIncrease.Name = "button_applyIncrease";
            this.button_applyIncrease.UseVisualStyleBackColor = true;
            this.button_applyIncrease.Click += new System.EventHandler(this.button_applyIncrease_Click);
            // 
            // label_increaseTank
            // 
            resources.ApplyResources(this.label_increaseTank, "label_increaseTank");
            this.label_increaseTank.Name = "label_increaseTank";
            // 
            // button_applyTank
            // 
            resources.ApplyResources(this.button_applyTank, "button_applyTank");
            this.button_applyTank.Name = "button_applyTank";
            this.button_applyTank.UseVisualStyleBackColor = true;
            this.button_applyTank.Click += new System.EventHandler(this.button_applyTank_Click);
            // 
            // dataGridView_areaTanks
            // 
            this.dataGridView_areaTanks.AllowUserToAddRows = false;
            this.dataGridView_areaTanks.AllowUserToDeleteRows = false;
            this.dataGridView_areaTanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_areaTanks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.areaTank,
            this.energyTank,
            this.missileTank,
            this.superTank,
            this.powerTank});
            resources.ApplyResources(this.dataGridView_areaTanks, "dataGridView_areaTanks");
            this.dataGridView_areaTanks.Name = "dataGridView_areaTanks";
            this.dataGridView_areaTanks.RowTemplate.Height = 23;
            // 
            // areaTank
            // 
            this.areaTank.DataPropertyName = "Area";
            resources.ApplyResources(this.areaTank, "areaTank");
            this.areaTank.Name = "areaTank";
            this.areaTank.ReadOnly = true;
            // 
            // energyTank
            // 
            this.energyTank.DataPropertyName = "Energy";
            resources.ApplyResources(this.energyTank, "energyTank");
            this.energyTank.MaxInputLength = 2;
            this.energyTank.Name = "energyTank";
            // 
            // missileTank
            // 
            this.missileTank.DataPropertyName = "Missile";
            resources.ApplyResources(this.missileTank, "missileTank");
            this.missileTank.MaxInputLength = 2;
            this.missileTank.Name = "missileTank";
            // 
            // superTank
            // 
            this.superTank.DataPropertyName = "Super";
            resources.ApplyResources(this.superTank, "superTank");
            this.superTank.MaxInputLength = 2;
            this.superTank.Name = "superTank";
            // 
            // powerTank
            // 
            this.powerTank.DataPropertyName = "Power";
            resources.ApplyResources(this.powerTank, "powerTank");
            this.powerTank.MaxInputLength = 2;
            this.powerTank.Name = "powerTank";
            // 
            // label_areaTanks
            // 
            resources.ApplyResources(this.label_areaTanks, "label_areaTanks");
            this.label_areaTanks.Name = "label_areaTanks";
            // 
            // tabPage_elevator
            // 
            this.tabPage_elevator.Controls.Add(this.button_applyElevator);
            this.tabPage_elevator.Controls.Add(this.dataGridView_elevators);
            resources.ApplyResources(this.tabPage_elevator, "tabPage_elevator");
            this.tabPage_elevator.Name = "tabPage_elevator";
            this.tabPage_elevator.UseVisualStyleBackColor = true;
            // 
            // button_applyElevator
            // 
            resources.ApplyResources(this.button_applyElevator, "button_applyElevator");
            this.button_applyElevator.Name = "button_applyElevator";
            this.button_applyElevator.UseVisualStyleBackColor = true;
            this.button_applyElevator.Click += new System.EventHandler(this.button_applyElevator_Click);
            // 
            // dataGridView_elevators
            // 
            this.dataGridView_elevators.AllowUserToAddRows = false;
            this.dataGridView_elevators.AllowUserToDeleteRows = false;
            this.dataGridView_elevators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_elevators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.area1Elevator,
            this.room1Elevator,
            this.coord1Elevator,
            this.area2Elevator,
            this.room2Elevator,
            this.coord2Elevator});
            this.dataGridView_elevators.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            resources.ApplyResources(this.dataGridView_elevators, "dataGridView_elevators");
            this.dataGridView_elevators.Name = "dataGridView_elevators";
            this.dataGridView_elevators.RowTemplate.Height = 23;
            // 
            // area1Elevator
            // 
            this.area1Elevator.DataPropertyName = "Area1";
            resources.ApplyResources(this.area1Elevator, "area1Elevator");
            this.area1Elevator.Name = "area1Elevator";
            // 
            // room1Elevator
            // 
            this.room1Elevator.DataPropertyName = "Room1";
            resources.ApplyResources(this.room1Elevator, "room1Elevator");
            this.room1Elevator.Name = "room1Elevator";
            // 
            // coord1Elevator
            // 
            this.coord1Elevator.DataPropertyName = "Coordinate1";
            resources.ApplyResources(this.coord1Elevator, "coord1Elevator");
            this.coord1Elevator.Name = "coord1Elevator";
            // 
            // area2Elevator
            // 
            this.area2Elevator.DataPropertyName = "Area2";
            resources.ApplyResources(this.area2Elevator, "area2Elevator");
            this.area2Elevator.Name = "area2Elevator";
            // 
            // room2Elevator
            // 
            this.room2Elevator.DataPropertyName = "Room2";
            resources.ApplyResources(this.room2Elevator, "room2Elevator");
            this.room2Elevator.Name = "room2Elevator";
            // 
            // coord2Elevator
            // 
            this.coord2Elevator.DataPropertyName = "Coordinate2";
            resources.ApplyResources(this.coord2Elevator, "coord2Elevator");
            this.coord2Elevator.Name = "coord2Elevator";
            // 
            // tabPage_hatch
            // 
            this.tabPage_hatch.Controls.Add(this.button_mapIconApply);
            this.tabPage_hatch.Controls.Add(this.label_MapIcon);
            this.tabPage_hatch.Controls.Add(this.dataGridView_mapIcons);
            this.tabPage_hatch.Controls.Add(this.groupBox_block);
            this.tabPage_hatch.Controls.Add(this.groupBox_hatch);
            resources.ApplyResources(this.tabPage_hatch, "tabPage_hatch");
            this.tabPage_hatch.Name = "tabPage_hatch";
            this.tabPage_hatch.UseVisualStyleBackColor = true;
            // 
            // button_mapIconApply
            // 
            resources.ApplyResources(this.button_mapIconApply, "button_mapIconApply");
            this.button_mapIconApply.Name = "button_mapIconApply";
            this.button_mapIconApply.UseVisualStyleBackColor = true;
            this.button_mapIconApply.Click += new System.EventHandler(this.button_mapIconApply_Click);
            // 
            // label_MapIcon
            // 
            resources.ApplyResources(this.label_MapIcon, "label_MapIcon");
            this.label_MapIcon.Name = "label_MapIcon";
            // 
            // dataGridView_mapIcons
            // 
            this.dataGridView_mapIcons.AllowUserToAddRows = false;
            this.dataGridView_mapIcons.AllowUserToDeleteRows = false;
            this.dataGridView_mapIcons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventMapIcon,
            this.typeMapIcon,
            this.mapX,
            this.mapY,
            this.pixelOffset});
            this.dataGridView_mapIcons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            resources.ApplyResources(this.dataGridView_mapIcons, "dataGridView_mapIcons");
            this.dataGridView_mapIcons.Name = "dataGridView_mapIcons";
            this.dataGridView_mapIcons.RowTemplate.Height = 23;
            // 
            // eventMapIcon
            // 
            this.eventMapIcon.DataPropertyName = "IconEvent";
            this.eventMapIcon.DropDownWidth = 300;
            resources.ApplyResources(this.eventMapIcon, "eventMapIcon");
            this.eventMapIcon.Name = "eventMapIcon";
            // 
            // typeMapIcon
            // 
            this.typeMapIcon.DataPropertyName = "IconType";
            resources.ApplyResources(this.typeMapIcon, "typeMapIcon");
            this.typeMapIcon.Name = "typeMapIcon";
            // 
            // mapX
            // 
            this.mapX.DataPropertyName = "X";
            resources.ApplyResources(this.mapX, "mapX");
            this.mapX.MaxInputLength = 3;
            this.mapX.Name = "mapX";
            // 
            // mapY
            // 
            this.mapY.DataPropertyName = "Y";
            resources.ApplyResources(this.mapY, "mapY");
            this.mapY.MaxInputLength = 3;
            this.mapY.Name = "mapY";
            // 
            // pixelOffset
            // 
            this.pixelOffset.DataPropertyName = "PixelOffset";
            resources.ApplyResources(this.pixelOffset, "pixelOffset");
            this.pixelOffset.MaxInputLength = 3;
            this.pixelOffset.Name = "pixelOffset";
            // 
            // groupBox_block
            // 
            this.groupBox_block.Controls.Add(this.button_blockApply);
            this.groupBox_block.Controls.Add(this.label_blockWeakness);
            this.groupBox_block.Controls.Add(this.comboBox_blockType);
            this.groupBox_block.Controls.Add(this.checkedListBox_blockWeakness);
            this.groupBox_block.Controls.Add(this.label_blockType);
            resources.ApplyResources(this.groupBox_block, "groupBox_block");
            this.groupBox_block.Name = "groupBox_block";
            this.groupBox_block.TabStop = false;
            // 
            // button_blockApply
            // 
            resources.ApplyResources(this.button_blockApply, "button_blockApply");
            this.button_blockApply.Name = "button_blockApply";
            this.button_blockApply.UseVisualStyleBackColor = true;
            this.button_blockApply.Click += new System.EventHandler(this.button_blockApply_Click);
            // 
            // label_blockWeakness
            // 
            resources.ApplyResources(this.label_blockWeakness, "label_blockWeakness");
            this.label_blockWeakness.Name = "label_blockWeakness";
            // 
            // comboBox_blockType
            // 
            this.comboBox_blockType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_blockType, "comboBox_blockType");
            this.comboBox_blockType.Name = "comboBox_blockType";
            this.comboBox_blockType.SelectedIndexChanged += new System.EventHandler(this.comboBox_blockType_SelectedIndexChanged);
            // 
            // checkedListBox_blockWeakness
            // 
            this.checkedListBox_blockWeakness.CheckOnClick = true;
            this.checkedListBox_blockWeakness.FormattingEnabled = true;
            this.checkedListBox_blockWeakness.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_blockWeakness.Items"),
            resources.GetString("checkedListBox_blockWeakness.Items1"),
            resources.GetString("checkedListBox_blockWeakness.Items2"),
            resources.GetString("checkedListBox_blockWeakness.Items3"),
            resources.GetString("checkedListBox_blockWeakness.Items4"),
            resources.GetString("checkedListBox_blockWeakness.Items5"),
            resources.GetString("checkedListBox_blockWeakness.Items6"),
            resources.GetString("checkedListBox_blockWeakness.Items7"),
            resources.GetString("checkedListBox_blockWeakness.Items8")});
            resources.ApplyResources(this.checkedListBox_blockWeakness, "checkedListBox_blockWeakness");
            this.checkedListBox_blockWeakness.Name = "checkedListBox_blockWeakness";
            // 
            // label_blockType
            // 
            resources.ApplyResources(this.label_blockType, "label_blockType");
            this.label_blockType.Name = "label_blockType";
            // 
            // groupBox_hatch
            // 
            this.groupBox_hatch.Controls.Add(this.checkBox_hatchFlash);
            this.groupBox_hatch.Controls.Add(this.checkedListBox_hatchWeakness);
            this.groupBox_hatch.Controls.Add(this.button_hatchApply);
            this.groupBox_hatch.Controls.Add(this.label_hatchWeakness);
            this.groupBox_hatch.Controls.Add(this.numericUpDown_hatchHits);
            this.groupBox_hatch.Controls.Add(this.label_hatchHits);
            this.groupBox_hatch.Controls.Add(this.comboBox_hatchType);
            this.groupBox_hatch.Controls.Add(this.label_hatchType);
            resources.ApplyResources(this.groupBox_hatch, "groupBox_hatch");
            this.groupBox_hatch.Name = "groupBox_hatch";
            this.groupBox_hatch.TabStop = false;
            // 
            // checkBox_hatchFlash
            // 
            resources.ApplyResources(this.checkBox_hatchFlash, "checkBox_hatchFlash");
            this.checkBox_hatchFlash.Name = "checkBox_hatchFlash";
            this.checkBox_hatchFlash.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_hatchWeakness
            // 
            this.checkedListBox_hatchWeakness.CheckOnClick = true;
            this.checkedListBox_hatchWeakness.FormattingEnabled = true;
            this.checkedListBox_hatchWeakness.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_hatchWeakness.Items"),
            resources.GetString("checkedListBox_hatchWeakness.Items1"),
            resources.GetString("checkedListBox_hatchWeakness.Items2"),
            resources.GetString("checkedListBox_hatchWeakness.Items3"),
            resources.GetString("checkedListBox_hatchWeakness.Items4")});
            resources.ApplyResources(this.checkedListBox_hatchWeakness, "checkedListBox_hatchWeakness");
            this.checkedListBox_hatchWeakness.Name = "checkedListBox_hatchWeakness";
            // 
            // button_hatchApply
            // 
            resources.ApplyResources(this.button_hatchApply, "button_hatchApply");
            this.button_hatchApply.Name = "button_hatchApply";
            this.button_hatchApply.UseVisualStyleBackColor = true;
            this.button_hatchApply.Click += new System.EventHandler(this.button_hatchApply_Click);
            // 
            // label_hatchWeakness
            // 
            resources.ApplyResources(this.label_hatchWeakness, "label_hatchWeakness");
            this.label_hatchWeakness.Name = "label_hatchWeakness";
            // 
            // numericUpDown_hatchHits
            // 
            resources.ApplyResources(this.numericUpDown_hatchHits, "numericUpDown_hatchHits");
            this.numericUpDown_hatchHits.Name = "numericUpDown_hatchHits";
            // 
            // label_hatchHits
            // 
            resources.ApplyResources(this.label_hatchHits, "label_hatchHits");
            this.label_hatchHits.Name = "label_hatchHits";
            // 
            // comboBox_hatchType
            // 
            this.comboBox_hatchType.FormattingEnabled = true;
            this.comboBox_hatchType.Items.AddRange(new object[] {
            resources.GetString("comboBox_hatchType.Items"),
            resources.GetString("comboBox_hatchType.Items1"),
            resources.GetString("comboBox_hatchType.Items2"),
            resources.GetString("comboBox_hatchType.Items3")});
            resources.ApplyResources(this.comboBox_hatchType, "comboBox_hatchType");
            this.comboBox_hatchType.Name = "comboBox_hatchType";
            this.comboBox_hatchType.SelectedIndexChanged += new System.EventHandler(this.comboBox_hatchType_SelectedIndexChanged);
            // 
            // label_hatchType
            // 
            resources.ApplyResources(this.label_hatchType, "label_hatchType");
            this.label_hatchType.Name = "label_hatchType";
            // 
            // tabPage_statue
            // 
            this.tabPage_statue.Controls.Add(this.button_statueApply);
            this.tabPage_statue.Controls.Add(this.dataGridView_statue);
            resources.ApplyResources(this.tabPage_statue, "tabPage_statue");
            this.tabPage_statue.Name = "tabPage_statue";
            this.tabPage_statue.UseVisualStyleBackColor = true;
            // 
            // button_statueApply
            // 
            resources.ApplyResources(this.button_statueApply, "button_statueApply");
            this.button_statueApply.Name = "button_statueApply";
            this.button_statueApply.UseVisualStyleBackColor = true;
            this.button_statueApply.Click += new System.EventHandler(this.button_statueApply_Click);
            // 
            // dataGridView_statue
            // 
            this.dataGridView_statue.AllowUserToAddRows = false;
            this.dataGridView_statue.AllowUserToDeleteRows = false;
            this.dataGridView_statue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_statue.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_statue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.dataGridView_statue, "dataGridView_statue");
            this.dataGridView_statue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statueArea,
            this.statueStartCoordinate,
            this.statueEndCoordinate,
            this.statueStartIcon,
            this.statueTargetArea,
            this.statueTargetCoordinate,
            this.statueEndIcon,
            this.statueCheckType,
            this.statueEquipEvent,
            this.statueTriggerEvent});
            this.dataGridView_statue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_statue.Name = "dataGridView_statue";
            this.dataGridView_statue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_statue_CellValueChanged);
            // 
            // statueArea
            // 
            this.statueArea.DataPropertyName = "Area";
            this.statueArea.FillWeight = 65F;
            resources.ApplyResources(this.statueArea, "statueArea");
            this.statueArea.Name = "statueArea";
            // 
            // statueStartCoordinate
            // 
            this.statueStartCoordinate.DataPropertyName = "StartCoordinate";
            this.statueStartCoordinate.FillWeight = 65F;
            resources.ApplyResources(this.statueStartCoordinate, "statueStartCoordinate");
            this.statueStartCoordinate.Name = "statueStartCoordinate";
            // 
            // statueEndCoordinate
            // 
            this.statueEndCoordinate.DataPropertyName = "EndCoordinate";
            this.statueEndCoordinate.FillWeight = 65F;
            resources.ApplyResources(this.statueEndCoordinate, "statueEndCoordinate");
            this.statueEndCoordinate.Name = "statueEndCoordinate";
            // 
            // statueStartIcon
            // 
            this.statueStartIcon.DataPropertyName = "StartIcon";
            this.statueStartIcon.FillWeight = 65F;
            resources.ApplyResources(this.statueStartIcon, "statueStartIcon");
            this.statueStartIcon.Name = "statueStartIcon";
            // 
            // statueTargetArea
            // 
            this.statueTargetArea.DataPropertyName = "TargetArea";
            this.statueTargetArea.FillWeight = 65F;
            resources.ApplyResources(this.statueTargetArea, "statueTargetArea");
            this.statueTargetArea.Name = "statueTargetArea";
            // 
            // statueTargetCoordinate
            // 
            this.statueTargetCoordinate.DataPropertyName = "TargetCoordinate";
            this.statueTargetCoordinate.FillWeight = 65F;
            resources.ApplyResources(this.statueTargetCoordinate, "statueTargetCoordinate");
            this.statueTargetCoordinate.Name = "statueTargetCoordinate";
            // 
            // statueEndIcon
            // 
            this.statueEndIcon.DataPropertyName = "EndIcon";
            this.statueEndIcon.FillWeight = 65F;
            resources.ApplyResources(this.statueEndIcon, "statueEndIcon");
            this.statueEndIcon.Name = "statueEndIcon";
            // 
            // statueCheckType
            // 
            this.statueCheckType.DataPropertyName = "Type";
            this.statueCheckType.FillWeight = 65F;
            resources.ApplyResources(this.statueCheckType, "statueCheckType");
            this.statueCheckType.Name = "statueCheckType";
            // 
            // statueEquipEvent
            // 
            this.statueEquipEvent.DataPropertyName = "EquipEvent";
            resources.ApplyResources(this.statueEquipEvent, "statueEquipEvent");
            this.statueEquipEvent.Name = "statueEquipEvent";
            // 
            // statueTriggerEvent
            // 
            this.statueTriggerEvent.DataPropertyName = "TriggerEvent";
            resources.ApplyResources(this.statueTriggerEvent, "statueTriggerEvent");
            this.statueTriggerEvent.Name = "statueTriggerEvent";
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FormTweak
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "FormTweak";
            this.tabControl.ResumeLayout(false);
            this.tabPage_tank.ResumeLayout(false);
            this.tabPage_tank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_increaseTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_areaTanks)).EndInit();
            this.tabPage_elevator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_elevators)).EndInit();
            this.tabPage_hatch.ResumeLayout(false);
            this.tabPage_hatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mapIcons)).EndInit();
            this.groupBox_block.ResumeLayout(false);
            this.groupBox_block.PerformLayout();
            this.groupBox_hatch.ResumeLayout(false);
            this.groupBox_hatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hatchHits)).EndInit();
            this.tabPage_statue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_statue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_tank;
        private System.Windows.Forms.TabPage tabPage_elevator;
        private System.Windows.Forms.DataGridView dataGridView_areaTanks;
        private System.Windows.Forms.Label label_areaTanks;
        private System.Windows.Forms.Button button_applyTank;
        private System.Windows.Forms.Label label_increaseTank;
        private System.Windows.Forms.DataGridView dataGridView_increaseTank;
        private System.Windows.Forms.Button button_applyIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaTank;
        private System.Windows.Forms.DataGridViewTextBoxColumn energyTank;
        private System.Windows.Forms.DataGridViewTextBoxColumn missileTank;
        private System.Windows.Forms.DataGridViewTextBoxColumn superTank;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerTank;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn energyIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn missileIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn superIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerIncrease;
        private System.Windows.Forms.DataGridView dataGridView_elevators;
        private System.Windows.Forms.DataGridViewComboBoxColumn area1Elevator;
        private System.Windows.Forms.DataGridViewTextBoxColumn room1Elevator;
        private System.Windows.Forms.DataGridViewTextBoxColumn coord1Elevator;
        private System.Windows.Forms.DataGridViewComboBoxColumn area2Elevator;
        private System.Windows.Forms.DataGridViewTextBoxColumn room2Elevator;
        private System.Windows.Forms.DataGridViewTextBoxColumn coord2Elevator;
        private System.Windows.Forms.Button button_applyElevator;
        private System.Windows.Forms.TabPage tabPage_hatch;
        private System.Windows.Forms.DataGridView dataGridView_mapIcons;
        private System.Windows.Forms.GroupBox groupBox_block;
        private System.Windows.Forms.GroupBox groupBox_hatch;
        private System.Windows.Forms.CheckedListBox checkedListBox_hatchWeakness;
        private System.Windows.Forms.Button button_hatchApply;
        private System.Windows.Forms.Label label_hatchWeakness;
        private System.Windows.Forms.NumericUpDown numericUpDown_hatchHits;
        private System.Windows.Forms.Label label_hatchHits;
        private System.Windows.Forms.ComboBox comboBox_hatchType;
        private System.Windows.Forms.Label label_hatchType;
        private System.Windows.Forms.Label label_blockType;
        private System.Windows.Forms.Button button_blockApply;
        private System.Windows.Forms.Label label_blockWeakness;
        private System.Windows.Forms.ComboBox comboBox_blockType;
        private System.Windows.Forms.CheckedListBox checkedListBox_blockWeakness;
        private System.Windows.Forms.Button button_mapIconApply;
        private System.Windows.Forms.Label label_MapIcon;
        private System.Windows.Forms.CheckBox checkBox_hatchFlash;
        private System.Windows.Forms.TabPage tabPage_statue;
        private System.Windows.Forms.DataGridView dataGridView_statue;
        private System.Windows.Forms.Button button_statueApply;
        private System.Windows.Forms.DataGridViewComboBoxColumn eventMapIcon;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeMapIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapX;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapY;
        private System.Windows.Forms.DataGridViewTextBoxColumn pixelOffset;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn statueStartCoordinate;
        private System.Windows.Forms.DataGridViewTextBoxColumn statueEndCoordinate;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueStartIcon;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueTargetArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn statueTargetCoordinate;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueEndIcon;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueCheckType;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueEquipEvent;
        private System.Windows.Forms.DataGridViewComboBoxColumn statueTriggerEvent;
        private System.Windows.Forms.TabPage tabPage1;
    }
}