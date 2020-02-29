/*
 * Created by SharpDevelop.
 * User: Matyi
 * Date: 2020.01.23.
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace deleteatcursorpro
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btn_terminate;
		private System.Windows.Forms.CheckBox chb_split;
		private System.Windows.Forms.RadioButton rdb_type1;
		private System.Windows.Forms.RadioButton rdb_type2;
		private System.Windows.Forms.RadioButton rdb_type3;
		private System.Windows.Forms.PictureBox pbt_setting;
		private System.Windows.Forms.TextBox tbx_preview;
		private System.Windows.Forms.ComboBox cbb_selectshort;
		private System.Windows.Forms.Button btn_savekey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_terminate = new System.Windows.Forms.Button();
			this.chb_split = new System.Windows.Forms.CheckBox();
			this.rdb_type1 = new System.Windows.Forms.RadioButton();
			this.rdb_type2 = new System.Windows.Forms.RadioButton();
			this.rdb_type3 = new System.Windows.Forms.RadioButton();
			this.pbt_setting = new System.Windows.Forms.PictureBox();
			this.tbx_preview = new System.Windows.Forms.TextBox();
			this.cbb_selectshort = new System.Windows.Forms.ComboBox();
			this.btn_savekey = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pbt_setting)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_terminate
			// 
			this.btn_terminate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
			this.btn_terminate.FlatAppearance.BorderSize = 3;
			this.btn_terminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_terminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_terminate.Location = new System.Drawing.Point(12, 60);
			this.btn_terminate.Name = "btn_terminate";
			this.btn_terminate.Size = new System.Drawing.Size(84, 28);
			this.btn_terminate.TabIndex = 0;
			this.btn_terminate.Text = "Delete";
			this.btn_terminate.UseVisualStyleBackColor = true;
			this.btn_terminate.Click += new System.EventHandler(this.Btn_terminateClick);
			// 
			// chb_split
			// 
			this.chb_split.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chb_split.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.chb_split.Location = new System.Drawing.Point(12, 13);
			this.chb_split.Name = "chb_split";
			this.chb_split.Size = new System.Drawing.Size(104, 24);
			this.chb_split.TabIndex = 1;
			this.chb_split.Text = "Split delete";
			this.chb_split.UseVisualStyleBackColor = true;
			this.chb_split.CheckedChanged += new System.EventHandler(this.Chb_splitCheckedChanged);
			// 
			// rdb_type1
			// 
			this.rdb_type1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
			this.rdb_type1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdb_type1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.rdb_type1.Location = new System.Drawing.Point(159, 12);
			this.rdb_type1.Name = "rdb_type1";
			this.rdb_type1.Size = new System.Drawing.Size(104, 24);
			this.rdb_type1.TabIndex = 2;
			this.rdb_type1.TabStop = true;
			this.rdb_type1.Text = "Just Audio";
			this.rdb_type1.UseVisualStyleBackColor = true;
			this.rdb_type1.Click += new System.EventHandler(this.Rdb_type1Click);
			// 
			// rdb_type2
			// 
			this.rdb_type2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdb_type2.Location = new System.Drawing.Point(159, 42);
			this.rdb_type2.Name = "rdb_type2";
			this.rdb_type2.Size = new System.Drawing.Size(104, 24);
			this.rdb_type2.TabIndex = 3;
			this.rdb_type2.TabStop = true;
			this.rdb_type2.Text = "Just Video";
			this.rdb_type2.UseVisualStyleBackColor = true;
			this.rdb_type2.Click += new System.EventHandler(this.Rdb_type2Click);
			// 
			// rdb_type3
			// 
			this.rdb_type3.Checked = true;
			this.rdb_type3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdb_type3.Location = new System.Drawing.Point(159, 76);
			this.rdb_type3.Name = "rdb_type3";
			this.rdb_type3.Size = new System.Drawing.Size(104, 24);
			this.rdb_type3.TabIndex = 4;
			this.rdb_type3.TabStop = true;
			this.rdb_type3.Text = "Video and Audio";
			this.rdb_type3.UseVisualStyleBackColor = true;
			this.rdb_type3.Click += new System.EventHandler(this.Rdb_type3Click);
			// 
			// pbt_setting
			// 
			this.pbt_setting.Image = global::deleteatcursorpro.Resource1.settings;
			this.pbt_setting.Location = new System.Drawing.Point(262, 7);
			this.pbt_setting.Name = "pbt_setting";
			this.pbt_setting.Size = new System.Drawing.Size(28, 29);
			this.pbt_setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbt_setting.TabIndex = 5;
			this.pbt_setting.TabStop = false;
			this.pbt_setting.Click += new System.EventHandler(this.Pbt_settingClick);
			this.pbt_setting.MouseEnter += new System.EventHandler(this.Pbt_settingMouseEnter);
			this.pbt_setting.MouseLeave += new System.EventHandler(this.Pbt_settingMouseLeave);
			// 
			// tbx_preview
			// 
			this.tbx_preview.Enabled = false;
			this.tbx_preview.Location = new System.Drawing.Point(17, 48);
			this.tbx_preview.Name = "tbx_preview";
			this.tbx_preview.Size = new System.Drawing.Size(138, 20);
			this.tbx_preview.TabIndex = 6;
			this.tbx_preview.Text = "None + None";
			// 
			// cbb_selectshort
			// 
			this.cbb_selectshort.BackColor = System.Drawing.SystemColors.ControlDark;
			this.cbb_selectshort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbb_selectshort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbb_selectshort.FormattingEnabled = true;
			this.cbb_selectshort.Items.AddRange(new object[] {
			"Split",
			"Just Audio",
			"Just Video",
			"Video and Audio"});
			this.cbb_selectshort.Location = new System.Drawing.Point(17, 23);
			this.cbb_selectshort.Name = "cbb_selectshort";
			this.cbb_selectshort.Size = new System.Drawing.Size(138, 21);
			this.cbb_selectshort.TabIndex = 7;
			this.cbb_selectshort.SelectedIndexChanged += new System.EventHandler(this.Cbb_selectshortSelectedIndexChanged);
			// 
			// btn_savekey
			// 
			this.btn_savekey.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
			this.btn_savekey.FlatAppearance.BorderSize = 3;
			this.btn_savekey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_savekey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_savekey.Location = new System.Drawing.Point(43, 77);
			this.btn_savekey.Name = "btn_savekey";
			this.btn_savekey.Size = new System.Drawing.Size(84, 28);
			this.btn_savekey.TabIndex = 8;
			this.btn_savekey.Text = "Save";
			this.btn_savekey.UseVisualStyleBackColor = true;
			this.btn_savekey.Click += new System.EventHandler(this.Btn_savekeyClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(17, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 18);
			this.label1.TabIndex = 9;
			this.label1.Text = "Custom shortcuts";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btn_savekey);
			this.panel1.Controls.Add(this.tbx_preview);
			this.panel1.Controls.Add(this.cbb_selectshort);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(322, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(172, 118);
			this.panel1.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(492, 116);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pbt_setting);
			this.Controls.Add(this.rdb_type3);
			this.Controls.Add(this.rdb_type2);
			this.Controls.Add(this.rdb_type1);
			this.Controls.Add(this.chb_split);
			this.Controls.Add(this.btn_terminate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::deleteatcursorpro.Resource1.scripticon;
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Delete at Cursor PRO Edition (LOL)";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pbt_setting)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
