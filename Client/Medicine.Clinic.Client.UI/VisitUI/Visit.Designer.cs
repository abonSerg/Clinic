namespace Medicine.Clinic.Client.UI
{
    partial class Visit
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
            this.textBoxMrn = new System.Windows.Forms.TextBox();
            this.textBoxPatientFirstName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonOpenVisit = new System.Windows.Forms.Button();
            this.buttonNewVisit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.gridControlVisits = new DevExpress.XtraGrid.GridControl();
            this.textBoxBillingNumber = new System.Windows.Forms.TextBox();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.layoutControlVisit = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridViewVisit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BillingNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PatientFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PatientLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DoctorFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DoctorLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Clinic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Room = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewVisits = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnBillingNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPatientFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPatientLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDoctorFirsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDoctorLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnClinic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBed = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVisits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlVisit)).BeginInit();
            this.layoutControlVisit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVisit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVisits)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMrn
            // 
            this.textBoxMrn.Location = new System.Drawing.Point(103, 12);
            this.textBoxMrn.Name = "textBoxMrn";
            this.textBoxMrn.Size = new System.Drawing.Size(209, 20);
            this.textBoxMrn.TabIndex = 0;
            // 
            // textBoxPatientFirstName
            // 
            this.textBoxPatientFirstName.Location = new System.Drawing.Point(103, 36);
            this.textBoxPatientFirstName.Name = "textBoxPatientFirstName";
            this.textBoxPatientFirstName.Size = new System.Drawing.Size(209, 20);
            this.textBoxPatientFirstName.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(12, 84);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(300, 27);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 115);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(300, 26);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "&Clear/Refresh";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonOpenVisit
            // 
            this.buttonOpenVisit.Location = new System.Drawing.Point(302, 471);
            this.buttonOpenVisit.Name = "buttonOpenVisit";
            this.buttonOpenVisit.Size = new System.Drawing.Size(314, 20);
            this.buttonOpenVisit.TabIndex = 7;
            this.buttonOpenVisit.Text = "&Open Visit";
            this.buttonOpenVisit.UseVisualStyleBackColor = true;
            this.buttonOpenVisit.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonNewVisit
            // 
            this.buttonNewVisit.Location = new System.Drawing.Point(620, 471);
            this.buttonNewVisit.Name = "buttonNewVisit";
            this.buttonNewVisit.Size = new System.Drawing.Size(261, 20);
            this.buttonNewVisit.TabIndex = 8;
            this.buttonNewVisit.Text = "&New Visit";
            this.buttonNewVisit.UseVisualStyleBackColor = true;
            this.buttonNewVisit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 495);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(869, 26);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "&Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // gridControlVisits
            // 
            this.gridControlVisits.Location = new System.Drawing.Point(12, 161);
            this.gridControlVisits.MainView = this.gridViewVisits;
            this.gridControlVisits.Name = "gridControlVisits";
            this.gridControlVisits.Size = new System.Drawing.Size(869, 296);
            this.gridControlVisits.TabIndex = 5;
            this.gridControlVisits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVisit,
            this.gridViewVisits});
            // 
            // textBoxBillingNumber
            // 
            this.textBoxBillingNumber.Location = new System.Drawing.Point(103, 60);
            this.textBoxBillingNumber.Name = "textBoxBillingNumber";
            this.textBoxBillingNumber.Size = new System.Drawing.Size(209, 20);
            this.textBoxBillingNumber.TabIndex = 2;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(12, 471);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(286, 20);
            this.buttonAddOrder.TabIndex = 6;
            this.buttonAddOrder.Text = "&Add Order";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // layoutControlVisit
            // 
            this.layoutControlVisit.Controls.Add(this.textBoxBillingNumber);
            this.layoutControlVisit.Controls.Add(this.buttonAddOrder);
            this.layoutControlVisit.Controls.Add(this.gridControlVisits);
            this.layoutControlVisit.Controls.Add(this.buttonOpenVisit);
            this.layoutControlVisit.Controls.Add(this.buttonNewVisit);
            this.layoutControlVisit.Controls.Add(this.buttonCancel);
            this.layoutControlVisit.Controls.Add(this.textBoxMrn);
            this.layoutControlVisit.Controls.Add(this.textBoxPatientFirstName);
            this.layoutControlVisit.Controls.Add(this.buttonClear);
            this.layoutControlVisit.Controls.Add(this.buttonSearch);
            this.layoutControlVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlVisit.Location = new System.Drawing.Point(0, 0);
            this.layoutControlVisit.Name = "layoutControlVisit";
            this.layoutControlVisit.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(778, 344, 250, 350);
            this.layoutControlVisit.Root = this.layoutControlGroup1;
            this.layoutControlVisit.Size = new System.Drawing.Size(893, 533);
            this.layoutControlVisit.TabIndex = 0;
            this.layoutControlVisit.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(893, 533);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textBoxMrn;
            this.layoutControlItem1.CustomizationFormText = "Mrn";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(304, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Mrn";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textBoxPatientFirstName;
            this.layoutControlItem2.CustomizationFormText = "Patient First Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(304, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Patient First Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textBoxBillingNumber;
            this.layoutControlItem3.CustomizationFormText = "Billing#";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(304, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Billing#";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.buttonSearch;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 31);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(24, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(304, 31);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.buttonClear;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 103);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(24, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(304, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridControlVisits;
            this.layoutControlItem6.CustomizationFormText = "Visits";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 133);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(104, 40);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(873, 316);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Visits";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonCancel;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 483);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 30);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(24, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(873, 30);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.buttonNewVisit;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(608, 459);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(265, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.buttonOpenVisit;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(290, 459);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(318, 24);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.buttonAddOrder;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 459);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(290, 24);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 449);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(873, 10);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(304, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 133);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 133);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(569, 133);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridViewVisit
            // 
            this.gridViewVisit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BillingNumber,
            this.PatientFirstName,
            this.PatientLastName,
            this.DoctorFirstName,
            this.DoctorLastName,
            this.Clinic,
            this.Room,
            this.Bed});
            this.gridViewVisit.GridControl = this.gridControlVisits;
            this.gridViewVisit.Name = "gridViewVisit";
            this.gridViewVisit.OptionsBehavior.Editable = false;
            // 
            // BillingNumber
            // 
            this.BillingNumber.Caption = "Billing Number";
            this.BillingNumber.FieldName = "BillingNumber";
            this.BillingNumber.Name = "BillingNumber";
            this.BillingNumber.Visible = true;
            this.BillingNumber.VisibleIndex = 0;
            this.BillingNumber.Width = 100;
            // 
            // PatientFirstName
            // 
            this.PatientFirstName.Caption = "Patient F. Name";
            this.PatientFirstName.FieldName = "Visits.Patient.FirstName";
            this.PatientFirstName.Name = "PatientFirstName";
            this.PatientFirstName.Visible = true;
            this.PatientFirstName.VisibleIndex = 1;
            this.PatientFirstName.Width = 139;
            // 
            // PatientLastName
            // 
            this.PatientLastName.Caption = "Patient L. Name";
            this.PatientLastName.FieldName = "PatientLastName";
            this.PatientLastName.Name = "PatientLastName";
            this.PatientLastName.Visible = true;
            this.PatientLastName.VisibleIndex = 2;
            this.PatientLastName.Width = 124;
            // 
            // DoctorFirstName
            // 
            this.DoctorFirstName.Caption = "Doctor F. Name";
            this.DoctorFirstName.FieldName = "DoctorFirstName";
            this.DoctorFirstName.Name = "DoctorFirstName";
            this.DoctorFirstName.Visible = true;
            this.DoctorFirstName.VisibleIndex = 3;
            this.DoctorFirstName.Width = 115;
            // 
            // DoctorLastName
            // 
            this.DoctorLastName.Caption = "Doctor L. Name";
            this.DoctorLastName.FieldName = "DoctorLastName";
            this.DoctorLastName.Name = "DoctorLastName";
            this.DoctorLastName.Visible = true;
            this.DoctorLastName.VisibleIndex = 4;
            this.DoctorLastName.Width = 96;
            // 
            // Clinic
            // 
            this.Clinic.Caption = "Clinic";
            this.Clinic.FieldName = "Clinic";
            this.Clinic.Name = "Clinic";
            this.Clinic.Visible = true;
            this.Clinic.VisibleIndex = 5;
            this.Clinic.Width = 120;
            // 
            // Room
            // 
            this.Room.Caption = "Room";
            this.Room.FieldName = "Room";
            this.Room.Name = "Room";
            this.Room.Visible = true;
            this.Room.VisibleIndex = 6;
            this.Room.Width = 62;
            // 
            // Bed
            // 
            this.Bed.Caption = "Bed";
            this.Bed.FieldName = "Bed";
            this.Bed.Name = "Bed";
            this.Bed.Visible = true;
            this.Bed.VisibleIndex = 7;
            this.Bed.Width = 55;
            // 
            // gridViewVisits
            // 
            this.gridViewVisits.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnBillingNumber,
            this.gridColumnPatientFirstName,
            this.gridColumnPatientLastName,
            this.gridColumnDoctorFirsName,
            this.gridColumnDoctorLastName,
            this.gridColumnClinic,
            this.gridColumnRoom,
            this.gridColumnBed});
            this.gridViewVisits.GridControl = this.gridControlVisits;
            this.gridViewVisits.Name = "gridViewVisits";
            this.gridViewVisits.OptionsBehavior.Editable = false;
            this.gridViewVisits.OptionsNavigation.UseTabKey = false;
            // 
            // gridColumnBillingNumber
            // 
            this.gridColumnBillingNumber.Caption = "Billing#";
            this.gridColumnBillingNumber.FieldName = "BillingNumber";
            this.gridColumnBillingNumber.Name = "gridColumnBillingNumber";
            this.gridColumnBillingNumber.Visible = true;
            this.gridColumnBillingNumber.VisibleIndex = 0;
            this.gridColumnBillingNumber.Width = 78;
            // 
            // gridColumnPatientFirstName
            // 
            this.gridColumnPatientFirstName.Caption = "Patient F.N.";
            this.gridColumnPatientFirstName.FieldName = "PatientFirstName";
            this.gridColumnPatientFirstName.Name = "gridColumnPatientFirstName";
            this.gridColumnPatientFirstName.Visible = true;
            this.gridColumnPatientFirstName.VisibleIndex = 1;
            this.gridColumnPatientFirstName.Width = 110;
            // 
            // gridColumnPatientLastName
            // 
            this.gridColumnPatientLastName.Caption = "Patient L.N.";
            this.gridColumnPatientLastName.FieldName = "PatientLastName";
            this.gridColumnPatientLastName.Name = "gridColumnPatientLastName";
            this.gridColumnPatientLastName.Visible = true;
            this.gridColumnPatientLastName.VisibleIndex = 2;
            this.gridColumnPatientLastName.Width = 131;
            // 
            // gridColumnDoctorFirsName
            // 
            this.gridColumnDoctorFirsName.Caption = "Doctor F.N.";
            this.gridColumnDoctorFirsName.FieldName = "DoctorFirstName";
            this.gridColumnDoctorFirsName.Name = "gridColumnDoctorFirsName";
            this.gridColumnDoctorFirsName.Visible = true;
            this.gridColumnDoctorFirsName.VisibleIndex = 3;
            this.gridColumnDoctorFirsName.Width = 103;
            // 
            // gridColumnDoctorLastName
            // 
            this.gridColumnDoctorLastName.Caption = "Doctor L.N.";
            this.gridColumnDoctorLastName.FieldName = "DoctorLastName";
            this.gridColumnDoctorLastName.Name = "gridColumnDoctorLastName";
            this.gridColumnDoctorLastName.Visible = true;
            this.gridColumnDoctorLastName.VisibleIndex = 4;
            this.gridColumnDoctorLastName.Width = 124;
            // 
            // gridColumnClinic
            // 
            this.gridColumnClinic.Caption = "Clinic";
            this.gridColumnClinic.FieldName = "ClinicName";
            this.gridColumnClinic.Name = "gridColumnClinic";
            this.gridColumnClinic.Visible = true;
            this.gridColumnClinic.VisibleIndex = 5;
            this.gridColumnClinic.Width = 166;
            // 
            // gridColumnRoom
            // 
            this.gridColumnRoom.Caption = "Room";
            this.gridColumnRoom.FieldName = "Room";
            this.gridColumnRoom.Name = "gridColumnRoom";
            this.gridColumnRoom.Visible = true;
            this.gridColumnRoom.VisibleIndex = 6;
            this.gridColumnRoom.Width = 70;
            // 
            // gridColumnBed
            // 
            this.gridColumnBed.Caption = "Bed";
            this.gridColumnBed.FieldName = "Bed";
            this.gridColumnBed.Name = "gridColumnBed";
            this.gridColumnBed.Visible = true;
            this.gridColumnBed.VisibleIndex = 7;
            this.gridColumnBed.Width = 69;
            // 
            // Visit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 533);
            this.Controls.Add(this.layoutControlVisit);
            this.Name = "Visit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Visit_FormClosed);
            this.Load += new System.EventHandler(this.Visit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVisits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlVisit)).EndInit();
            this.layoutControlVisit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVisit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVisits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMrn;
        private System.Windows.Forms.TextBox textBoxPatientFirstName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOpenVisit;
        private System.Windows.Forms.Button buttonNewVisit;
        private System.Windows.Forms.Button buttonCancel;
        private DevExpress.XtraGrid.GridControl gridControlVisits;
        private System.Windows.Forms.TextBox textBoxBillingNumber;
        private System.Windows.Forms.Button buttonAddOrder;
        private DevExpress.XtraLayout.LayoutControl layoutControlVisit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVisit;
        private DevExpress.XtraGrid.Columns.GridColumn BillingNumber;
        private DevExpress.XtraGrid.Columns.GridColumn PatientFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn PatientLastName;
        private DevExpress.XtraGrid.Columns.GridColumn DoctorFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn DoctorLastName;
        private DevExpress.XtraGrid.Columns.GridColumn Clinic;
        private DevExpress.XtraGrid.Columns.GridColumn Room;
        private DevExpress.XtraGrid.Columns.GridColumn Bed;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVisits;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBillingNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatientFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatientLastName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDoctorFirsName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDoctorLastName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClinic;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBed;
    }
}