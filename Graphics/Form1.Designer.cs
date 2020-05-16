namespace Graphics
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblTriangle = new System.Windows.Forms.Label();
			this.btnTriangle = new System.Windows.Forms.Button();
			this.lblSquare = new System.Windows.Forms.Label();
			this.btnSquare = new System.Windows.Forms.Button();
			this.lblTexture = new System.Windows.Forms.Label();
			this.btnTexture = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnImage = new System.Windows.Forms.Button();
			this.lblWindow = new System.Windows.Forms.Label();
			this.btnCreate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.Location = new System.Drawing.Point(6, 724);
			this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(0, 18);
			this.lblVersion.TabIndex = 2;
			// 
			// lblTriangle
			// 
			this.lblTriangle.AutoSize = true;
			this.lblTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTriangle.Location = new System.Drawing.Point(10, 53);
			this.lblTriangle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTriangle.Name = "lblTriangle";
			this.lblTriangle.Size = new System.Drawing.Size(146, 18);
			this.lblTriangle.TabIndex = 4;
			this.lblTriangle.Text = "Create New Triangle:";
			// 
			// btnTriangle
			// 
			this.btnTriangle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTriangle.Location = new System.Drawing.Point(162, 47);
			this.btnTriangle.Margin = new System.Windows.Forms.Padding(2);
			this.btnTriangle.Name = "btnTriangle";
			this.btnTriangle.Size = new System.Drawing.Size(82, 31);
			this.btnTriangle.TabIndex = 3;
			this.btnTriangle.Text = "Triangle";
			this.btnTriangle.UseVisualStyleBackColor = false;
			this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
			// 
			// lblSquare
			// 
			this.lblSquare.AutoSize = true;
			this.lblSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSquare.Location = new System.Drawing.Point(15, 88);
			this.lblSquare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblSquare.Name = "lblSquare";
			this.lblSquare.Size = new System.Drawing.Size(141, 18);
			this.lblSquare.TabIndex = 6;
			this.lblSquare.Text = "Create New Square:";
			// 
			// btnSquare
			// 
			this.btnSquare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSquare.Location = new System.Drawing.Point(162, 82);
			this.btnSquare.Margin = new System.Windows.Forms.Padding(2);
			this.btnSquare.Name = "btnSquare";
			this.btnSquare.Size = new System.Drawing.Size(82, 31);
			this.btnSquare.TabIndex = 5;
			this.btnSquare.Text = "Square";
			this.btnSquare.UseVisualStyleBackColor = false;
			this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
			// 
			// lblTexture
			// 
			this.lblTexture.AutoSize = true;
			this.lblTexture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTexture.Location = new System.Drawing.Point(13, 123);
			this.lblTexture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTexture.Name = "lblTexture";
			this.lblTexture.Size = new System.Drawing.Size(143, 18);
			this.lblTexture.TabIndex = 8;
			this.lblTexture.Text = "Create New Texture:";
			// 
			// btnTexture
			// 
			this.btnTexture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnTexture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTexture.Location = new System.Drawing.Point(162, 117);
			this.btnTexture.Margin = new System.Windows.Forms.Padding(2);
			this.btnTexture.Name = "btnTexture";
			this.btnTexture.Size = new System.Drawing.Size(82, 31);
			this.btnTexture.TabIndex = 7;
			this.btnTexture.Text = "Texture";
			this.btnTexture.UseVisualStyleBackColor = false;
			this.btnTexture.Click += new System.EventHandler(this.btnTexture_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(39, 158);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 18);
			this.label1.TabIndex = 10;
			this.label1.Text = "Generate Image:";
			// 
			// btnImage
			// 
			this.btnImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnImage.Location = new System.Drawing.Point(162, 152);
			this.btnImage.Margin = new System.Windows.Forms.Padding(2);
			this.btnImage.Name = "btnImage";
			this.btnImage.Size = new System.Drawing.Size(82, 31);
			this.btnImage.TabIndex = 9;
			this.btnImage.Text = "Image";
			this.btnImage.UseVisualStyleBackColor = false;
			this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
			// 
			// lblWindow
			// 
			this.lblWindow.AutoSize = true;
			this.lblWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWindow.Location = new System.Drawing.Point(10, 18);
			this.lblWindow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWindow.Name = "lblWindow";
			this.lblWindow.Size = new System.Drawing.Size(148, 18);
			this.lblWindow.TabIndex = 1;
			this.lblWindow.Text = "Create New Window:";
			// 
			// btnCreate
			// 
			this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCreate.Location = new System.Drawing.Point(162, 12);
			this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(82, 31);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create!";
			this.btnCreate.UseVisualStyleBackColor = false;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(250, 552);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnImage);
			this.Controls.Add(this.lblTexture);
			this.Controls.Add(this.btnTexture);
			this.Controls.Add(this.lblSquare);
			this.Controls.Add(this.btnSquare);
			this.Controls.Add(this.lblTriangle);
			this.Controls.Add(this.btnTriangle);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblWindow);
			this.Controls.Add(this.btnCreate);
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "GL Graphics";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTriangle;
        private System.Windows.Forms.Button btnTriangle;
		private System.Windows.Forms.Label lblSquare;
		private System.Windows.Forms.Button btnSquare;
		private System.Windows.Forms.Label lblTexture;
		private System.Windows.Forms.Button btnTexture;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnImage;
		private System.Windows.Forms.Label lblWindow;
		private System.Windows.Forms.Button btnCreate;
    }
}

