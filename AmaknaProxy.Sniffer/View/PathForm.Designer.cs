namespace AmaknaProxy.Engine.View
{
    partial class PathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathForm));
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.Button_Apply = new System.Windows.Forms.Button();
            this.Label_PathTxt = new System.Windows.Forms.Label();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(12, 37);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(389, 22);
            this.TextBox_Path.TabIndex = 0;
            // 
            // Button_Apply
            // 
            this.Button_Apply.Location = new System.Drawing.Point(455, 37);
            this.Button_Apply.Name = "Button_Apply";
            this.Button_Apply.Size = new System.Drawing.Size(75, 23);
            this.Button_Apply.TabIndex = 2;
            this.Button_Apply.Text = "Appliquer";
            this.Button_Apply.UseVisualStyleBackColor = true;
            this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
            // 
            // Label_PathTxt
            // 
            this.Label_PathTxt.AutoSize = true;
            this.Label_PathTxt.Location = new System.Drawing.Point(9, 13);
            this.Label_PathTxt.Name = "Label_PathTxt";
            this.Label_PathTxt.Size = new System.Drawing.Size(281, 13);
            this.Label_PathTxt.TabIndex = 3;
            this.Label_PathTxt.Text = "Indiquez le chemin d\'accès au répertoire de votre jeu.\r\n";
            // 
            // Button_Browse
            // 
            this.Button_Browse.Location = new System.Drawing.Point(407, 37);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(37, 22);
            this.Button_Browse.TabIndex = 4;
            this.Button_Browse.Text = "...";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 78);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.Label_PathTxt);
            this.Controls.Add(this.Button_Apply);
            this.Controls.Add(this.TextBox_Path);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PathForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chemin d\'accès";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.Button Button_Apply;
        private System.Windows.Forms.Label Label_PathTxt;
        private System.Windows.Forms.Button Button_Browse;
    }
}