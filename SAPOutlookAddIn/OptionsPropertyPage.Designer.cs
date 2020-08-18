namespace SAPOutlookAddIn
{
	partial class OptionsPropertyPage
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
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.labelPath = new System.Windows.Forms.Label();
			this.textBoxPattern = new System.Windows.Forms.TextBox();
			this.labelPattern = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxPath
			// 
			this.textBoxPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxPath.Location = new System.Drawing.Point(0, 17);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(365, 22);
			this.textBoxPath.TabIndex = 0;
			this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
			// 
			// labelPath
			// 
			this.labelPath.AutoSize = true;
			this.labelPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPath.Location = new System.Drawing.Point(0, 0);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(261, 17);
			this.labelPath.TabIndex = 1;
			this.labelPath.Text = "Chemin de sauvegarde des emails:";
			// 
			// textBoxPattern
			// 
			this.textBoxPattern.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxPattern.Location = new System.Drawing.Point(0, 56);
			this.textBoxPattern.Name = "textBoxPattern";
			this.textBoxPattern.Size = new System.Drawing.Size(365, 22);
			this.textBoxPattern.TabIndex = 2;
			this.textBoxPattern.TextChanged += new System.EventHandler(this.textBoxPattern_TextChanged);
			// 
			// labelPattern
			// 
			this.labelPattern.AutoSize = true;
			this.labelPattern.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern.Location = new System.Drawing.Point(0, 39);
			this.labelPattern.Name = "labelPattern";
			this.labelPattern.Size = new System.Drawing.Size(208, 17);
			this.labelPattern.TabIndex = 3;
			this.labelPattern.Text = "Pattern de reconnaissance:";
			// 
			// OptionsPropertyPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxPattern);
			this.Controls.Add(this.labelPattern);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.labelPath);
			this.Name = "OptionsPropertyPage";
			this.Size = new System.Drawing.Size(365, 146);
			this.Load += new System.EventHandler(this.OptionsPropertyPage_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.TextBox textBoxPattern;
		private System.Windows.Forms.Label labelPattern;
	}
}
