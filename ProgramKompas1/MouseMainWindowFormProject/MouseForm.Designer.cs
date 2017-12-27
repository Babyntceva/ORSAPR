namespace MouseMainWindowFormProject
{
    partial class MouseForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonBuild = new System.Windows.Forms.Button();
            this._textBoxFrontOfTheMouse = new System.Windows.Forms.TextBox();
            this._textBoxBackOfTheMouse = new System.Windows.Forms.TextBox();
            this._textBoxLengthOfMouse = new System.Windows.Forms.TextBox();
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse = new System.Windows.Forms.TextBox();
            this._textBoxHeightOfTheSecondMouse = new System.Windows.Forms.TextBox();
            this._labelFrontOfTheMouse = new System.Windows.Forms.Label();
            this._labelBackOfTheMouse = new System.Windows.Forms.Label();
            this._labelLengthOfMouse = new System.Windows.Forms.Label();
            this._labelTheHeightOfTheFirstLevelOfTheMouse = new System.Windows.Forms.Label();
            this._labelHeightOfTheSecondMouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonBuild
            // 
            this._buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBuild.Location = new System.Drawing.Point(178, 144);
            this._buttonBuild.Name = "_buttonBuild";
            this._buttonBuild.Size = new System.Drawing.Size(75, 23);
            this._buttonBuild.TabIndex = 6;
            this._buttonBuild.Text = "Построить";
            this._buttonBuild.UseVisualStyleBackColor = true;
            this._buttonBuild.Click += new System.EventHandler(this.ButtonBuild_Click);
            // 
            // _textBoxFrontOfTheMouse
            // 
            this._textBoxFrontOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxFrontOfTheMouse.Location = new System.Drawing.Point(153, 39);
            this._textBoxFrontOfTheMouse.Name = "_textBoxFrontOfTheMouse";
            this._textBoxFrontOfTheMouse.Size = new System.Drawing.Size(100, 20);
            this._textBoxFrontOfTheMouse.TabIndex = 2;
            this._textBoxFrontOfTheMouse.Leave += new System.EventHandler(this.TextBoxFrontOfTheMouseLeave);
            this._textBoxFrontOfTheMouse.MouseHover += new System.EventHandler(this.TextBoxFrontOfTheMouseHover);
            // 
            // _textBoxBackOfTheMouse
            // 
            this._textBoxBackOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxBackOfTheMouse.Location = new System.Drawing.Point(153, 65);
            this._textBoxBackOfTheMouse.Name = "_textBoxBackOfTheMouse";
            this._textBoxBackOfTheMouse.Size = new System.Drawing.Size(100, 20);
            this._textBoxBackOfTheMouse.TabIndex = 3;
            this._textBoxBackOfTheMouse.Leave += new System.EventHandler(this.TextBoxBackOfTheMouseLeave);
            this._textBoxBackOfTheMouse.MouseHover += new System.EventHandler(this.TextBoxBackOfTheMouseHover);
            // 
            // _textBoxLengthOfMouse
            // 
            this._textBoxLengthOfMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxLengthOfMouse.Location = new System.Drawing.Point(153, 13);
            this._textBoxLengthOfMouse.Name = "_textBoxLengthOfMouse";
            this._textBoxLengthOfMouse.Size = new System.Drawing.Size(100, 20);
            this._textBoxLengthOfMouse.TabIndex = 1;
            this._textBoxLengthOfMouse.Leave += new System.EventHandler(this.TextBoxLengthOfMouseLeave);
            this._textBoxLengthOfMouse.MouseHover += new System.EventHandler(this.TextBoxLengthOfMouseMouseHover);
            // 
            // _textBoxTheHeightOfTheFirstLevelOfTheMouse
            // 
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.Location = new System.Drawing.Point(153, 91);
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.Name = "_textBoxTheHeightOfTheFirstLevelOfTheMouse";
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.Size = new System.Drawing.Size(100, 20);
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.TabIndex = 4;
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.Leave += new System.EventHandler(this.TextBoxHeightFirstLevelOfTheMouseLeave);
            this._textBoxTheHeightOfTheFirstLevelOfTheMouse.MouseHover += new System.EventHandler(this.TextBoxTheHeightOfTheFirstLevelOfTheMouseHover);
            // 
            // _textBoxHeightOfTheSecondMouse
            // 
            this._textBoxHeightOfTheSecondMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxHeightOfTheSecondMouse.Location = new System.Drawing.Point(153, 117);
            this._textBoxHeightOfTheSecondMouse.Name = "_textBoxHeightOfTheSecondMouse";
            this._textBoxHeightOfTheSecondMouse.Size = new System.Drawing.Size(100, 20);
            this._textBoxHeightOfTheSecondMouse.TabIndex = 5;
            this._textBoxHeightOfTheSecondMouse.Leave += new System.EventHandler(this.TextBoxHeightOfTheSecondMouseLeave);
            this._textBoxHeightOfTheSecondMouse.MouseHover += new System.EventHandler(this.TextBoxHeightOfTheSecondMouseHover);
            // 
            // _labelFrontOfTheMouse
            // 
            this._labelFrontOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelFrontOfTheMouse.AutoSize = true;
            this._labelFrontOfTheMouse.Location = new System.Drawing.Point(12, 46);
            this._labelFrontOfTheMouse.Name = "_labelFrontOfTheMouse";
            this._labelFrontOfTheMouse.Size = new System.Drawing.Size(88, 13);
            this._labelFrontOfTheMouse.TabIndex = 2;
            this._labelFrontOfTheMouse.Text = "Передняя часть";
            // 
            // _labelBackOfTheMouse
            // 
            this._labelBackOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelBackOfTheMouse.AutoSize = true;
            this._labelBackOfTheMouse.Location = new System.Drawing.Point(12, 72);
            this._labelBackOfTheMouse.Name = "_labelBackOfTheMouse";
            this._labelBackOfTheMouse.Size = new System.Drawing.Size(75, 13);
            this._labelBackOfTheMouse.TabIndex = 2;
            this._labelBackOfTheMouse.Text = "Задняя часть";
            // 
            // _labelLengthOfMouse
            // 
            this._labelLengthOfMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelLengthOfMouse.AutoSize = true;
            this._labelLengthOfMouse.Location = new System.Drawing.Point(12, 20);
            this._labelLengthOfMouse.Name = "_labelLengthOfMouse";
            this._labelLengthOfMouse.Size = new System.Drawing.Size(73, 13);
            this._labelLengthOfMouse.TabIndex = 2;
            this._labelLengthOfMouse.Text = "Длина мыши";
            // 
            // _labelTheHeightOfTheFirstLevelOfTheMouse
            // 
            this._labelTheHeightOfTheFirstLevelOfTheMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTheHeightOfTheFirstLevelOfTheMouse.AutoSize = true;
            this._labelTheHeightOfTheFirstLevelOfTheMouse.Location = new System.Drawing.Point(11, 98);
            this._labelTheHeightOfTheFirstLevelOfTheMouse.Name = "_labelTheHeightOfTheFirstLevelOfTheMouse";
            this._labelTheHeightOfTheFirstLevelOfTheMouse.Size = new System.Drawing.Size(127, 13);
            this._labelTheHeightOfTheFirstLevelOfTheMouse.TabIndex = 2;
            this._labelTheHeightOfTheFirstLevelOfTheMouse.Text = "Высота первого уровня";
            // 
            // _labelHeightOfTheSecondMouse
            // 
            this._labelHeightOfTheSecondMouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelHeightOfTheSecondMouse.AutoSize = true;
            this._labelHeightOfTheSecondMouse.Location = new System.Drawing.Point(12, 124);
            this._labelHeightOfTheSecondMouse.Name = "_labelHeightOfTheSecondMouse";
            this._labelHeightOfTheSecondMouse.Size = new System.Drawing.Size(126, 13);
            this._labelHeightOfTheSecondMouse.TabIndex = 2;
            this._labelHeightOfTheSecondMouse.Text = "Высота второго уровня";
            // 
            // MouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 179);
            this.Controls.Add(this._labelHeightOfTheSecondMouse);
            this.Controls.Add(this._labelTheHeightOfTheFirstLevelOfTheMouse);
            this.Controls.Add(this._labelLengthOfMouse);
            this.Controls.Add(this._labelBackOfTheMouse);
            this.Controls.Add(this._labelFrontOfTheMouse);
            this.Controls.Add(this._textBoxHeightOfTheSecondMouse);
            this.Controls.Add(this._textBoxTheHeightOfTheFirstLevelOfTheMouse);
            this.Controls.Add(this._textBoxLengthOfMouse);
            this.Controls.Add(this._textBoxBackOfTheMouse);
            this.Controls.Add(this._textBoxFrontOfTheMouse);
            this.Controls.Add(this._buttonBuild);
            this.Name = "MouseForm";
            this.Text = "Mouse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonBuild;
        private System.Windows.Forms.TextBox _textBoxFrontOfTheMouse;
        private System.Windows.Forms.TextBox _textBoxBackOfTheMouse;
        private System.Windows.Forms.TextBox _textBoxLengthOfMouse;
        private System.Windows.Forms.TextBox _textBoxTheHeightOfTheFirstLevelOfTheMouse;
        private System.Windows.Forms.TextBox _textBoxHeightOfTheSecondMouse;
        private System.Windows.Forms.Label _labelFrontOfTheMouse;
        private System.Windows.Forms.Label _labelBackOfTheMouse;
        private System.Windows.Forms.Label _labelLengthOfMouse;
        private System.Windows.Forms.Label _labelTheHeightOfTheFirstLevelOfTheMouse;
        private System.Windows.Forms.Label _labelHeightOfTheSecondMouse;
    }
}

