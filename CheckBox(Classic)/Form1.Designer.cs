
namespace CheckBox_Classic_
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.changeText = new System.Windows.Forms.Button();
            this.enableCheckbox = new System.Windows.Forms.CheckBox();
            this.labelToChange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeText
            // 
            this.changeText.AutoSize = true;
            this.changeText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeText.Location = new System.Drawing.Point(12, 12);
            this.changeText.Name = "changeText";
            this.changeText.Size = new System.Drawing.Size(140, 23);
            this.changeText.TabIndex = 0;
            this.changeText.Text = "Kliknięcie zmienia etykietę";
            this.changeText.UseVisualStyleBackColor = true;
            this.changeText.Click += new System.EventHandler(this.changeText_Click);
            // 
            // enableCheckbox
            // 
            this.enableCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enableCheckbox.AutoSize = true;
            this.enableCheckbox.Checked = true;
            this.enableCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCheckbox.Location = new System.Drawing.Point(391, 12);
            this.enableCheckbox.Name = "enableCheckbox";
            this.enableCheckbox.Size = new System.Drawing.Size(139, 17);
            this.enableCheckbox.TabIndex = 1;
            this.enableCheckbox.Text = "Włącza zmianę etykiety";
            this.enableCheckbox.UseVisualStyleBackColor = true;
            // 
            // labelToChange
            // 
            this.labelToChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelToChange.Location = new System.Drawing.Point(12, 114);
            this.labelToChange.Name = "labelToChange";
            this.labelToChange.Size = new System.Drawing.Size(518, 23);
            this.labelToChange.TabIndex = 2;
            this.labelToChange.Text = "Naciśnij przycisk, aby zmienić tekst";
            this.labelToChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 146);
            this.Controls.Add(this.labelToChange);
            this.Controls.Add(this.enableCheckbox);
            this.Controls.Add(this.changeText);
            this.Name = "Form1";
            this.Text = "CheckBox (Classic)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeText;
        private System.Windows.Forms.CheckBox enableCheckbox;
        private System.Windows.Forms.Label labelToChange;
    }
}

