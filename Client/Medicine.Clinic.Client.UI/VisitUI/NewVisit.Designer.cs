namespace Medicine.Clinic.Client.UI
{
    partial class NewVisit
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
            this.lookUpEditPatient = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlNewVisit = new DevExpress.XtraLayout.LayoutControl();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lookUpEditDoctor = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditApartment = new DevExpress.XtraEditors.LookUpEdit();
            this.textBoxBilling = new System.Windows.Forms.TextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPatient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewVisit)).BeginInit();
            this.layoutControlNewVisit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDoctor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditApartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEditPatient
            // 
            this.lookUpEditPatient.Location = new System.Drawing.Point(66, 36);
            this.lookUpEditPatient.Name = "lookUpEditPatient";
            this.lookUpEditPatient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPatient.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Mrn", "Mrn"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstName", "First Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastName", "Last Name")});
            this.lookUpEditPatient.Properties.DisplayMember = "FirstName";
            this.lookUpEditPatient.Properties.NullText = "";
            this.lookUpEditPatient.Properties.ValueMember = "Mrn";
            this.lookUpEditPatient.Size = new System.Drawing.Size(142, 20);
            this.lookUpEditPatient.StyleController = this.layoutControlNewVisit;
            this.lookUpEditPatient.TabIndex = 1;
            // 
            // layoutControlNewVisit
            // 
            this.layoutControlNewVisit.Controls.Add(this.buttonOk);
            this.layoutControlNewVisit.Controls.Add(this.buttonAddOrder);
            this.layoutControlNewVisit.Controls.Add(this.buttonCancel);
            this.layoutControlNewVisit.Controls.Add(this.lookUpEditDoctor);
            this.layoutControlNewVisit.Controls.Add(this.lookUpEditApartment);
            this.layoutControlNewVisit.Controls.Add(this.textBoxBilling);
            this.layoutControlNewVisit.Controls.Add(this.lookUpEditPatient);
            this.layoutControlNewVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlNewVisit.Location = new System.Drawing.Point(0, 0);
            this.layoutControlNewVisit.Name = "layoutControlNewVisit";
            this.layoutControlNewVisit.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(414, 124, 250, 350);
            this.layoutControlNewVisit.Root = this.layoutControlGroup1;
            this.layoutControlNewVisit.Size = new System.Drawing.Size(220, 319);
            this.layoutControlNewVisit.TabIndex = 0;
            this.layoutControlNewVisit.Text = "layoutControl1";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 263);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(96, 20);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "&OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(112, 263);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(96, 20);
            this.buttonAddOrder.TabIndex = 5;
            this.buttonAddOrder.Text = "&Add Order";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(196, 20);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // lookUpEditDoctor
            // 
            this.lookUpEditDoctor.Location = new System.Drawing.Point(66, 84);
            this.lookUpEditDoctor.Name = "lookUpEditDoctor";
            this.lookUpEditDoctor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDoctor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstName", "First Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastName", "Last Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clinic", "Clinic")});
            this.lookUpEditDoctor.Properties.DisplayMember = "FirstName";
            this.lookUpEditDoctor.Properties.NullText = "";
            this.lookUpEditDoctor.Properties.ValueMember = "Code";
            this.lookUpEditDoctor.Size = new System.Drawing.Size(142, 20);
            this.lookUpEditDoctor.StyleController = this.layoutControlNewVisit;
            this.lookUpEditDoctor.TabIndex = 3;
            // 
            // lookUpEditApartment
            // 
            this.lookUpEditApartment.EditValue = 0;
            this.lookUpEditApartment.Location = new System.Drawing.Point(66, 60);
            this.lookUpEditApartment.Name = "lookUpEditApartment";
            this.lookUpEditApartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditApartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClinicCode", "Clinic Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClinicName", "Clinic Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Room", "Room"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Bed", "Bed")});
            this.lookUpEditApartment.Properties.DisplayMember = "ClinicName";
            this.lookUpEditApartment.Properties.NullText = "";
            this.lookUpEditApartment.Properties.ValueMember = "Id";
            this.lookUpEditApartment.Size = new System.Drawing.Size(142, 20);
            this.lookUpEditApartment.StyleController = this.layoutControlNewVisit;
            this.lookUpEditApartment.TabIndex = 2;
            this.lookUpEditApartment.EditValueChanged += new System.EventHandler(this.lookUpEditApartment_EditValueChanged);
            // 
            // textBoxBilling
            // 
            this.textBoxBilling.Location = new System.Drawing.Point(66, 12);
            this.textBoxBilling.Name = "textBoxBilling";
            this.textBoxBilling.ReadOnly = true;
            this.textBoxBilling.Size = new System.Drawing.Size(142, 20);
            this.textBoxBilling.TabIndex = 0;
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
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(220, 319);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textBoxBilling;
            this.layoutControlItem1.CustomizationFormText = "Billing#";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(79, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Billing#";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookUpEditPatient;
            this.layoutControlItem2.CustomizationFormText = "Patient";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(109, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Patient";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpEditApartment;
            this.layoutControlItem3.CustomizationFormText = "Apartment";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(109, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Apartment";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookUpEditDoctor;
            this.layoutControlItem4.CustomizationFormText = "Doctor";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(109, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Doctor";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.buttonCancel;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 275);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonAddOrder;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(100, 251);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(100, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.buttonOk;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 251);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(100, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(200, 155);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // NewVisit
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(220, 319);
            this.Controls.Add(this.layoutControlNewVisit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVisit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewVisit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewVisit_FormClosed);
            this.Load += new System.EventHandler(this.NewVisit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPatient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewVisit)).EndInit();
            this.layoutControlNewVisit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDoctor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditApartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEditPatient;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDoctor;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditApartment;
        private System.Windows.Forms.TextBox textBoxBilling;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddOrder;
        private DevExpress.XtraLayout.LayoutControl layoutControlNewVisit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}