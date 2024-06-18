using System;

namespace AmaknaProxy.Engine.View
{
    partial class ClientControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBox_Packets = new System.Windows.Forms.GroupBox();
            this.CheckBox_Enable = new System.Windows.Forms.CheckBox();
            this.DataGridView_PacketsList = new System.Windows.Forms.DataGridView();
            this.Column_Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_Clean = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupBox_Details = new System.Windows.Forms.GroupBox();
            this.TreeView_InfosPacket = new System.Windows.Forms.TreeView();
            this.GroupBox_Packets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PacketsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupBox_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Packets
            // 
            this.GroupBox_Packets.Controls.Add(this.CheckBox_Enable);
            this.GroupBox_Packets.Controls.Add(this.DataGridView_PacketsList);
            this.GroupBox_Packets.Controls.Add(this.Button_Clean);
            this.GroupBox_Packets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Packets.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_Packets.Name = "GroupBox_Packets";
            this.GroupBox_Packets.Size = new System.Drawing.Size(337, 528);
            this.GroupBox_Packets.TabIndex = 2;
            this.GroupBox_Packets.TabStop = false;
            this.GroupBox_Packets.Text = "Listes des paquets reçus/envoyés";
            // 
            // CheckBox_Enable
            // 
            this.CheckBox_Enable.AutoSize = true;
            this.CheckBox_Enable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CheckBox_Enable.Location = new System.Drawing.Point(3, 484);
            this.CheckBox_Enable.Name = "CheckBox_Enable";
            this.CheckBox_Enable.Size = new System.Drawing.Size(331, 17);
            this.CheckBox_Enable.TabIndex = 2;
            this.CheckBox_Enable.Text = "Activé";
            this.CheckBox_Enable.UseVisualStyleBackColor = true;
            // 
            // DataGridView_PacketsList
            // 
            this.DataGridView_PacketsList.AllowUserToAddRows = false;
            this.DataGridView_PacketsList.AllowUserToDeleteRows = false;
            this.DataGridView_PacketsList.AllowUserToResizeColumns = false;
            this.DataGridView_PacketsList.AllowUserToResizeRows = false;
            this.DataGridView_PacketsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_PacketsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Hour,
            this.Column_Origin,
            this.Column_ID,
            this.Column_Name});
            this.DataGridView_PacketsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_PacketsList.Location = new System.Drawing.Point(3, 18);
            this.DataGridView_PacketsList.MultiSelect = false;
            this.DataGridView_PacketsList.Name = "DataGridView_PacketsList";
            this.DataGridView_PacketsList.ReadOnly = true;
            this.DataGridView_PacketsList.RowHeadersVisible = false;
            this.DataGridView_PacketsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_PacketsList.Size = new System.Drawing.Size(331, 483);
            this.DataGridView_PacketsList.TabIndex = 0;
            this.DataGridView_PacketsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_PacketsList_CellClick);
            // 
            // Column_Hour
            // 
            this.Column_Hour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column_Hour.HeaderText = "Heure";
            this.Column_Hour.MinimumWidth = 45;
            this.Column_Hour.Name = "Column_Hour";
            this.Column_Hour.ReadOnly = true;
            this.Column_Hour.Width = 45;
            // 
            // Column_Origin
            // 
            this.Column_Origin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column_Origin.HeaderText = "Origine";
            this.Column_Origin.MinimumWidth = 50;
            this.Column_Origin.Name = "Column_Origin";
            this.Column_Origin.ReadOnly = true;
            this.Column_Origin.Width = 50;
            // 
            // Column_ID
            // 
            this.Column_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.MinimumWidth = 25;
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 25;
            // 
            // Column_Name
            // 
            this.Column_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Name.HeaderText = "Nom";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Button_Clean
            // 
            this.Button_Clean.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_Clean.Location = new System.Drawing.Point(3, 501);
            this.Button_Clean.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Clean.Name = "Button_Clean";
            this.Button_Clean.Size = new System.Drawing.Size(331, 24);
            this.Button_Clean.TabIndex = 1;
            this.Button_Clean.Text = "Vider l\'historique";
            this.Button_Clean.UseVisualStyleBackColor = true;
            this.Button_Clean.Click += new System.EventHandler(this.Button_Clean_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GroupBox_Packets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GroupBox_Details);
            this.splitContainer1.Size = new System.Drawing.Size(682, 528);
            this.splitContainer1.SplitterDistance = 337;
            this.splitContainer1.TabIndex = 3;
            // 
            // GroupBox_Details
            // 
            this.GroupBox_Details.Controls.Add(this.TreeView_InfosPacket);
            this.GroupBox_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Details.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_Details.Name = "GroupBox_Details";
            this.GroupBox_Details.Size = new System.Drawing.Size(341, 528);
            this.GroupBox_Details.TabIndex = 3;
            this.GroupBox_Details.TabStop = false;
            this.GroupBox_Details.Text = "Information sur le paquet";
            // 
            // TreeView_InfosPacket
            // 
            this.TreeView_InfosPacket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView_InfosPacket.Location = new System.Drawing.Point(3, 18);
            this.TreeView_InfosPacket.Name = "TreeView_InfosPacket";
            this.TreeView_InfosPacket.Size = new System.Drawing.Size(335, 507);
            this.TreeView_InfosPacket.TabIndex = 0;
            // 
            // ClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClientControl";
            this.Size = new System.Drawing.Size(682, 528);
            this.GroupBox_Packets.ResumeLayout(false);
            this.GroupBox_Packets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PacketsList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GroupBox_Details.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox_Packets;
        public System.Windows.Forms.CheckBox CheckBox_Enable;
        public System.Windows.Forms.DataGridView DataGridView_PacketsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Origin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        internal System.Windows.Forms.Button Button_Clean;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.GroupBox GroupBox_Details;
        public System.Windows.Forms.TreeView TreeView_InfosPacket;
    }
}
