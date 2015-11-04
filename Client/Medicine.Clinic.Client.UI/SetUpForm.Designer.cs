namespace Medicine.Clinic.Client.UI
{
    partial class SetupForm
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
            this.gridControlView = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlClinics
            // 
            this.gridControlView.Location = new System.Drawing.Point(12, 128);
            this.gridControlView.MainView = this.gridView;
            this.gridControlView.Name = "gridControlClinics";
            this.gridControlView.Size = new System.Drawing.Size(541, 414);
            this.gridControlView.TabIndex = 4;
            this.gridControlView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
           
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(44, 12);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(201, 20);
            this.textBoxCode.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(44, 36);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(201, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(12, 60);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(233, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 87);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(233, 21);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear/Refresh";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 601);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(234, 20);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(250, 601);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(303, 20);
            this.buttonNew.TabIndex = 6;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 625);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(541, 20);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // layoutControlClinic
            // 
            this.layoutControl.Controls.Add(this.buttonCancel);
            this.layoutControl.Controls.Add(this.buttonNew);
            this.layoutControl.Controls.Add(this.textBoxCode);
            this.layoutControl.Controls.Add(this.buttonEdit);
            this.layoutControl.Controls.Add(this.textBoxName);
            this.layoutControl.Controls.Add(this.gridControlView);
            this.layoutControl.Controls.Add(this.buttonClear);
            this.layoutControl.Controls.Add(this.buttonSearch);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControlClinic";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(687, 410, 250, 350);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(565, 657);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(565, 657);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textBoxName;
            this.layoutControlItem2.CustomizationFormText = "Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(57, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(237, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(29, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.buttonSearch;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(24, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(237, 27);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.buttonClear;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 25);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(24, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(237, 25);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.buttonEdit;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 589);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(238, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonNew;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(238, 589);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(307, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.buttonCancel;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 613);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(545, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textBoxCode;
            this.layoutControlItem1.CustomizationFormText = "Code";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(57, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(237, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Code";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(29, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlView;
            this.layoutControlItem5.CustomizationFormText = "Clinics";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(545, 434);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Clinics";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(29, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 534);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(545, 55);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(237, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(308, 100);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Clinic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 657);
            this.Controls.Add(this.layoutControl);
            this.Name = "Clinic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinic";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Clinic_FormClosed);
            this.Load += new System.EventHandler(this.Clinic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControlView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonCancel;
        private DevExpress.XtraGrid.Columns.GridColumn ClinicId;
        private DevExpress.XtraGrid.Columns.GridColumn ClinicCode;
        private DevExpress.XtraGrid.Columns.GridColumn ClinicName;
        private DevExpress.XtraGrid.Columns.GridColumn ClinicAddress;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn TestCode;
        private DevExpress.XtraGrid.Columns.GridColumn TestName;
        private DevExpress.XtraGrid.Columns.GridColumn TestCost;
        private DevExpress.XtraGrid.Columns.GridColumn DiagnosisCode;
        private DevExpress.XtraGrid.Columns.GridColumn DiagnosisName;
        private DevExpress.XtraGrid.Columns.GridColumn IndicationCode;
        private DevExpress.XtraGrid.Columns.GridColumn IndicationName;
        private DevExpress.XtraGrid.Columns.GridColumn SexCode;
        private DevExpress.XtraGrid.Columns.GridColumn SexName;
        private DevExpress.XtraGrid.Columns.GridColumn SpecimenCode;
        private DevExpress.XtraGrid.Columns.GridColumn SpecimenName;
        private DevExpress.XtraGrid.Columns.GridColumn DefaultTube;



        private void InitializeClinicGridControlComponent()
        {
            this.ClinicId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClinicCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClinicName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClinicAddress = new DevExpress.XtraGrid.Columns.GridColumn();

            // gridView1
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ClinicId,
            this.ClinicCode,
            this.ClinicName,
            this.ClinicAddress});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;
            // 
            // ClinicId
            // 
            this.ClinicId.Caption = "Id";
            this.ClinicId.FieldName = "Id";
            this.ClinicId.Name = "ClinicId";
            // 
            // ClinicCode
            // 
            this.ClinicCode.Caption = "Code";
            this.ClinicCode.FieldName = "Code";
            this.ClinicCode.Name = "ClinicCode";
            this.ClinicCode.Visible = true;
            this.ClinicCode.VisibleIndex = 0;
            // 
            // ClinicName
            // 
            this.ClinicName.Caption = "Name";
            this.ClinicName.FieldName = "Name";
            this.ClinicName.Name = "ClinicName";
            this.ClinicName.Visible = true;
            this.ClinicName.VisibleIndex = 1;
            // 
            // ClinicAddress
            // 
            this.ClinicAddress.Caption = "Address";
            this.ClinicAddress.FieldName = "Address";
            this.ClinicAddress.Name = "ClinicAddress";
            this.ClinicAddress.Visible = true;
            this.ClinicAddress.VisibleIndex = 2;
        }

        private void InitializeTestGridControlComponent() 
        {
            this.TestCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TestCost = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TestCode,
            this.TestName,
            this.TestCost});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;
            // 
            // TestCode
            // 
            this.TestCode.Caption = "Code";
            this.TestCode.FieldName = "Code";
            this.TestCode.Name = "TestCode";
            this.TestCode.Visible = true;
            this.TestCode.VisibleIndex = 0;
            // 
            // TestName
            // 
            this.TestName.Caption = "Name";
            this.TestName.FieldName = "Name";
            this.TestName.Name = "TestName";
            this.TestName.Visible = true;
            this.TestName.VisibleIndex = 1;
            // 
            // TestCost
            // 
            this.TestCost.AppearanceCell.Options.UseTextOptions = true;
            this.TestCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TestCost.Caption = "Cost";
            this.TestCost.FieldName = "Cost";
            this.TestCost.Name = "TestCost";
            this.TestCost.Visible = true;
            this.TestCost.VisibleIndex = 2;
            this.TestCost.Width = 70;

        }

        private void InitializeDiagnosisGridControlComponent()
        {
            this.DiagnosisCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiagnosisName = new DevExpress.XtraGrid.Columns.GridColumn();
            // gridView1
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DiagnosisCode,
            this.DiagnosisName});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;
            // 
            // DiagnosisCode
            // 
            this.DiagnosisCode.Caption = "Code";
            this.DiagnosisCode.FieldName = "Code";
            this.DiagnosisCode.Name = "DiagnosisCode";
            this.DiagnosisCode.Visible = true;
            this.DiagnosisCode.VisibleIndex = 0;
            // 
            // DiagnosisName
            // 
            this.DiagnosisName.Caption = "Name";
            this.DiagnosisName.FieldName = "Name";
            this.DiagnosisName.Name = "DiagnosisName";
            this.DiagnosisName.Visible = true;
            this.DiagnosisName.VisibleIndex = 1;

        }


        private void InitializeIndicationGridControlComponent()
        {
            this.IndicationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IndicationName = new DevExpress.XtraGrid.Columns.GridColumn();
          
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IndicationCode,
            this.IndicationName});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;
           
            this.IndicationCode.Caption = "Code";
            this.IndicationCode.FieldName = "Code";
            this.IndicationCode.Name = "IndicationCode";
            this.IndicationCode.Visible = true;
            this.IndicationCode.VisibleIndex = 0;
         
            this.IndicationName.Caption = "Name";
            this.IndicationName.FieldName = "Name";
            this.IndicationName.Name = "IndicationName";
            this.IndicationName.Visible = true;
            this.IndicationName.VisibleIndex = 1;
        }

        private void InitializeSexGridControlComponent()
        {
            this.SexCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SexName = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SexCode,
            this.SexName});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;

            this.SexCode.Caption = "Code";
            this.SexCode.FieldName = "Code";
            this.SexCode.Name = "SexCode";
            this.SexCode.Visible = true;
            this.SexCode.VisibleIndex = 0;

            this.SexName.Caption = "Name";
            this.SexName.FieldName = "Name";
            this.SexName.Name = "SexName";
            this.SexName.Visible = true;
            this.SexName.VisibleIndex = 1;
        }

        private void InitializeSpecimenGridControlComponent()
        {
            this.SpecimenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SpecimenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DefaultTube = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SpecimenCode,
            this.DefaultTube,
            this.SpecimenName});
            this.gridView.GridControl = this.gridControlView;
            this.gridView.Name = "gridView1";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsNavigation.UseTabKey = false;

            this.SpecimenCode.Caption = "Code";
            this.SpecimenCode.FieldName = "Code";
            this.SpecimenCode.Name = "SpecimenCode";
            this.SpecimenCode.Visible = true;
            this.SpecimenCode.VisibleIndex = 0;

            this.SpecimenName.Caption = "Name";
            this.SpecimenName.FieldName = "Name";
            this.SpecimenName.Name = "SpecimenName";
            this.SpecimenName.Visible = true;
            this.SpecimenName.VisibleIndex = 1;

            this.DefaultTube.Caption = "Default Tube";
            this.DefaultTube.FieldName = "DefaultTube.Name";
            this.DefaultTube.Name = "DefaultTube";
            this.DefaultTube.Visible = true;
            this.DefaultTube.VisibleIndex = 2;
            this.DefaultTube.Width = 100;
        }



        

    }
}