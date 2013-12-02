using MetroFramework.Forms;

namespace MowChat
{
	partial class CharacterSelect
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
            this.characterButton = new MetroFramework.Controls.MetroButton();
            this.scrollPanel = new MetroFramework.Controls.MetroPanel();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterButton
            // 
            this.characterButton.Location = new System.Drawing.Point(3, 3);
            this.characterButton.Name = "characterButton";
            this.characterButton.Size = new System.Drawing.Size(197, 35);
            this.characterButton.TabIndex = 2;
            this.characterButton.Text = "Character";
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.characterButton);
            this.scrollPanel.HorizontalScrollbar = true;
            this.scrollPanel.HorizontalScrollbarBarColor = true;
            this.scrollPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.scrollPanel.HorizontalScrollbarSize = 10;
            this.scrollPanel.Location = new System.Drawing.Point(10, 63);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(203, 310);
            this.scrollPanel.TabIndex = 1;
            this.scrollPanel.VerticalScrollbar = true;
            this.scrollPanel.VerticalScrollbarBarColor = true;
            this.scrollPanel.VerticalScrollbarHighlightOnWheel = false;
            this.scrollPanel.VerticalScrollbarSize = 10;
            // 
            // CharacterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 384);
            this.Controls.Add(this.scrollPanel);
            this.MaximizeBox = false;
            this.Name = "CharacterSelect";
            this.ShadowType = MetroFormShadowType.DropShadow;
            this.Text = "Select A Character";
            this.Load += new System.EventHandler(this.CharacterSelect_Load);
            this.scrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroButton characterButton;
		private MetroFramework.Controls.MetroPanel scrollPanel;

	}
}